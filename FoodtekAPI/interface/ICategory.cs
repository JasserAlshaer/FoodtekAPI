using FoodtekAPI.DTOs.Category;

namespace FoodtekAPI.Interfaces
{
    public interface ICategory
    {
        Task<List<CategoryDTO>> GetAllCategory();


    }
}
