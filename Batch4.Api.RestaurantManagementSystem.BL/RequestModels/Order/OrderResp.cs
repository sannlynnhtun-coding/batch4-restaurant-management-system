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