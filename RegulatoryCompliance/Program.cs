using Common.Configuration;
using Common.Helpers;
using Common.Interfaces;
using RuleEngine.Facade;
using RuleEngine.Interfaces;
using SalManager;
using SqlManager;
using SqlManager.Interfaces;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using Serilog.Sinks.SystemConsole;
using Serilog.Sinks.Seq;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.ApplicationInsights.Extensibility;
using StackExchange.Profiling;
using Microsoft.Extensions.Caching.Memory;

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .Enrich.FromLogContext()
    .Enrich.WithCorrelationId()
    .Enrich.WithProperty("UserName", Environment.UserName)
    .WriteTo.Console()
    .WriteTo.File(new CompactJsonFormatter(), "Logs/log-.json", rollingInterval: RollingInterval.Day)
    .WriteTo.Seq("http://localhost:5341") // Change URL if using remote Seq server
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
// Add health checks
builder.Services.AddHealthChecks();
// Add Application Insights telemetry
builder.Services.AddApplicationInsightsTelemetry();
// Add MiniProfiler for performance profiling
builder.Services.AddMiniProfiler(options =>
{
    options.RouteBasePath = "/profiler";
});

// Add in-memory caching
builder.Services.AddMemoryCache();
// Add API versioning
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});
// JWT Authentication configuration
var jwtKey = builder.Configuration["Jwt:Key"] ?? "YourSuperSecretKeyHere";
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "JwtBearer";
    options.DefaultChallengeScheme = "JwtBearer";
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtKey))
    };
});
builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<RegulatoryCompliance.Validation.HighCostTestInputValidator>();
builder.Services.Configure<AppSettingsConfig>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddSingleton<IAppSettingsService, AppSettingsService>();
builder.Services.AddSingleton<SqlManager.Interfaces.IDbConnectionFactory, SqlManager.SqlDbConnectionFactory>();

builder.Services.AddTransient<IRegulatoryRuleFacade, SafeHarborRuleFacade>();
builder.Services.AddTransient<IRegulatoryRuleFacade, HighCostRuleFacade>();
builder.Services.AddTransient<IRegulatoryRuleFacade, PointsAndFeesRuleFacade>();
builder.Services.AddTransient<IRegulatoryRuleFacade, StateRegulatoryRulesFacade>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Add versioning to Swagger
    var provider = builder.Services.BuildServiceProvider().GetRequiredService<Microsoft.AspNetCore.Mvc.ApiExplorer.IApiVersionDescriptionProvider>();
    foreach (var description in provider.ApiVersionDescriptions)
    {
        c.SwaggerDoc(description.GroupName, new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = $"RegulatoryCompliance API {description.ApiVersion}",
            Version = description.ApiVersion.ToString(),
        });
    }

    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: 'Authorization: Bearer {token}'",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
    });
    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer",
                },
            },
            System.Array.Empty<string>()
        },
    });
});


var app = builder.Build();
// Map health check endpoint
app.MapHealthChecks("/health");
// Optionally, expose Application Insights telemetry configuration for advanced scenarios
var telemetryConfig = app.Services.GetRequiredService<TelemetryConfiguration>();
// Use MiniProfiler middleware
app.UseMiniProfiler();
// Enable authentication middleware
app.UseAuthentication();

// Use custom global exception handling middleware
app.UseMiddleware<RegulatoryCompliance.ExceptionMiddleware.ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    var apiVersionProvider = app.Services.GetRequiredService<Microsoft.AspNetCore.Mvc.ApiExplorer.IApiVersionDescriptionProvider>();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in apiVersionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", $"API {description.GroupName.ToUpperInvariant()}");
        }
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
