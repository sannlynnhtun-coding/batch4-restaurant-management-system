using Batch4.Api.RestaurantManagementSystem.BL.Services.Category;
using Batch4.Api.RestaurantManagementSystem.DA.Models;
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
            try
            {
                var result = _blCategory.CreateCategory(category);
                string message = result > 0 ? "New category Creation Successful" : "New category Creation Fail";
                return Ok(message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var list = _blCategory.GetAllCategories();
                return Ok(list);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("id/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var item = _blCategory.GetCategoryById(id);
                return Ok(item);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("code/{code}")]
        public IActionResult GetByCode(string code)
        {
            try
            {
                var item = _blCategory.GetCategoryByCode(code);
                return Ok(item);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{code}")]
        public IActionResult Update(string code, CategoryModel category)
        {
            try
            {
                var result = _blCategory.UpdateCategory(code, category);
                string message = result > 0 ? "Updated Successful" : "Failed update!";
                return Ok(message);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{code}")]
        public IActionResult Delete(string code) 
        {
            try
            {
                var result = _blCategory.DeleteCategory(code);
                string message = result > 0 ? "Deleted Successful" : "Failed delete!";
                return Ok(message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
