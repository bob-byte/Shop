using System;
using System.Collections.Generic;

namespace TestTaskWebitel.Models.Domain
{
    public class Order : Shop
    {
        public Order()
        {
            ProductOrders = new HashSet<ProductOrder>();
        }

        public Guid Id { get; set; }
        public ICollection<ProductOrder> ProductOrders { get; set; }
        public String Number { get; set; }
        public Decimal Amount { get; set; }
    }
}