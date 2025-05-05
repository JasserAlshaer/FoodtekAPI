using FoodtekAPI.DTOs.Category;
using FoodtekAPI.DTOs.Discount;
using FoodtekAPI.Interfaces;
using FoodtekAPI.Models;

namespace FoodtekAPI.Services
{
    public class DiscountService : IDiscount
    {
        private readonly FoodtekDbContext _Context;

        public DiscountService(FoodtekDbContext context)
        {
            _Context = context;
        }
        public async Task<List<DiscountDTO>> GetAllDiscount()
        {
            var discounts = _Context.Discounts.ToList();
            
            var discountsDTOs = discounts.Select(d => new DiscountDTO
            {
               
                TitleAr = d.TitleAr,
                TitleEn = d.TitleEn,
                DescriptionAr=d.DescriptionAr,
                DescriptionEn=d.DescriptionEn,
                ImageUrl=d.ImageUrl
                // add to discount model
            }).ToList();

            return discountsDTOs;
        }

        Task<DiscountDTO> IDiscount.GetAllDiscount()
        {
            throw new NotImplementedException();
        }
    }
}
