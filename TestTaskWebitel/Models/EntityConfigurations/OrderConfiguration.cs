using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TestTaskWebitel.Models.Domain;

namespace TestTaskWebitel.Models.EntityConfigurations
{
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            ToTable("Order");

            Property(order => order.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(order => order.Number)
                .IsRequired()
                .HasMaxLength(50);

            Property(order => order.Amount)
                .HasPrecision(18, 0);

            HasMany(order => order.ProductOrders)
                .WithRequired(productOrder => productOrder.Order)
                .HasForeignKey(productOrder => productOrder.OrderId);
        }
    }
}