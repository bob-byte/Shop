namespace TestTaskWebitel.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using TestTaskWebitel.Models.Domain;
    using TestTaskWebitel.Models.EntityConfigurations;

    public class ShopDbContext : DbContext
    {
        // Контекст настроен для использования строки подключения "ShopDbContext" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "TestTaskWebitel.Models.ShopDbContext" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "ShopDbContext" 
        // в файле конфигурации приложения.
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
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}