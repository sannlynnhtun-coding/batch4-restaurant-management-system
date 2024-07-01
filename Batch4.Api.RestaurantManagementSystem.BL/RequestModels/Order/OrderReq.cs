using Batch4.Api.RestaurantManagementSystem.DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Quic;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.Api.RestaurantManagementSystem.BL.RequestModels.Order;

public class OrderReq
{
    public List<Order> orders { get; set; }

    public OrderModel Change(string invoiceNo,decimal total)
    {
        return new OrderModel
        {
            InvoiceNo = invoiceNo,
            TotalPrice = total
        };
    }
}

public record Order(int itemId, int qty)
{
    public OrderDetailModel Change(string invoiceNo, decimal total)
    {
        return new OrderDetailModel
        {
            InvoiceNo = invoiceNo,
            ItemId = itemId,
            Quantity = qty,
            TotalPrice = total
        };
    }
};