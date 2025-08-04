namespace Common.Configuration
{
    public class AppSettingsConfig
    {
        public int AppId { get;  set; }
        public string AppName { get;  set; }
        public string Auth0_ClientId { get;  set; }
        public string Auth0_ClientSecret { get;  set; }
        public string Auth0_TokenURL { get;  set; }

        public string SafeHarborService_ClientId { get;  set; }
        public string SafeHarborService_ClientSecret { get;  set; }
        public string SafeHarborService_TokenURL { get;  set; }

        public string HighCostService_ClientId { get;  set; }
        public string HighCostService_ClientSecret { get;  set; }
        public string HighCostService_TokenURL { get;  set; }

        public string PoinAndFeesService_ClientId { get;  set; }
        public string PoinAndFeesService_ClientSecret { get;  set; }
        public string PoinAndFeesService_TokenURL { get;  set; }

        public string StateRegulatoryService_ClientId { get;  set; }
        public string StateRegulatoryService_ClientSecret { get;  set; }
        public string StateRegulatoryService_TokenURL { get;  set; }
    }
}
