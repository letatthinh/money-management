using DataLayer.DomainModels.Abstracts;
using DataLayer.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.DomainModels.TransactionGroup
{
    [Table("Loan", Schema = "moneytransaction")]
    public class Loan : LoanLendingInvestmentBaseModel
    {
        public float AmountOfMoneyRepaid { get; set; }

        [StringLength(5)]
        public string MoneyRepaidCurrency { get; set; } = null!;

        public ICollection<LoanPaymentDetail>? LoanPaymentDetails { get; set; } = new List<LoanPaymentDetail>();
    }
}
