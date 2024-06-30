using Batch4.Api.RestaurantManagementSystem.BL.RequestModels;
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

        public int CreateMenuItem(MenuItemRequest menuItem)
        {
            if (isExist(menuItem.name)) throw new Exception("Already existed!");

            var result = _daMenuItem.CreateMenuItem(menuItem.Change());
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

        public int UpdateMenuItem(int id, MenuItemRequest menuModel)
        {
            //if (isExist(menuModel.name)) throw new Exception("Already existed!");

            var item = _daMenuItem.UpdateMenuItem(id, menuModel.Change());
            return item;
        }

        public int DeleteMenuItem(int id)
        {
            return _daMenuItem.DeleteMenuItem(id);
        }

        private bool isExist(string name)
        {
            var item = _daMenuItem.FindByName(name);
            if(item == null) return false;
            return true;
        }
    }
}
