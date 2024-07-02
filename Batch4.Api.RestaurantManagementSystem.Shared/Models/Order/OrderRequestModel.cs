namespace Batch4.Api.RestaurantManagementSystem.Shared;

public class OrderRequestModel
{
    public List<OrderItem> Items { get; set; }
}

public class OrderItem
{
    public int ItemId { get; set; }

    public int Quantity { get; set; }
}
