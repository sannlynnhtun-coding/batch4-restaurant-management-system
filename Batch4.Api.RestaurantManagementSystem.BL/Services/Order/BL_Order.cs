using Batch4.Api.RestaurantManagementSystem.Shared;

namespace Batch4.Api.RestaurantManagementSystem.BL.Services.Order;

public class BL_Order
{
    private readonly DA_Order _daOrder;
    private readonly BL_MenuItem _blMenuItem;

    public BL_Order(DA_Order daOrder, BL_MenuItem blMenuItem)
    {
        _daOrder = daOrder;
        _blMenuItem = blMenuItem;
    }

    public async Task<OrderResponseModel> CreateOrder(OrderRequest orderRequest)
    {
        var model = await _daOrder.CreateOrder(orderRequest);
        return model;
    }

    public async Task<OrderDetailResponseModel> ViewOrder(string invoiceNo)
    {
        var model = await _daOrder.ViewOrder(invoiceNo);
        return model;
    }

    public async Task<List<OrderModel>> ViewOrders()
    {
        return await _daOrder.ViewOrders();
    }
}
