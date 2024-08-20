using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiQuanlikho.Datas
{
    [Table("Order")]
    public class Order
    {

        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public string Address { get; set; }
        public string CustomerPhone { get; set; }
        public int TotalPrice { get; set; }
        public Customer customer { get; set; }
        public Product product { get; set; }    
    }
}
