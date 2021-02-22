using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TestTaskWebitel.Models.Domain;

namespace TestTaskWebitel.Models.EntityConfigurations
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            ToTable("Product");

            Property(product => product.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(product => product.Name)
                .IsRequired()
                .HasMaxLength(50);

            Property(product => product.Price)
                .HasPrecision(18, 0);

            HasMany(product => product.ProductOrders)
                .WithRequired(productOrder => productOrder.Product)
                .HasForeignKey(productOrder => productOrder.ProductId);

            //HasMany(product => product.Orders)
            //    .WithMany(order => order.Products)
            //    .Map(map =>
            //    {
            //        map.ToTable("ProductOrder");
            //        map.MapLeftKey("ProductId");
            //        map.MapRightKey("OrderId");
            //    });
        }
    }
}