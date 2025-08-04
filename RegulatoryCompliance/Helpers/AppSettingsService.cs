using RegulatoryCompliance.Configuration;
using RegulatoryCompliance.Interfaces;
using Microsoft.Extensions.Options;

namespace RegulatoryCompliance.Helpers
{
    public class AppSettingsService : IAppSettingsService
    {
        private readonly AppSettings _settings;

        public AppSettingsService(IOptions<AppSettings> options)
        {
            _settings = options.Value;
        }

        //App 
        public int AppId => _settings.AppId;
        public string AppName => _settings.AppName;

        //API values
        public string Auth0_ClientId => _settings.Auth0_ClientId;
        public string Auth0_ClientSecret => _settings.Auth0_ClientSecret;
        public string Auth0_TokenURL => _settings.Auth0_TokenURL;

        //SafeHarborService values
        public string SafeHarborService_ClientId => _settings.SafeHarborService_ClientId;
        public string SafeHarborService_ClientSecret => _settings.SafeHarborService_ClientSecret;
        public string SafeHarborService_TokenURL => _settings.SafeHarborService_TokenURL;

        //HighCostService values
        public string HighCostService_ClientId => _settings.HighCostService_ClientId;
        public string HighCostService_ClientSecret => _settings.HighCostService_ClientSecret;
        public string HighCostService_TokenURL => _settings.HighCostService_TokenURL;

        //PoinAndFeesService values
        public string PoinAndFeesService_ClientId => _settings.PoinAndFeesService_ClientId;
        public string PoinAndFeesService_ClientSecret => _settings.PoinAndFeesService_ClientSecret;
        public string PoinAndFeesService_TokenURL => _settings.PoinAndFeesService_TokenURL;

        //StateRegulatoryService values
        public string StateRegulatoryService_ClientId => _settings.StateRegulatoryService_ClientId;
        public string StateRegulatoryService_ClientSecret => _settings.StateRegulatoryService_ClientSecret;
        public string StateRegulatoryService_TokenURL => _settings.StateRegulatoryService_TokenURL;
    }
}
