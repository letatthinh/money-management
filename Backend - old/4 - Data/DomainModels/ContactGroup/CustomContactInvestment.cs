using DataLayer.DomainModels.TransactionGroup;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.DomainModels.ContactGroup
{
    [Table("CustomContactInvestment", Schema = "contact")]
    public class CustomContactInvestment : Investment
    {
        public uint CustomContactId { get; set; }
        public CustomContact CustomContact { get; set; } = null!;
    }
}

