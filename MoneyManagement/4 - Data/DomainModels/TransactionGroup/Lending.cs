using DataLayer.DomainModels.Abstracts;
using DataLayer.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.DomainModels.TransactionGroup
{
    [Table("Lending", Schema = "moneytransaction")]
    public class Lending : LoanLendingInvestmentBaseModel
    {
        public float AmountOfMoneyReturned { get; set; }

        [StringLength(5)]
        public string MoneyReturnedCurrency { get; set; } = null!;

        public ICollection<LendingPaymentDetail>? LendingPaymentDetails { get; set; } = new List<LendingPaymentDetail>();
    }
}
