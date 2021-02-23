using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTaskWebitel.Models.Domain
{
    public interface Shop
    {
        ICollection<ProductOrder> ProductOrders { get; set; }
    }
}