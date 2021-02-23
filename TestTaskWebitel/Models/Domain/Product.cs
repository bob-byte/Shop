using System;
using System.Collections.Generic;

namespace TestTaskWebitel.Models.Domain
{
    public class Product : Shop
    {
        public Product()
        {
            ProductOrders = new HashSet<ProductOrder>();
        }

        public Guid Id { get; set; }
        public ICollection<ProductOrder> ProductOrders { get; set; }
        public String Name { get; set; }
        public Decimal Price { get; set; }
    }
}