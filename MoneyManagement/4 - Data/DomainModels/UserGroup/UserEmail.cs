using DataLayer.DomainModels.Abstracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.DomainModels.UserGroup
{
    [Table("UserEmail", Schema = "user")]
    public class UserEmail : BaseModel
    {
        public uint UserId { get; set; }
        public User User { get; set; } = null!;

        [StringLength(320)]
        public string Email { get; set; } = null!;
    }
}
