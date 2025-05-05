using FoodtekAPI.DTOs.Cart;
using FoodtekAPI.DTOs.Item;
using FoodtekAPI.interfaces;
using FoodtekAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodtekAPI.Services
{
    public class CartService : ICart
    {
        private readonly FoodtekDbContext _DbContext;
        public CartService(FoodtekDbContext DbContext)
        {
            _DbContext = DbContext;
        }
        public async Task<string> AddItemToCart(CartDTO itemDTO)
        {
            var cart = await _DbContext.Cart.Include(c => c.CartItems).SingleOrDefaultAsync(c => c.CartId == itemDTO.CartId);

            if (cart == null)
            {
                return "Cart not found!";
            }

            var item = await _DbContext.Items.SingleOrDefaultAsync(i => i.ItemId == itemDTO.ItemId);

            if (item == null)
            {
                return "Item not found!";
            }

          
            var cartItem = cart.CartItems.SingleOrDefault(ci => ci.ItemId == itemDTO.ItemId);

            if (cartItem != null)
            {
                
                cartItem.Quantity += itemDTO.Quantity;
                cartItem.TotalPrice = cartItem.Quantity * item.Price;
            }
            else
            {
              
                cart.CartItems.Add(new CartItem
                {
                    CartId = cart.CartId,
                    ItemId = itemDTO.ItemId,
                    Quantity = itemDTO.Quantity,
                    TotalPrice = itemDTO.Quantity * item.Price
                });
            }

       
            await _DbContext.SaveChangesAsync();

            return "Item added to cart successfully!";
        }
    }
}