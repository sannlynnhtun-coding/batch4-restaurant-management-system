using Batch4.Api.RestaurantManagementSystem.DA.Services.MenuItem;
using Batch4.Api.RestaurantManagementSystem.DA.Services.Order;
using Batch4.Api.RestaurantManagementSystem.DA.ResponseModel;

namespace Batch4.Api.RestaurantManagementSystem.BL.Services.Order
{
    public class BL_Order
    {
        private readonly DA_Order _daOrder;

        public BL_Order(DA_Order daOrder)
        {
            _daOrder = daOrder;
        }

        public async Task<OrderResponseModel> CreateOrder(OrderRequest orderRequest)
        {
            var model = await _daOrder.CreateOrder(orderRequest);
            return model;
        }

    }
}
