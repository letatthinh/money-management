using DataLayer.DomainModels.TransactionGroup;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.DomainModels.ContactGroup
{
    [Table("CustomContactLendingPaymentDetail", Schema = "contact")]
    public class CustomContactLendingPaymentDetail : LendingPaymentDetail
    {
        public uint CustomContactId { get; set; }
        public CustomContact CustomContact { get; set; } = null!;
    }
}

