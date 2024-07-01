using Batch4.Api.RestaurantManagementSystem.BL.Services.MenuItem;
using Batch4.Api.RestaurantManagementSystem.BL.Services.Order;
using Batch4.Api.RestaurantManagementSystem.DA.ResponseModel;
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
        public async Task<IActionResult> Create(OrderRequest orderRequest)
        {
            var model =await _blOrder.CreateOrder(orderRequest);
            if (model.InvoiceNo == null) return Ok("Order Creation Fail."); 
            return Ok(model);
        }

        [HttpGet("invoiceNo")]
        public async Task<IActionResult> ViewOrder(string invoiceNo)
        {
            var model = await _blOrder.ViewOrder(invoiceNo);
            if (model.InvoiceNo == null) return Ok("No order found.");
            return Ok(model);
        }

        [HttpGet]
        public async Task<IActionResult> ViewOrders()
        {
            var model = await _blOrder.ViewOrders();
            return Ok(model);
        }
    }
}
