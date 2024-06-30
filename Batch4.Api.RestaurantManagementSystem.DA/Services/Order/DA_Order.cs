using Batch4.Api.RestaurantManagementSystem.DA.Db;
using Batch4.Api.RestaurantManagementSystem.DA.Models;
namespace Batch4.Api.RestaurantManagementSystem.DA.Services.Order
{
    public class DA_Order
    {
        private readonly AppDbContext _db;

        public DA_Order(AppDbContext db)
        {
            _db = db;
        }
        public int CreateOrder(OrderRequest orderRequest)
        {
            var invoiceNo = DateTime.Now.ToString("yyyMMddHHmmss");

            List<OrderItemDetailModel> orderDetail = orderRequest.Items.Select(x => new OrderItemDetailModel
            {
                ItemId = x.ItemId,
                ItemName = _db.MenuItem.FirstOrDefault(y => y.ItemId == x.ItemId).ItemName,
                ItemPrice = (decimal)_db.MenuItem.FirstOrDefault(y => y.ItemId == x.ItemId).ItemPrice,
                Quantity = x.Quantity
            }).ToList();


            OrderModel order = new OrderModel()
            {
                InvoiceNo = invoiceNo,
                TotalPrice = orderDetail.Sum(x => x.Quantity * x.ItemPrice)
            };

            List<OrderDetailModel> orderDetailLst = orderDetail.Select(x => new OrderDetailModel
            {
                InvoiceNo = invoiceNo,
                ItemId = x.ItemId,
                Quantity = x.Quantity,
                TotalPrice = x.ItemPrice * x.Quantity
            }).ToList();

            _db.OrderDetails.AddRange(orderDetailLst);
            _db.Orders.Add(order);
            int result = _db.SaveChanges();
            return result;
        }
    }
}
