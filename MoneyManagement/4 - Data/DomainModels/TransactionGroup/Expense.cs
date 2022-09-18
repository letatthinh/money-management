using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.DomainModels.TransactionGroup
{
    [Table("Expense", Schema = "moneytransaction")]
    public class Expense : MoneyTransaction
    {
        public DateTime DateTime { get; set; }

        public ICollection<ExpenseDetail> ExpenseDetails { get; set; } = new List<ExpenseDetail>();
    }
}
