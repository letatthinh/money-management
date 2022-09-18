using DataLayer.DomainModels.TransactionGroup;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.DomainModels.ContactGroup
{
    [Table("CustomContactExpenseDetail", Schema = "contact")]
    public class CustomContactExpenseDetail : ExpenseDetail
    {
        public uint CustomContactId { get; set; }
        public CustomContact CustomContact { get; set; } = null!;
    }
}
