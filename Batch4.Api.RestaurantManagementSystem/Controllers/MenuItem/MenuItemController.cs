using Batch4.Api.RestaurantManagementSystem.BL.Services.Category;
using Batch4.Api.RestaurantManagementSystem.BL.Services.MenuItem;
using Batch4.Api.RestaurantManagementSystem.DA.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace Batch4.Api.RestaurantManagementSystem.Controllers.MenuItem
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly BL_MenuItem _blMenuItem;

        public MenuItemController(BL_MenuItem blMenuItem)
        {
            _blMenuItem = blMenuItem;
        }

        [HttpPost]
        public IActionResult Create(MenuItemModel menuItem)
        {
            var result = _blMenuItem.CreateMenuItem(menuItem);
            string message = result > 0 ? "New MenuItem Creation Successful" : "New MenuItem Creation Fail";
            return Ok(message);
        }
        [HttpGet]
        public IActionResult GetItem()
        {
            var list = _blMenuItem.GetAllMenuItem();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetMenuById(int id)
        {
            var item = _blMenuItem.GetMenuItemById(id);
            return Ok(item);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMenuItem(int id, MenuItemModel menuItem)
        {
            var result = _blMenuItem.UpdateMenuItem(id,menuItem);
            string message = result > 0 ? "Updating Successful!" : "Updating Failed!";
            return Ok(message);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMenuItem(int id)
        {
            var result= _blMenuItem.DeleteMenuItem(id);
            string message = result > 0 ? "Deleting Successful!" : "Deleting Failed!";
            return Ok(message);

        }

    }
}
