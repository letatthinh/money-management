using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.DomainModels.UserGroup
{
    [Table("UserContacts", Schema = "user")]
    public class UserContacts
    {
        public uint UserId { get; set; }
        public User User { get; set; } = null!;

        public uint ContactId { get; set; }
        public User Contact { get; set; } = null!;

        [StringLength(70)]
        public string? DisplayName { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }
    }
}