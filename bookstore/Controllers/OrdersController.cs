using bookstore.Data.Cart;
using bookstore.Data.Services;
using bookstore.Data.Static;
using bookstore.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace bookstore.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {

        private readonly ICartiService _cartiService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _ordersService;
        public OrdersController(ICartiService cartiService, ShoppingCart shoppingCart, IOrdersService ordersService)
        {
            _cartiService = cartiService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
        }
        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string UserRole = User.FindFirstValue(ClaimTypes.Role);
            var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId,UserRole);
            return View(orders);
        }
        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(response);
        }
        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _cartiService.GetCarteByIdAsync(id);
            if(item !=null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart)); 

        }
        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _cartiService.GetCarteByIdAsync(id);
            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));

        }
        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAdress = User.FindFirstValue(ClaimTypes.Email);
           await _ordersService.StoreOrderAsync(items, userId, userEmailAdress);
           await _shoppingCart.ClearShoppingCartAsync();
            return View("OrderCompleted");
        }
    }
}
