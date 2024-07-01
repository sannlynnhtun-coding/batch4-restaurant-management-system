namespace Batch4.Api.RestaurantManagementSystem.DA.Models;

[Table("Tbl_Order")]
public class OrderModel
{
    [Key]
    public int OrderId { get; set; }

    public string InvoiceNo { get; set; }

    public decimal TotalPrice { get; set; }
}
