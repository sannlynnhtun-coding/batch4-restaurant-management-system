namespace Batch4.Api.RestaurantManagementSystem.DA.Models;

[Table("Tbl_Category")]
public class CategoryModel
{
    [Key]
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }    
    public string CategoryCode { get; set; }
}
