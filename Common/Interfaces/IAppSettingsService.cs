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

        //string PointAndFeesService_ClientId { get; }
        //string PointAndFeesService_ClientSecret { get; }
        //string PointAndFeesService_TokenURL { get; }

        //string StateRegulatoryService_ClientId { get; }
        //string StateRegulatoryService_ClientSecret { get; }
        //string StateRegulatoryService_TokenURL { get; }
    }
}
