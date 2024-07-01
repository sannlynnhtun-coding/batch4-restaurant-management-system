using Batch4.Api.RestaurantManagementSystem.DA.Services.MenuItem;
using Batch4.Api.RestaurantManagementSystem.DA.Services.Order;
using Batch4.Api.RestaurantManagementSystem.DA.ResponseModel;
using Batch4.Api.RestaurantManagementSystem.DA.Models;
using Batch4.Api.RestaurantManagementSystem.BL.Services.MenuItem;
using Batch4.Api.RestaurantManagementSystem.BL.RequestModels.Order;

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

    public async Task<OrderResp> AddOrder(OrderReq orderReq)
    {
        OrderListModel OrderList = new OrderListModel();
        OrderResp response = new OrderResp();

        string invoiceNo = DateTime.Now.ToString("yyyMMddHHmmss");

        foreach (var item in orderReq.orders)
        {
            var menu = await _blMenuItem.GetMenuItemById(item.itemId);
            if (menu == null) throw new InvalidDataException("item not found on the menu!");

            var totalPrice = menu.ItemPrice * item.qty;

            var orderDetail = item.Change(invoiceNo, totalPrice);

            OrderList.Details.Add(orderDetail);
        }

        var total = OrderList.Details.Sum(x => x.TotalPrice);

        OrderList.Order = orderReq.Change(invoiceNo, total);
        int result = await _daOrder.AddOrderList(OrderList);

        if (result > 0)
        {
            response.InvoiceNo = OrderList.Order.InvoiceNo;
            response.TotalPrice = OrderList.Order.TotalPrice;
        }

        return response;
    }
}
