using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.Api.RestaurantManagementSystem.DA.Models
{
    [Table("Tbl_MenuItem")]
    public class MenuItemModel
    {
        [Key]
        public int ItemId { get; set; }    
        public string ItemName { get; set; }
        public double ItemPrice { get; set; }
        public string CategoryCode { get; set; }

    }
}
