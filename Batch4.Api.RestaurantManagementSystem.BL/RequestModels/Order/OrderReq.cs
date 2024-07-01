namespace Batch4.Api.RestaurantManagementSystem.BL.RequestModels.Order;

public class OrderReq
{
    public List<Order> orders { get; set; }

    public OrderModel Change(string invoiceNo,decimal total)
    {
        return new OrderModel
        {
            InvoiceNo = invoiceNo,
            TotalPrice = total
        };
    }
}

public record Order(int itemId, int qty)
{
    public OrderDetailModel Change(string invoiceNo, decimal total)
    {
        return new OrderDetailModel
        {
            InvoiceNo = invoiceNo,
            ItemId = itemId,
            Quantity = qty,
            TotalPrice = total
        };
    }
};