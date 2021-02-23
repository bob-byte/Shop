using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TestTaskWebitel.Models.Domain;

namespace TestTaskWebitel.Models.EntityConfigurations
{
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            ToTable("Order");

            Property(o => o.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(o => o.Number)
                .IsRequired()
                .HasMaxLength(50);

            Property(o => o.Amount)
                .HasPrecision(18, 0);

            HasMany(o => o.ProductOrders)
                .WithRequired(o => o.Order)
                .HasForeignKey(po => po.OrderId);
        }
    }
}