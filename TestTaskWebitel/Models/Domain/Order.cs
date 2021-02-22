using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace TestTaskWebitel.Models.Domain
{
    public class Order
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