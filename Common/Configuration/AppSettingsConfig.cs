namespace Common.Configuration
{
    public class AppSettingsConfig
    {
        public int AppId { get;  set; }
        public required string AppName { get;  set; }
        public required string Auth0_ClientId { get;  set; }
        public required string Auth0_ClientSecret { get;  set; }
        public required string Auth0_TokenURL { get;  set; }

        public required string SafeHarborService_ClientId { get;  set; }
        public required string stringSafeHarborService_ClientSecret { get;  set; }
        public required string stringSafeHarborService_TokenURL { get;  set; }

        public required string stringHighCostService_ClientId { get;  set; }
        public required string HighCostService_ClientSecret { get;  set; }
        public required string HighCostService_TokenURL { get;  set; }

        public required string PoinAndFeesService_ClientId { get;  set; }
        public required string PoinAndFeesService_ClientSecret { get;  set; }
        public required string PoinAndFeesService_TokenURL { get;  set; }

        public required string SateRegulatoryService_ClientId { get;  set; }
        public required string StateRegulatoryService_ClientSecret { get;  set; }
        public required string StateRegulatoryService_TokenURL { get;  set; }
    }
}
