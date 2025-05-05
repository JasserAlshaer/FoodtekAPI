using FoodtekAPI.DTOs.ItemSearch.Response;
using FoodtekAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodtekAPI.Services
{
    public class GetTopRecommendedItemService
    {
        private readonly FoodtekDbContext _foodtekDbContext;
        public GetTopRecommendedItemService(FoodtekDbContext foodtekDbContext)
        {
            _foodtekDbContext = foodtekDbContext;
        }

        public async Task<List<TopRecommendedItemDTO>> GetTopRecommendedItemsAsync()
        {
            var topItems = await _foodtekDbContext.OrderItems
                .GroupBy(oi => oi.ItemId)
                .Select(group => new
                {
                    ItemId = group.Key,
                    OrderCount = group.Sum(x => x.Quantity)
                })
                .OrderByDescending(x => x.OrderCount)
                .Take(10)
                .Join(_foodtekDbContext.Items,
                      g => g.ItemId,
                      i => i.ItemId,
                      (g, i) => new TopRecommendedItemDTO
                      {
                          Id = i.ItemId,
                          EnglishName = i.EnglishName,
                          ArabicName = i.ArabicName,
                          EnglishDescription = i.DescriptionEn,
                          ArabicDescription = i.DescriptionAr,
                          Price = (float)i.Price,
                          Image = i.ImagePath
                      })
                .ToListAsync();

            return topItems;
        }

    }
}
