using Batch4.Api.RestaurantManagementSystem.DA.Models;
using Batch4.Api.RestaurantManagementSystem.DA.Services.MenuItem;

namespace Batch4.Api.RestaurantManagementSystem.BL.Services.MenuItem
{
    public class BL_MenuItem
    {
        private readonly DA_MenuItem _daMenuItem;

        public BL_MenuItem(DA_MenuItem daMenuItem)
        {
            _daMenuItem = daMenuItem;
        }

        public int CreateMenuItem(MenuItemModel menuItem)
        {
            var result = _daMenuItem.CreateMenuItem(menuItem);
            return result;
        }

        public List<MenuItemModel> GetAllMenuItem()
        {
            return _daMenuItem.GetAllMenuItem();
        }

        public MenuItemModel GetMenuItemById(int id)
        {
            var item = _daMenuItem.GetMenuItemById(id);
            return item;
        }

        public List<MenuItemModel> GetMenuItemsByCategoryCode(string categoryCode)
        {
            var lst = _daMenuItem.GetMenuItemByCategoryCode(categoryCode);
            return lst;
        }

        public int UpdateMenuItem(int id, MenuItemModel menuModel)
        {
            var item = _daMenuItem.UpdateMenuItem(id, menuModel);
            return item;
        }

        public int DeleteMenuItem(int id)
        {
            return _daMenuItem.DeleteMenuItem(id);
        }

    }
}
