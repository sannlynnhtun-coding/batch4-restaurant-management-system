using System;
namespace Batch4.Api.RestaurantManagementSystem.DA.ResponseModel;

public class OrderRequest
{
    public List<OrderItem> Items { get; set; }
}

public class OrderItem
{
    public int ItemId { get; set; }

    public int Quantity { get; set; }
}
