namespace Batch4.Api.RestaurantManagementSystem.BL.Services.Category;

public class BL_Category
{
    private readonly DA_Category _daCategory;

    public BL_Category(DA_Category daCategory)
    {
        _daCategory = daCategory;
    }

    public async Task<int> CreateCategory(CategoryRequest category)
    {
        if (this.IsExist(category.CategoryName)) throw new Exception("Already Existed!");

        var result = await _daCategory.CreateCategory(category);
        return result;
    }

    public async Task<List<CategoryModel>> GetAllCategories()
    {
        return await _daCategory.GetAllCategories();
    }

    public async Task<CategoryModel> GetCategoryById(int id)
    {
        var category = await _daCategory.GetCategoryById(id);
        if (category == null) throw new InvalidDataException("no data found");
        return category;
    }

    public async Task<CategoryModel> GetCategoryByCode(string code)
    {
        var category = await _daCategory.GetCategoryByCode(code);
        return category;
    }

    public async Task<int> DeleteCategory(int id)
    {
        return await _daCategory.DeleteCategory(id);
    }

    private bool IsExist(string name)
    {
        var Category = _daCategory.FindByName(name);
        if (Category == null) return false;
        return true;
    }
}
