using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TestTaskWebitel.Models.Domain;

namespace TestTaskWebitel.Models.EntityConfigurations
{
    public class ProductOrderConfiguration : EntityTypeConfiguration<ProductOrder>
    {
        public ProductOrderConfiguration()
        {
            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}