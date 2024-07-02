namespace Batch4.Api.RestaurantManagementSystem.Shared;

public class OrderResponseModel
{
    public string? InvoiceNo { get; set; }
    public decimal TotalPrice { get; set; }
}

public class OrderDetailResponseModel : OrderResponseModel
{
    public List<OrderItemDetailModel> Items { get; set; }
}
