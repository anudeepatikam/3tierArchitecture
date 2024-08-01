using System.ComponentModel.DataAnnotations;

namespace EMS.PresentationLayer.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string ?Name { get; set; }
        public string ? Address { get; set; }

        public int Age { get; set; }

        public string ? Email { get; set; }

    }
}
