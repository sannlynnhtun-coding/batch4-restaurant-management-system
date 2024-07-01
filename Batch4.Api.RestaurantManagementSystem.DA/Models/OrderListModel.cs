namespace Batch4.Api.RestaurantManagementSystem.DA.Models;

public class OrderListModel
{
    public OrderModel Order { get; set; }
    public List<OrderDetailModel> Details { get; set; } = new List<OrderDetailModel>();
}
