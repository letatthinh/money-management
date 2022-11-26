using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.DomainModels.ContactGroup
{
    [Table("Place", Schema = "contact")]
    public class Place : CustomContact
    {
    }
}
