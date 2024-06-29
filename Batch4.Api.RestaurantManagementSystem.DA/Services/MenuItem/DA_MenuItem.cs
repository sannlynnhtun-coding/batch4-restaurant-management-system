using Batch4.Api.RestaurantManagementSystem.DA.Db;
using Batch4.Api.RestaurantManagementSystem.DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.Api.RestaurantManagementSystem.DA.Services.MenuItem
{
    public class DA_MenuItem
    {
        private readonly AppDbContext _db;

        public DA_MenuItem(AppDbContext db)
        {
            _db = db;
        }
        public int CreateMenuItem(MenuItemModel menuItem)
        {
            _db.MenuItem.Add(menuItem);
            int result = _db.SaveChanges();
            return result;
        }
        public List<MenuItemModel> GetAllMenuItem()
        {
            List<MenuItemModel> list = _db.MenuItem.ToList();
            return list;
        }
        public MenuItemModel GetMenuItemById(int id)
        {
            MenuItemModel item = _db.MenuItem.FirstOrDefault(x => x.ItemId == id)!;
            return item;
        }
        public int UpdateMenuItem(int id,MenuItemModel menuModel)
        {
            MenuItemModel item = this.GetMenuItemById(id);
            if (item == null) throw new InvalidDataException("No data found");

            item.ItemName = menuModel.ItemName;
            item.ItemPrice = menuModel.ItemPrice;
            item.CategoryCode = menuModel.CategoryCode;

            int result = _db.SaveChanges();
            return result;
        }
        public int DeleteMenuItem(int id)
        {
            MenuItemModel item = this.GetMenuItemById(id); ;
            if (item == null) throw new InvalidDataException("No data found");

            _db.MenuItem.Remove(item);

            int result = _db.SaveChanges();
            return result;
        }
    }
}
