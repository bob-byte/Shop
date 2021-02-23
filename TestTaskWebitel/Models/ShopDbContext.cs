using System.Data.Entity;
using TestTaskWebitel.Models.Domain;
using TestTaskWebitel.Models.EntityConfigurations;

namespace TestTaskWebitel.Models
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext()
            : base("name=ShopDbContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<ProductOrder> ProductOrders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new ProductOrderConfiguration());
        }
    }
}