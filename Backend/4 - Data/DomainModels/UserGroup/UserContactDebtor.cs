using DataLayer.DomainModels.TransactionGroup;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.DomainModels.UserGroup
{
    [Table("UserContactDebtor", Schema = "user")]
    public class UserContactDebtor : Lending
    {
        public uint UserId { get; set; }
        public User User { get; set; } = null!;
    }
}

