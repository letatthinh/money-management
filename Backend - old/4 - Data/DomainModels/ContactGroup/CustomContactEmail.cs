using DataLayer.DomainModels.Abstracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.DomainModels.ContactGroup
{
    [Table("CustomContactEmail", Schema = "contact")]
    public class CustomContactEmail : BaseModel
    {
        public uint CustomContactId { get; set; }
        public CustomContact CustomContact { get; set; } = null!;

        [StringLength(320)]
        public string Email { get; set; } = null!;
    }
}
