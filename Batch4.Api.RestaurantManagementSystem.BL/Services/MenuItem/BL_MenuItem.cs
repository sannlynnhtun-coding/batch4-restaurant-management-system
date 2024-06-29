using Batch4.Api.RestaurantManagementSystem.DA.Models;
using Batch4.Api.RestaurantManagementSystem.DA.Services.Category;
using Batch4.Api.RestaurantManagementSystem.DA.Services.MenuItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (item == null) throw new InvalidDataException("No data found");
            return item;
        }
        public int UpdateMenuItem(int id, MenuItemModel menuModel)
        {
            var item = _daMenuItem.UpdateMenuItem(id, menuModel);
            if (item == null) throw new InvalidDataException("No data found");
            return item;
        }
        public int DeleteMenuItem(int id)
        {
            return _daMenuItem.DeleteMenuItem(id);
        }

    }
}
