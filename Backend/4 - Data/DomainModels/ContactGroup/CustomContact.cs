using DataLayer.DomainModels.Abstracts;
using DataLayer.DomainModels.UserGroup;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.DomainModels.ContactGroup
{
    [Table("CustomContact", Schema = "contact")]
    public class CustomContact : BaseModel
    {
        public uint UserId { get; set; }
        public User User { get; set; } = null!;

        [StringLength(100)]
        public string? DisplayName { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public ICollection<CustomContactEmail>? CustomContactEmails { get; set; } = new List<CustomContactEmail>();

        public ICollection<CustomContactIncomeDetail>? CustomContactIncomeDetails { get; set; } = new List<CustomContactIncomeDetail>();

        public ICollection<CustomContactExpenseDetail>? CustomContactExpenseDetails { get; set; } = new List<CustomContactExpenseDetail>();

        public ICollection<CustomContactLoanOwner>? CustomContactLoanOwners { get; set; } = new List<CustomContactLoanOwner>();

        public ICollection<CustomContactLoanPaymentDetail>? CustomContactLoanPaymentDetails { get; set; } = new List<CustomContactLoanPaymentDetail>();

        public ICollection<CustomContactDebtor>? CustomContactDebtors { get; set; } = new List<CustomContactDebtor>();

        public ICollection<CustomContactLendingPaymentDetail>? CustomContactLendingPaymentDetails { get; set; } = new List<CustomContactLendingPaymentDetail>();

        public ICollection<CustomContactInvestment>? CustomContactInvestments { get; set; } = new List<CustomContactInvestment>();
    }
}