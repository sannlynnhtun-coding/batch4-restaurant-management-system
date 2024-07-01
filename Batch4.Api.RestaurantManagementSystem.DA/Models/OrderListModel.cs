using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.Api.RestaurantManagementSystem.DA.Models;

public class OrderListModel
{
    public OrderModel Order { get; set; }
    public List<OrderDetailModel> Details { get; set; } = new List<OrderDetailModel>();
}
