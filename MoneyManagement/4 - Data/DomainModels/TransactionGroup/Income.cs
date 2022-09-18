using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.DomainModels.TransactionGroup
{
    [Table("Income", Schema = "moneytransaction")]
    public class Income : MoneyTransaction
    {
        public DateTime DateTime { get; set; }

        public ICollection<IncomeDetail> IncomeDetails { get; set; } = new List<IncomeDetail>();
    }
}
