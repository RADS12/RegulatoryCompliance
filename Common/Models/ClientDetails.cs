using Common.Interfaces;

namespace Common.Models
{
    public class ClientDetails : EntityAuditHistory
    {
        private int ClientId { get; set; }
        private int LoanNumber { get; set; }
         public required string FirstName { get; set; }
         public required string LastName { get; set; }
         public required string AddressLine1 { get; set; }
         public required string AddressLine2 { get; set; }
         public required string City { get; set; }
         public required string ZipCode { get; set; }
    }
}
