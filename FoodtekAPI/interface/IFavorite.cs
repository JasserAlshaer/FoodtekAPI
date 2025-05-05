using FoodtekAPI.DTOs.Favorites;

namespace FoodtekAPI.Interfaces
{
    public interface IFavorite
    {
        Task<string> AddToFavorite(FavoriteDTO FavoriteDTO);
        Task<string> RemoveFromFavorite(int itemId);
    }
}
