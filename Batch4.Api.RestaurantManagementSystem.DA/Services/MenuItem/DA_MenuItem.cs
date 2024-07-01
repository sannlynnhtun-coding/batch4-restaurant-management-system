using Batch4.Api.RestaurantManagementSystem.DA.Db;
using Batch4.Api.RestaurantManagementSystem.DA.Models;
using Microsoft.EntityFrameworkCore;

namespace Batch4.Api.RestaurantManagementSystem.DA.Services.MenuItem;

public class DA_MenuItem
{
    private readonly AppDbContext _db;

    public DA_MenuItem(AppDbContext db)
    {
        _db = db;
    }

    public async  Task<int> CreateMenuItem(MenuItemModel menuItem)
    {
        _db.MenuItem.Add(menuItem);
        int result = await _db.SaveChangesAsync();
        return result;
    }

    public async Task<List<MenuItemModel>> GetAllMenuItem()
    {
        List<MenuItemModel> list = await _db.MenuItem.ToListAsync();
        return list;
    }

    public async Task<MenuItemModel> GetMenuItemById(int id)
    {
        MenuItemModel item = await _db.MenuItem.FirstOrDefaultAsync(x => x.ItemId == id)!;
        return item;
    }

    public async Task<List<MenuItemModel>> GetMenuItemByCategoryCode(string categoryCode)
    {
        var lst = await _db.MenuItem.Where(x=>x.CategoryCode==categoryCode).ToListAsync();
        return lst;
    }

    public async Task<int> UpdateMenuItem(int id,MenuItemModel menuModel)
    {
        MenuItemModel item = await GetMenuItemById(id);
        item.ItemName = menuModel.ItemName;
        item.ItemPrice = menuModel.ItemPrice;
        item.CategoryCode = menuModel.CategoryCode;

        int result = await _db.SaveChangesAsync();
        return result;
    }

    public async Task<int> DeleteMenuItem(int id)
    {
        MenuItemModel item = await this.GetMenuItemById(id); ;
        if (item == null) throw new InvalidDataException("No data found");

        _db.MenuItem.Remove(item);

        int result = await _db.SaveChangesAsync();
        return result;
    }

    public MenuItemModel FindByName(string name)
    {
        MenuItemModel item = _db.MenuItem.FirstOrDefault(x => x.ItemName == name);
        return item;
    }
}
