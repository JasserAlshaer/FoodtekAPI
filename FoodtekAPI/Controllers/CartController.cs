using FoodtekAPI.DTOs.Cart;
using FoodtekAPI.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodtekAPI.Controllers
{
    public class CartController : Controller
    {
        private readonly ICart _cartService;

        public CartController(ICart cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("add-item")]
        public async Task<IActionResult> AddItem([FromBody] CartDTO itemDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _cartService.AddItemToCart(itemDTO);

            if (result.Contains("not found", StringComparison.OrdinalIgnoreCase))
                return NotFound(result);

            return Ok(result);
        }


    }
}
