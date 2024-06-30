using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.Api.RestaurantManagementSystem.DA.Models
{
    public class OrderRequest
    {
        public OrderItem[] Items { get; set; }
    }

    public class OrderItem
    {
        public int ItemId { get; set; }

        public int Quantity { get; set; }
    }
}
