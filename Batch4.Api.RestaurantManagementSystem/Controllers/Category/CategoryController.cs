using Batch4.Api.RestaurantManagementSystem.BL.Services.Category;
using Batch4.Api.RestaurantManagementSystem.DA.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Batch4.Api.RestaurantManagementSystem.Controllers.Category
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly BL_Category _blCategory;

        public CategoryController(BL_Category blCategory)
        {
            _blCategory = blCategory;
        }

        [HttpPost]
        public IActionResult Create(CategoryModel category)
        {
            var result = _blCategory.CreateCategory(category);
            string message = result > 0 ? "New category Creation Successful" : "New category Creation Fail";
            return Ok(message);
        }
    }
}
