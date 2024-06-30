using Batch4.Api.RestaurantManagementSystem.BL.Services.MenuItem;
using Batch4.Api.RestaurantManagementSystem.BL.Services.Order;
using Batch4.Api.RestaurantManagementSystem.DA.Models;
using Microsoft.AspNetCore.Mvc;

namespace Batch4.Api.RestaurantManagementSystem.Controllers.Order
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly BL_Order _blOrder;

        public OrderController(BL_Order blOrder)
        {
            _blOrder = blOrder;
        }

        [HttpPost]
        public IActionResult Create(OrderRequest orderRequest)
        {
            var result = _blOrder.CreateOrder(orderRequest);
            string message = result > 0 ? "Order placed successful." : "Order placed Fail.";
            return Ok(message);
        }
    }
}
