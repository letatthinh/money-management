using DataLayer.DomainModels.Abstracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.DomainModels.UserGroup
{
    [Table("Role", Schema = "user")]
    public class Role : BaseModel
    {
        [Required]
        [StringLength(40)]
        public string Name { get; set; } = null!;

        [StringLength(500)]
        public string? Description { get; set; }

        public ICollection<UserRoles> UserRoles { get; set; } = new List<UserRoles>();
    }
}
