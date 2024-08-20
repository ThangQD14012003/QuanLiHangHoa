using System.ComponentModel.DataAnnotations;

namespace ApiQuanlikho.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public int Price { get; set; }
        [Required]
        public IFormFile image { get; set; }
        // IFromFile: truong de nhan hinh anh
    }
}
