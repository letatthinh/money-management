using DataLayer.DomainModels.TransactionGroup;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.DomainModels.UserGroup
{
    [Table("UserContactLoanPaymentDetail", Schema = "user")]
    public class UserContactLoanPaymentDetail : LoanPaymentDetail
    {
        public uint UserId { get; set; }
        public User User { get; set; } = null!;
    }
}

