using System.ComponentModel.DataAnnotations;

namespace ApiQuanlikho.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        [MaxLength(12)]
        public string Sdt { get; set; }
    }
}
