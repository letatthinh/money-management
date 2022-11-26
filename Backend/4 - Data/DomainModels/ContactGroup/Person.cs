using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.DomainModels.ContactGroup
{
    [Table("Person", Schema = "contact")]
    public class Person : CustomContact
    {
        [StringLength(20)]
        public string FirstName { get; set; } = null!;

        [StringLength(20)]
        public string? MiddleName { get; set; }

        [StringLength(20)]
        public string LastName { get; set; } = null!;

        public DateOnly? Birthday { get; set; }
    }
}
