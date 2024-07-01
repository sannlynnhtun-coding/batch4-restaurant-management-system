namespace Batch4.Api.RestaurantManagementSystem.DA.Db;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<CategoryModel> Categories { get; set; }
    public DbSet<MenuItemModel> MenuItem { get; set; }
    public DbSet<OrderModel> Orders { get; set; }
    public DbSet<OrderDetailModel> OrderDetails { get; set; }

}
