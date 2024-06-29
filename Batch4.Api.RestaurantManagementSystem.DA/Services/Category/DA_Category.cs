using Batch4.Api.RestaurantManagementSystem.DA.Db;
using Batch4.Api.RestaurantManagementSystem.DA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.Api.RestaurantManagementSystem.DA.Services.Category
{
    public class DA_Category
    {
        private readonly AppDbContext _db;

        public DA_Category(AppDbContext db)
        {
            _db = db;
        }

        public int CreateCategory(CategoryModel category)
        {
            _db.Categories.Add(category);
            int result = _db.SaveChanges();
            return result;
        }
    }
}
