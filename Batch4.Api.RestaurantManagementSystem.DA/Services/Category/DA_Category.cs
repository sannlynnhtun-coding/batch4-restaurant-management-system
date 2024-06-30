using Batch4.Api.RestaurantManagementSystem.DA.Db;
using Batch4.Api.RestaurantManagementSystem.DA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.Api.RestaurantManagementSystem.DA.Services.Category;

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

    public List<CategoryModel> GetAllCategories()
    {
        List<CategoryModel> list = _db.Categories.ToList();
        return list;
    }

    public CategoryModel GetCategoryById(int id)
    {
        CategoryModel category = _db.Categories.FirstOrDefault(x => x.CategoryId ==  id);
        return category;
    }

    public CategoryModel GetCategoryByCode(string code)
    {
        CategoryModel category = _db.Categories.FirstOrDefault(x => x.CategoryCode == code);
        return category;
    }

    //public int UpdateCategory(string categoryCode,  CategoryModel category)
    //{
    //    CategoryModel item = this.GetCategoryByCode(categoryCode);
    //    if (item == null) throw new InvalidDataException("no data found");

    //    item.CategoryName = category.CategoryName;
    //    item.CategoryCode = category.CategoryCode;

    //    int result = _db.SaveChanges();
    //    return result;
    //}

    public int DeleteCategory(string categoryCode)
    {
        CategoryModel category = this.GetCategoryByCode(categoryCode);
        if (category == null) throw new InvalidDataException("no data found");

        _db.Categories.Remove(category);

        int result = _db.SaveChanges();
        return result;
    }

    public CategoryModel FindByName(string name)
    {
        CategoryModel category = _db.Categories.FirstOrDefault(x => x.CategoryName == name);
        return category;
    }
}
