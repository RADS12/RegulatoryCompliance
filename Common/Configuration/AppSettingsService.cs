using Common.Configuration;
using Common.Interfaces;
using Microsoft.Extensions.Options;

namespace Common.Helpers
{
    public class AppSettingsService : IAppSettingsService
    {
        private readonly AppSettingsConfig _config;

        public AppSettingsService(IOptions<AppSettingsConfig> options)
        {
            _config = options.Value;
        }

        public AppSettingsConfig GetConfig() => _config;

        public int AppId => _config.AppId;
        public string AppName => _config.AppName;

        //API values
        public string Auth0_ClientId => _config.Auth0_ClientId;
        public string Auth0_ClientSecret => _config.Auth0_ClientSecret;
        public string Auth0_TokenURL => _config.Auth0_TokenURL;

        ////SafeHarborService values
        //public string SafeHarborService_ClientId => _config.SafeHarborService_ClientId;
        //public string SafeHarborService_ClientSecret => _config.SafeHarborService_ClientSecret;
        //public string SafeHarborService_TokenURL => _config.SafeHarborService_TokenURL;

        ////HighCostService values
        //public string HighCostService_ClientId => _config.HighCostService_ClientId;
        //public string HighCostService_ClientSecret => _config.HighCostService_ClientSecret;
        //public string HighCostService_TokenURL => _config.HighCostService_TokenURL;

        ////PoinAndFeesService values
        //public string PoinAndFeesService_ClientId => _config.PoinAndFeesService_ClientId;
        //public string PoinAndFeesService_ClientSecret => _config.PoinAndFeesService_ClientSecret;
        //public string PoinAndFeesService_TokenURL => _config.PoinAndFeesService_TokenURL;

        ////StateRegulatoryService values
        //public string StateRegulatoryService_ClientId => _config.StateRegulatoryService_ClientId;
        //public string StateRegulatoryService_ClientSecret => _config.StateRegulatoryService_ClientSecret;
        //public string StateRegulatoryService_TokenURL => _config.StateRegulatoryService_TokenURL;
    }
}
