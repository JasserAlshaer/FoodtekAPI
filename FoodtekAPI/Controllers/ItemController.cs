using FoodtekAPI.Interfaces;
using FoodtekAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodtekAPI.Controllers
{
    public class ItemController : ControllerBase
    {
        private readonly IItem _ItemService;

        public ItemController(IItem ItemService)
        {
            _ItemService = ItemService;
        }

        [HttpGet("Get-One-Item/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var existing = await _ItemService.GetOneItem(id);
                return existing is null ? NotFound() : Ok(existing);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
