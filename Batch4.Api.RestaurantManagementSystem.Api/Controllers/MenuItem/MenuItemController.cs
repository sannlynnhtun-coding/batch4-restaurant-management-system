namespace Batch4.Api.RestaurantManagementSystem.Api.Controllers.MenuItem;

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
    public async Task<IActionResult> Create(MenuItemRequestModel menuItem)
    {
        try
        {
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
    public async Task<IActionResult> UpdateMenuItem(int id, MenuItemRequestModel menuItem)
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
