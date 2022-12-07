using DataLayer.DomainModels.Abstracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.DomainModels.TransactionGroup
{
    [Table("LoanPaymentDetail", Schema = "moneytransaction")]
    public class LoanPaymentDetail : BaseModel
    {
        public uint LoanId { get; set; }
        public Loan Loan { get; set; } = null!;

        public DateTime DateTime { get; set; }

        public float AmountOfMoney { get; set; }

        [StringLength(5)]
        public string MoneyCurrency { get; set; } = null!;

        public float? AmountOfExchangedMoney { get; set; }

        [StringLength(5)]
        public string? ExchangedMoneyCurrency { get; set; }

        public float? ExchangeRate { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }
    }
}
