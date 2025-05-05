using FoodtekAPI.DTOs.Item;

namespace FoodtekAPI.Interfaces
{
    public interface IItem
    {
        Task<ItemDTO> GetOneItem(int id);
    }
}
