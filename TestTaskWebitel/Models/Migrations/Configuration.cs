namespace TestTaskWebitel.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TestTaskWebitel.Models.Domain;

    internal sealed class Configuration : DbMigrationsConfiguration<TestTaskWebitel.Models.ShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            //MigrationsNamespace = "TestTaskWebitel.Models.Migrations";
            MigrationsDirectory = "Models\\Migrations";
        }

        protected override void Seed(TestTaskWebitel.Models.ShopDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var products = new Dictionary<String, Product>
            {
                {"Redmi Note 5", new Product{Name = "Redmi Note 5", Price = 400} },
                {"iPhone 7", new Product{Name = "iPhone 7", Price = 520} },
                {"Lenovo 5300", new Product{Name = "Lenovo 5300", Price = 290} },
                {"Lenovo 5450", new Product{Name = "Lenovo 5450", Price = 150} }
            };

            foreach (var product in products.Values)
            {
                context.Products.AddOrUpdate(p => p.Id, product);
            }
            context.SaveChanges();

            var orders = new List<Order>
            {
                new Order
                {
                    Number = "3219cedw1",
                    Amount = 1,
                    ProductOrders = new Collection<ProductOrder>
                    {
                        new ProductOrder
                        {
                            ProductId = context.Products.First(p => p.Name == "Redmi Note 5").Id
                        }
                    }
                },
                new Order
                {
                    Number = "3329cedw1",
                    Amount = 1,
                    ProductOrders = new Collection<ProductOrder>
                    {
                        new ProductOrder
                        {
                            ProductId = context.Products.First(p => p.Name == "iPhone 7").Id
                        }
                    }
                },
                new Order
                {
                    Number = "3549cedw1",
                    Amount = 2,
                    ProductOrders = new Collection<ProductOrder>
                    {
                        new ProductOrder
                        {
                            ProductId = context.Products.First(p => p.Name == "Lenovo 5300").Id
                        },
                        new ProductOrder
                        {
                            ProductId = context.Products.First(p => p.Name == "Lenovo 5450").Id
                        }
                    }
                }
            };

            foreach (var order in orders)
            {
                context.Orders.AddOrUpdate(order);
            }
        }
    }

    //public class ShopDbInitializer : DropCreateDatabaseAlways<ShopDbContext>
    //{
    //    protected override void Seed(ShopDbContext context)
    //    {
            

    //        base.Seed(context);
    //    }
    //}
}
