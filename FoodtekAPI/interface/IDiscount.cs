using FoodtekAPI.DTOs.Discount;

namespace FoodtekAPI.Interfaces
{
    public interface IDiscount
    {
        Task<DiscountDTO> GetAllDiscount();




    }
}
