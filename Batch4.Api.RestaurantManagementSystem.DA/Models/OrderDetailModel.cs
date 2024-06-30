using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Batch4.Api.RestaurantManagementSystem.DA.Models;

[Table("Tbl_OrderDetail")]
public class OrderDetailModel
{
    [Key]
    public int OrderDetailId { get; set; }

    public string InvoiceNo { get; set; }

    public int ItemId { get; set; }

    public int Quantity { get; set; }

    public decimal TotalPrice { get; set; }
}
