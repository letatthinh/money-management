using DataLayer.DomainModels.TransactionGroup;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.DomainModels.UserGroup
{
    [Table("UserContactInvestment", Schema = "user")]
    public class UserContactInvestment : Investment
    {
        public uint UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
