using Batch4.Api.RestaurantManagementSystem.DA.Services.Category;

namespace Batch4.Api.RestaurantManagementSystem.DA.Services.MenuItem;

public class DA_MenuItem
{
    private readonly AppDbContext _db;
    private readonly DA_Category _daCategory;

    public DA_MenuItem(AppDbContext db,
        DA_Category daCategory)
    {
        _db = db;
        _daCategory = daCategory;
    }

    public async Task<int> CreateMenuItem(MenuItemRequestModel reqModel)
    {
        MenuItemModel menu = new MenuItemModel()
        {
            ItemName = reqModel.ItemName,
            ItemPrice = reqModel.ItemPrice,
            CategoryCode = reqModel.CategoryCode
        };
        _db.MenuItem.Add(menu);
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
        var lst = await _db.MenuItem.Where(x => x.CategoryCode == categoryCode).ToListAsync();
        return lst;
    }

    public async Task<int> UpdateMenuItem(int id, MenuItemRequestModel reqModel)
    {
        var category = await _daCategory.GetCategoryByCode(reqModel.CategoryCode);
        if (category is null) return 0;
        MenuItemModel item = await GetMenuItemById(id);
        item.ItemName = reqModel.ItemName;
        item.ItemPrice = reqModel.ItemPrice;
        item.CategoryCode = reqModel.CategoryCode;

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
