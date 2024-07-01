namespace Batch4.Api.RestaurantManagementSystem.DA.Services.Order;

public class DA_Order
{
    private readonly AppDbContext _db;
    private readonly DapperService _dapper;

    public DA_Order(AppDbContext db,DapperService dapper)
    {
        _db = db;
        _dapper = dapper;
    }

    public async Task<OrderResponseModel> CreateOrder(OrderRequest orderRequest)
    {
        OrderResponseModel model = new OrderResponseModel();
        List<OrderDetailModel> orderDetailLst = new List<OrderDetailModel>();
        decimal totalPrice = 0;
        var invoiceNo = DateTime.Now.ToString("yyyMMddHHmmss");

        foreach (var item in orderRequest.Items)
        {
            OrderDetailModel detailModel = new OrderDetailModel();
            var menu = await _db.MenuItem.FirstOrDefaultAsync(x => x.ItemId == item.ItemId);
            if (menu is not null)
            {
                detailModel.ItemId = menu.ItemId;
                detailModel.Quantity = item.Quantity;
                detailModel.InvoiceNo = invoiceNo;
                detailModel.TotalPrice = item.Quantity * menu.ItemPrice;
            }
            orderDetailLst.Add(detailModel);
        }

        if (orderDetailLst.Count == 0) return model;
        totalPrice = orderDetailLst.Sum(x => x.TotalPrice);
        OrderModel order = new OrderModel()
        {
            InvoiceNo = invoiceNo,
            TotalPrice = totalPrice
        };

        await _db.Orders.AddAsync(order);
        await _db.OrderDetails.AddRangeAsync(orderDetailLst);
        int result =await _db.SaveChangesAsync();
        if (result > 0)
        {
            model.InvoiceNo = invoiceNo;
            model.TotalPrice = totalPrice;
        }
        return model;
    }

    public async Task<OrderDetailResponseModel> ViewOrder(string invoiceNo)
    {
        OrderDetailResponseModel model = new OrderDetailResponseModel();    
        var order = await _db.Orders.FirstOrDefaultAsync(x=>x.InvoiceNo == invoiceNo);
        if(order == null) return model;
        model.InvoiceNo = order.InvoiceNo;
        model.TotalPrice = order.TotalPrice;

        var orderDetail = _dapper.Query<OrderItemDetailModel>(OrderQuery.OrderDetailQuery, new { InvoiceNo = invoiceNo });
        model.Items = orderDetail;
        return model;
    }

    public async Task<List<OrderModel>> ViewOrders()
    {
        List<OrderModel> list = await _db.Orders.ToListAsync();
        return list;
    }

    public async Task<int> AddOrderList(OrderListModel model)
    {
        await _db.Orders.AddAsync(model.Order);
        await _db.OrderDetails.AddRangeAsync(model.Details);

        int result = await _db.SaveChangesAsync();
        return result;
    }
}
