using bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Data.Services
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAdress);
        Task<List<Order>>GetOrdersByUserIdAndRoleAsync(string userId, string userRole);
    }
}
