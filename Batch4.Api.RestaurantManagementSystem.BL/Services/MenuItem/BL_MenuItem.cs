namespace Batch4.Api.RestaurantManagementSystem.BL.Services.MenuItem;

public class BL_MenuItem
{
    private readonly DA_MenuItem _daMenuItem;

    public BL_MenuItem(DA_MenuItem daMenuItem)
    {
        _daMenuItem = daMenuItem;
    }

    public async Task<int> CreateMenuItem(MenuItemRequest menuItem)
    {
        if (isExist(menuItem.name)) throw new Exception("Already existed!");

        var result = await _daMenuItem.CreateMenuItem(menuItem.Change());
        return result;
    }

    public async Task<List<MenuItemModel>> GetAllMenuItem()
    {
        return await _daMenuItem.GetAllMenuItem();
    }

    public async Task<MenuItemModel> GetMenuItemById(int id)
    {
        var item = await _daMenuItem.GetMenuItemById(id);
        return item;
    }

    public async Task<List<MenuItemModel>> GetMenuItemsByCategoryCode(string categoryCode)
    {
        var lst = await _daMenuItem.GetMenuItemByCategoryCode(categoryCode);
        return lst;
    }

    public async Task<int> UpdateMenuItem(int id, MenuItemRequest menuModel)
    {
        //if (isExist(menuModel.name)) throw new Exception("Already existed!");

        var item = await _daMenuItem.UpdateMenuItem(id, menuModel.Change());
        return item;
    }

    public async Task<int> DeleteMenuItem(int id)
    {
        return await _daMenuItem.DeleteMenuItem(id);
    }

    private bool isExist(string name)
    {
        var item = _daMenuItem.FindByName(name);
        if (item == null) return false;
        return true;
    }
}
