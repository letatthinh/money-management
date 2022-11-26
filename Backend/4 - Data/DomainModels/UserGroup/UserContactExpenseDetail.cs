using DataLayer.DomainModels.TransactionGroup;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.DomainModels.UserGroup
{
    [Table("UserContactExpenseDetail", Schema = "user")]
    public class UserContactExpenseDetail : ExpenseDetail
    {
        public uint UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
