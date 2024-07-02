using Batch4.Api.RestaurantManagementSystem.DA.Services.Category;
using Batch4.Api.RestaurantManagementSystem.Shared;

namespace Batch4.Api.RestaurantManagementSystem.BL.Services.MenuItem;

public class BL_MenuItem
{
    private readonly DA_MenuItem _daMenuItem;
    private readonly DA_Category _daCategory;

    public BL_MenuItem(DA_MenuItem daMenuItem, DA_Category daCategory)
    {
        _daMenuItem = daMenuItem;
        _daCategory = daCategory;
    }

    public async Task<int> CreateMenuItem(MenuItemRequestModel reqModel)
    {
        var category = await _daCategory.GetCategoryByCode(reqModel.CategoryCode);
        if (category is null) throw new Exception("Invalid Category");
        if (isExist(reqModel.ItemName)) throw new Exception("Already existed!");
        var result = await _daMenuItem.CreateMenuItem(reqModel);
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

    public async Task<int> UpdateMenuItem(int id, MenuItemRequestModel menuModel)
    {
        //if (isExist(menuModel.name)) throw new Exception("Already existed!");

        var item = await _daMenuItem.UpdateMenuItem(id, menuModel);
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
