using FoodtekAPI.DTOs.Item;
using FoodtekAPI.DTOs.ItemSearch.Response;
using FoodtekAPI.Interfaces;
using FoodtekAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodtekAPI.Services
{
    public class ItemService : IItem
    {
        private  readonly FoodtekDbContext _foodtekDbContext;
        public  ItemService(FoodtekDbContext foodtekDbContext)
        {
            _foodtekDbContext = foodtekDbContext;
        }

        public  async Task<List<TopRatedItemDTO>> GetTopRatedItemsAsync()
        {
            var topRatedItems = await _foodtekDbContext.Items
                .Select(item => new
                {
                    Item = item,
                    AverageRate = _foodtekDbContext.RatingsAndReviews
                        .Where(r => r.ItemId == item.ItemId)
                        .Average(r => (double?)r.RatingValue) ?? 0
                })
                .OrderBy(x => x.AverageRate) 
                .Take(10)
                .Select(x => new TopRatedItemDTO
                {
                    Id = x.Item.ItemId,
                    EnglishName = x.Item.EnglishName,
                    ArabicName = x.Item.ArabicName,
                    EnglishDescription = x.Item.DescriptionEn,
                    ArabicDescription = x.Item.DescriptionAr,
                    Price = (float)x.Item.Price,
                    Image = x.Item.ImagePath,
                    Rate = x.AverageRate
                })
                .ToListAsync();

            return topRatedItems;
        }
        public async Task<ItemDTO> GetOneItem(int id)
        {
            var existing = await _foodtekDbContext.Items.FindAsync(id);
            if (existing is null)
                return null;

            var itemDTO = new ItemDTO
            {
                NameAr = existing.ArabicName,
                NameEn = existing.EnglishName,
                DescriptionAr = existing.DescriptionAr,
                DescriptionEn = existing.DescriptionEn,
                Price = Convert.ToSingle(existing.Price)
            };

            return itemDTO;




        }

    }
}
