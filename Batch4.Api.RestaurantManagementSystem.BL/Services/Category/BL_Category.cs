using Batch4.Api.RestaurantManagementSystem.BL.RequestModels;
using Batch4.Api.RestaurantManagementSystem.DA.Models;
using Batch4.Api.RestaurantManagementSystem.DA.Services.Category;

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
        if (this.IsExist(category.categoryName)) throw new Exception("Already Existed!");

        var result = await _daCategory.CreateCategory(category.Change());
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

    public async Task<int> DeleteCategory(string code)
    {
        return await _daCategory.DeleteCategory(code);
    }

    private bool IsExist(string name)
    {
        var Category = _daCategory.FindByName(name);
        if(Category == null) return false;
        return true;
    }
}
