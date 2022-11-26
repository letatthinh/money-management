using DataLayer.DomainModels.Abstracts;
using DataLayer.DomainModels.TransactionGroup;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.DomainModels.UserGroup
{
    [Table("UserInvestmentCategory", Schema = "user")]
    public class UserInvestmentCategory : BaseModel
    {
        public uint UserId { get; set; }
        public User User { get; set; } = null!;

        [StringLength(40)]
        public string Name { get; set; } = null!;

        [StringLength(500)]
        public string? Description { get; set; }

        public ICollection<Investment>? Investments { get; set; } = new List<Investment>();        
    }
}

