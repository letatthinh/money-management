using DataLayer.DomainModels.Abstracts;
using DataLayer.DomainModels.UserGroup;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.DomainModels.TransactionGroup
{
    [Table("Investment", Schema = "moneytransaction")]
    public class Investment : LoanLendingInvestmentBaseModel
    {
        public uint UserInvestmentCategoryId { get; set; }
        public UserInvestmentCategory UserInvestmentCategory { get; set; } = null!;

        public float AmountOfMoneyEarned { get; set; }

        [StringLength(5)]
        public string MoneyEarnedCurrency { get; set; } = null!;

        public float? AmountOfExchangedMoneyEarned { get; set; }

        [StringLength(5)]
        public string? ExchangedMoneyEarnedCurrency { get; set; }

        public float? ExchangeRateOfMoneyEarned { get; set; }
    }
}
