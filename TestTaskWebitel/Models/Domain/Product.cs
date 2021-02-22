using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace TestTaskWebitel.Models.Domain
{
    public class Product
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