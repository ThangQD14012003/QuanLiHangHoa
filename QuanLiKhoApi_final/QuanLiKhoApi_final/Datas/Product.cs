using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiQuanlikho.Datas
{   
    public class Product
    {
        
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public int Price { get; set; }

        public string image {  get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
