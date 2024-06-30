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

    public int CreateCategory(CategoryRequest category)
    {
        var IsExist = _daCategory.FindByName(category.categoryName);
        if (IsExist != null) throw new Exception("Already Existed!");

        var result = _daCategory.CreateCategory(category.Change());
        return result;
    }

    public List<CategoryModel> GetAllCategories()
    {
        return _daCategory.GetAllCategories();
    }

    public CategoryModel GetCategoryById(int id)
    {
        var category = _daCategory.GetCategoryById(id);
        if (category == null) throw new InvalidDataException("no data found");
        return category;
    }

        public CategoryModel GetCategoryByCode(string code)
        {
            var category = _daCategory.GetCategoryByCode(code);
            return category;
        }

    public int UpdateCategory(string code,  CategoryRequest category)
    {
        var result = _daCategory.UpdateCategory(code, category.Change());
        return result;
    }

    public int DeleteCategory(string code)
    {
        return _daCategory.DeleteCategory(code);
    }
}
