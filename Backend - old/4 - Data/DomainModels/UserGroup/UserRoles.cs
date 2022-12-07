using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.DomainModels.UserGroup
{
    [Table("UserRoles", Schema = "user")]
    public class UserRoles
    {
        public UserRoles()
        {
            User = null!;
            Role = null!;
        }

        public uint UserId { get; set; }
        public User User { get; set; }

        public uint RoleId { get; set; }
        public Role Role { get; set; }
    }
}
