using DataLayer.DomainModels.TransactionGroup;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.DomainModels.ContactGroup
{
    [Table("CustomContactLoanPaymentDetail", Schema = "contact")]
    public class CustomContactLoanPaymentDetail : LoanPaymentDetail
    {
        public uint CustomContactId { get; set; }
        public CustomContact CustomContact { get; set; } = null!;
    }
}
