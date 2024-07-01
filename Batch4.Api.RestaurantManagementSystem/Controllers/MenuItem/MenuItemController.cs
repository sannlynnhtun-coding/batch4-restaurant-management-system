namespace Batch4.Api.RestaurantManagementSystem.Controllers.MenuItem;

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
    public async Task<IActionResult> Create(MenuItemRequest menuItem)
    {
        try
        {
        var category = _blCategory.GetCategoryByCode(menuItem.categoryCode);
        if (category is null) return Ok("Invalid Category.");

        var result = await _blMenuItem.CreateMenuItem(menuItem);
        string message = result > 0 ? "New MenuItem Creation Successful" : "New MenuItem Creation Fail";
        return Ok(message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetItem()
    {
        try
        {
            var list = await _blMenuItem.GetAllMenuItem();
            if (list.Count == 0) return Ok("No Menu Item Found");
            return Ok(list);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetMenuById(int id)
    {
        try
        {
            var item = await _blMenuItem.GetMenuItemById(id);
            if (item is null) return Ok("No Menu Item Found.");
            return Ok(item);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMenuItem(int id, MenuItemRequest menuItem)
    {
        try
        {
            var menu = await _blMenuItem.GetMenuItemById(id);
            if (menu is null) return Ok("No Data Found");

            var result = await _blMenuItem.UpdateMenuItem(id, menuItem);
            string message = result > 0 ? "Updating Successful!" : "Updating Failed!";
            return Ok(message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMenuItem(int id)
    {
        try
        {
            var result = await _blMenuItem.DeleteMenuItem(id);
            string message = result > 0 ? "Deleting Successful!" : "Deleting Failed!";
            return Ok(message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("CategoryCode/{categoryCode}")]
    public async Task<IActionResult> GetMenuItemsByCategoryCode(string categoryCode)
    {
        try
        {
            var menulst = await _blMenuItem.GetMenuItemsByCategoryCode(categoryCode);
            if (menulst.Count == 0) return Ok("No menu found.");
            return Ok(menulst);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}
