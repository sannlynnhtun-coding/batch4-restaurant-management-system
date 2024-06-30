using Batch4.Api.RestaurantManagementSystem.DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.Api.RestaurantManagementSystem.BL.RequestModels;

public record MenuItemRequest(string name, decimal price, string categoryCode)
{
    public MenuItemModel Change()
    {
        return new MenuItemModel
        {
            ItemName = name.Trim().ToUpper(),
            ItemPrice = price,
            CategoryCode = categoryCode
        };
    }
}
