using DataLayer.DomainModels.TransactionGroup;
using DataLayer.Enums;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.DomainModels.Abstracts
{
    public abstract class LoanLendingInvestmentBaseModel : MoneyTransaction
    {
        public DateTime StartDateTime { get; set; }

        public float AmountOfMoney { get; set; }

        [StringLength(5)]
        public string MoneyCurrency { get; set; } = null!;

        public float? AmountOfExchangedMoney { get; set; }

        [StringLength(5)]
        public string? ExchangedMoneyCurrency { get; set; }

        public float? ExchangeRate { get; set; }

        public DateTime EndDateTime { get; set; }

        public float InterestRate { get; set; }

        public InterestType InterestType { get; set; }
    }
}
