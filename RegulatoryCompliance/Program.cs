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
using FluentValidation.AspNetCore;
using FluentValidation;
using Serilog.Enrichers.CorrelationId;

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
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Use custom global exception handling middleware
app.UseMiddleware<RegulatoryCompliance.ExceptionMiddleware.ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
