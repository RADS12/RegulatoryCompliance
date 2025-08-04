using Common.Interfaces;

namespace Common.Models
{
    public class EntityAuditHistory
    {
        private static readonly IAppSettingsService _appSettingsService;

        //public EntityAuditHistory(IAppSettingsService appSettingsService)
        //{
        //    _appSettingsService = appSettingsService;
        //}

        public int CreatedById { get; set; } = _appSettingsService.AppId;
        public int UpdatedById { get; set; } = _appSettingsService.AppId;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; } = null;
    }
}
