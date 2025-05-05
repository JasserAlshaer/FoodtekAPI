using FoodtekAPI.Interfaces;
using FoodtekAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodtekAPI.Controllers
{
    public class DiscountController : ControllerBase
    {
        private readonly IDiscount _discountService;

        public DiscountController(IDiscount discountService)
        {
            _discountService = discountService;
        }

        [HttpGet("Get-allDiscounts")]
        public async Task<IActionResult> GetAllDiscounts()
        {
            var discounts = await _discountService.GetAllDiscount();
            return Ok(discounts);
        }

    }
}
