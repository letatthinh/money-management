using DataLayer.DomainModels.TransactionGroup;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.DomainModels.UserGroup
{
    [Table("UserContactLendingPaymentDetail", Schema = "user")]
    public class UserContactLendingPaymentDetail : LendingPaymentDetail
    {
        public uint UserId { get; set; }
        public User User { get; set; } = null!;
    }
}


