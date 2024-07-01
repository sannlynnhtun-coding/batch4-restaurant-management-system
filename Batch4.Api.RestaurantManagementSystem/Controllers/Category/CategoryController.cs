namespace Batch4.Api.RestaurantManagementSystem.Controllers.Category;

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
    public async Task<IActionResult> Create(CategoryRequest category)
    {
        try
        {
            var result = await _blCategory.CreateCategory(category);
            string message = result > 0 ? "New category Creation Successful" : "New category Creation Fail";
            return Ok(message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var list = await _blCategory.GetAllCategories();
            return Ok(list);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var item = await _blCategory.GetCategoryById(id);
            return Ok(item);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [HttpGet("code/{code}")]
    public async Task<IActionResult> GetByCode(string code)
    {
        try
        {
            var item = await _blCategory.GetCategoryByCode(code);
            if(item is null) return Ok("No Category Found.");
            return Ok(item);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{code}")]
    public async Task<IActionResult> Delete(string code) 
    {
        try
        {
            var result = await _blCategory.DeleteCategory(code);
            string message = result > 0 ? "Deleted Successful" : "Failed delete!";
            return Ok(message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
