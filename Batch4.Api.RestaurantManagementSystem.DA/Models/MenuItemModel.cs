namespace Batch4.Api.RestaurantManagementSystem.DA.Models;

[Table("Tbl_MenuItem")]
public class MenuItemModel
{
    [Key]
    public int ItemId { get; set; }    
    public string ItemName { get; set; }
        
    public decimal ItemPrice { get; set; }
    public string CategoryCode { get; set; }

}
