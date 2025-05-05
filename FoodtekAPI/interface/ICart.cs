using FoodtekAPI.DTOs.Cart;

namespace FoodtekAPI.interfaces
{
   public interface ICart
    {
        Task<string> AddItemToCart(CartDTO itemDTO);

    }
}


