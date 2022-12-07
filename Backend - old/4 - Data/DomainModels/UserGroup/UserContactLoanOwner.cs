using DataLayer.DomainModels.TransactionGroup;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.DomainModels.UserGroup
{
    [Table("UserContactLoanOwner", Schema = "user")]
    public class UserContactLoanOwner : Loan
    {
        public uint UserId { get; set; }
        public User User { get; set; } = null!;
    }
}

