namespace Batch4.Api.RestaurantManagementSystem.DA.Services.Category;

public class DA_Category
{
    private readonly AppDbContext _db;

    public DA_Category(AppDbContext db)
    {
        _db = db;
    }

    public async Task<int> CreateCategory(CategoryModel category)
    {
        _db.Categories.Add(category);
        int result = await _db.SaveChangesAsync();
        return result;
    }

    public async Task<List<CategoryModel>> GetAllCategories()
    {
        List<CategoryModel> list = await _db.Categories.ToListAsync();
        return list;
    }

    public async Task<CategoryModel> GetCategoryById(int id)
    {
        CategoryModel category = await _db.Categories.FirstOrDefaultAsync(x => x.CategoryId ==  id);
        return category;
    }

    public async Task<CategoryModel> GetCategoryByCode(string code)
    {
        CategoryModel category = await _db.Categories.FirstOrDefaultAsync(x => x.CategoryCode == code);
        return category;
    }

    public async Task<int> DeleteCategory(string categoryCode)
    {
        CategoryModel category = await this.GetCategoryByCode(categoryCode);
        if (category == null) throw new InvalidDataException("no data found");

        _db.Categories.Remove(category);

        int result = await _db.SaveChangesAsync();
        return result;
    }

    public CategoryModel FindByName(string name)
    {
        CategoryModel category = _db.Categories.FirstOrDefault(x => x.CategoryName == name);
        return category;
    }
}
