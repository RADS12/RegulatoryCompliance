using Common.Interfaces;

namespace Common.Models
{
    public class ClientDetails : EntityAuditHistory
    {
        private int ClientId { get; set; }
        private int LoanNumber { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string AddressLine1 { get; set; }
        private string AddressLine2 { get; set; }
        private string City { get; set; }
        private string ZipCode { get; set; }
    }
}
