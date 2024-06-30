using Batch4.Api.RestaurantManagementSystem.BL.Services.Category;
using Batch4.Api.RestaurantManagementSystem.BL.Services.MenuItem;
using Batch4.Api.RestaurantManagementSystem.DA.Models;
using Microsoft.AspNetCore.Mvc;

namespace Batch4.Api.RestaurantManagementSystem.Controllers.MenuItem
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly BL_MenuItem _blMenuItem;
        private readonly BL_Category _blCategory;

        public MenuItemController(BL_MenuItem blMenuItem,BL_Category blCategory)
        {
            _blMenuItem = blMenuItem;
            _blCategory = blCategory;
        }

        [HttpPost]
        public IActionResult Create(MenuItemModel menuItem)
        {
            var category = _blCategory.GetCategoryByCode(menuItem.CategoryCode);
            if (category is null) return Ok("Invalid Category.");

            var result = _blMenuItem.CreateMenuItem(menuItem);
            string message = result > 0 ? "New MenuItem Creation Successful" : "New MenuItem Creation Fail";
            return Ok(message);
        }

        [HttpGet]
        public IActionResult GetItem()
        {
            var list = _blMenuItem.GetAllMenuItem();
            if (list.Count == 0) return Ok("No Menu Item Found");
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
            var menu = _blMenuItem.GetMenuItemById(id);
            if (menu is null) return Ok("Np Data Found");

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
