using DataLayer.DomainModels.Abstracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.DomainModels.TransactionGroup
{
    [Table("LendingPaymentDetail", Schema = "moneytransaction")]
    public class LendingPaymentDetail : BaseModel
    {
        public uint LendingId { get; set; }
        public Lending Lending { get; set; } = null!;

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

