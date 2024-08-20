

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ApiQuanlikho.Datas
{
    public class SaleDataContext : IdentityDbContext<ApplicationUser>
    {
        public SaleDataContext(DbContextOptions<SaleDataContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
       // DbSet<T> cung cấp các phương thức để thao tác dữ liệu như FirstOrDefault, Add, Remove, Update,...
       // Những phương thức này giúp chúng ta thao tác với dữ liệu trong bảng tương ứng.
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // điều mà tôi tìm kiếm bây lâu nay, k thêm chỗ này bị lỗi dưới đây
            //Unable to create a 'DbContext' of type ''. The exception 'The entity type 'IdentityUserLogin<string>'
            //requires a primary key to be defined. If you intended to use a keyless entity type, call 'HasNoKey'
            //in 'OnModelCreating'. For more information on keyless entity types,
            //see https://go.microsoft.com/fwlink/?linkid=2141943.' was thrown while attempting to create an
            //instance. For the different patterns supported at design time,
            //see https://go.microsoft.com/fwlink/?linkid=851728
            builder.Entity<Order>(e =>
            {
                e.ToTable("Order");
                e.HasKey(o => o.Id);
                e.HasOne(e => e.product)
                    .WithMany(e => e.Orders)
                    .HasForeignKey(e => e.ProductId);
                e.HasOne(e => e.customer)
                    .WithMany(e => e.Orders)
                    .HasForeignKey(e => e.CustomerId);
            });
        }
    }
}
