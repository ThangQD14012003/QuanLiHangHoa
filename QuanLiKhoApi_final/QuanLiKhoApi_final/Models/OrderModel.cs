using ApiQuanlikho.Datas;
using System.ComponentModel.DataAnnotations;

namespace ApiQuanlikho.Models
{
    public class OrderModel
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public string Address { get; set; }
        public string CustomerPhone { get; set; }
        public int TotalPrice { get; set; }
        
    }
}
