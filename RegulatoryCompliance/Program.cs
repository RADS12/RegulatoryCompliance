using Common.Configuration;
using Common.Helpers;
using Common.Interfaces;
using RuleEngine.Facade;
using RuleEngine.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configure<AppSettingsConfig>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddSingleton<IAppSettingsService, AppSettingsService>();

builder.Services.AddTransient<IRegulatoryRuleFacade, SafeHarborRuleFacade>();
builder.Services.AddTransient<IRegulatoryRuleFacade, HighCostRuleFacade>();
builder.Services.AddTransient<IRegulatoryRuleFacade, PointsAndFeesRuleFacade>();
builder.Services.AddTransient<IRegulatoryRuleFacade, StateRegulatoryRulesFacade>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

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
