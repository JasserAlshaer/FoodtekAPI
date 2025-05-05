using FoodtekAPI.Interfaces;
using FoodtekAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodtekAPI.Controllers
{
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _CategoryService;
        public CategoryController(ICategory CategoryService)
        {
            _CategoryService = CategoryService;
        }
        [HttpGet("Get-allCategories")]
        public async Task<IActionResult> GetAllDiscounts()
        {
            var categories = await _CategoryService.GetAllCategory();
            return Ok(categories);
        }

    }
}
