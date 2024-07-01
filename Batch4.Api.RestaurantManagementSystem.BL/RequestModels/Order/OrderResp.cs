using Batch4.Api.RestaurantManagementSystem.DA.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.Api.RestaurantManagementSystem.BL.RequestModels.Order;

public class OrderResp
{
    public string? InvoiceNo { get; set; }
    public decimal TotalPrice { get; set; }
}

public class OrderDetailResp : OrderResp
{
    public List<OrderItemDetailModel> Items { get; set; }
}