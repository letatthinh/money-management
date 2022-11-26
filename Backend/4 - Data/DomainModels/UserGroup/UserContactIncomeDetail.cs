using DataLayer.DomainModels.TransactionGroup;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.DomainModels.UserGroup
{
    [Table("UserContactIncomeDetail", Schema = "user")]
    public class UserContactIncomeDetail : IncomeDetail
    {
        public uint UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
