using DataLayer.DomainModels.TransactionGroup;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.DomainModels.ContactGroup
{
    [Table("CustomContactLoanOwner", Schema = "contact")]
    public class CustomContactLoanOwner : Loan
    {
        public uint CustomContactId { get; set; }
        public CustomContact CustomContact { get; set; } = null!;
    }
}
