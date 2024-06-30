namespace Batch4.Api.RestaurantManagementSystem.DA.ResponseModel;

public class OrderItemDetailModel
{
    public int ItemId { get; set; }
    public string ItemName { get; set; }
    public decimal ItemPrice { get; set; }
    public int Quantity { get; set; }
}
