using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TestTaskWebitel.Models.Domain;

namespace TestTaskWebitel.Models.EntityConfigurations
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            ToTable("Product");

            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            Property(p => p.Price)
                .HasPrecision(18, 0);

            HasMany(p => p.ProductOrders)
                .WithRequired(po => po.Product)
                .HasForeignKey(po => po.ProductId);
        }
    }
}