using Common.Configuration;

namespace Common.Interfaces
{
    public interface IAppSettingsService
    {
        AppSettingsConfig GetConfig();

        int AppId { get; }
        string AppName { get; }
        string Auth0_ClientId { get; }
        string Auth0_ClientSecret { get; }
        // string Auth0_TokenURL { get; }
        //string SafeHarborService_ClientId { get; }
        //string SafeHarborService_ClientSecret { get; }
        //string SafeHarborService_TokenURL { get; }

        //string HighCostService_ClientId { get; }
        //string HighCostService_ClientSecret { get; }
        //string HighCostService_TokenURL { get; }

        //string PoinAndFeesService_ClientId { get; }
        //string PoinAndFeesService_ClientSecret { get; }
        //string PoinAndFeesService_TokenURL { get; }

        //string StateRegulatoryService_ClientId { get; }
        //string StateRegulatoryService_ClientSecret { get; }
        //string StateRegulatoryService_TokenURL { get; }
    }
}
