using DataLayer.DomainModels.Abstracts;
using DataLayer.DomainModels.UserGroup;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.DomainModels.TransactionGroup
{
    [Table("MoneyTransaction", Schema = "moneytransaction")]
    public class MoneyTransaction : BaseModel
    {
        public uint UserMoneyTransactionCategoryId { get; set; }
        public UserMoneyTransactionCategory UserMoneyTransactionCategory { get; set; } = null!;

        [StringLength(100)]
        public string? Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }
    }
}
