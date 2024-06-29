using Batch4.Api.RestaurantManagementSystem.DA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.Api.RestaurantManagementSystem.DA.Db
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<MenuItemModel> MenuItem { get; set; }

    }
}
