using Batch4.Api.RestaurantManagementSystem.DA.Models;
using Batch4.Api.RestaurantManagementSystem.DA.Services.MenuItem;
using Batch4.Api.RestaurantManagementSystem.DA.Services.Order;

namespace Batch4.Api.RestaurantManagementSystem.BL.Services.Order
{
    public class BL_Order
    {
        private readonly DA_Order _daOrder;

        public BL_Order(DA_Order daOrder)
        {
            _daOrder = daOrder;
        }

        public int CreateOrder(OrderRequest orderRequest)
        {
            var result = _daOrder.CreateOrder(orderRequest);
            return result;
        }
    }
}
