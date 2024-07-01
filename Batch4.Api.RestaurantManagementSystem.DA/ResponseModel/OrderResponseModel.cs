using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.Api.RestaurantManagementSystem.DA.ResponseModel;

public class OrderResponseModel
{
    public string? InvoiceNo { get; set; }
    public decimal TotalPrice { get; set; }
}

public class OrderDetailResponseModel : OrderResponseModel
{
    public List<OrderItemDetailModel> Items { get; set; }
}
