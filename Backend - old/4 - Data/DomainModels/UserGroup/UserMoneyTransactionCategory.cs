using DataLayer.DomainModels.Abstracts;
using DataLayer.DomainModels.TransactionGroup;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.DomainModels.UserGroup
{
    [Table("UserMoneyTransactionCategory", Schema = "user")]
    public class UserMoneyTransactionCategory : BaseModel
    {
        public uint UserId { get; set; }
        public User User { get; set; } = null!;

        [StringLength(40)]
        public string Name { get; set; } = null!;

        public ICollection<MoneyTransaction>? MoneyTransactions { get; set; } = new List<MoneyTransaction>();        
    }
}
