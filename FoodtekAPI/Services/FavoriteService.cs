using FoodtekAPI.DTOs.Favorites;
using FoodtekAPI.Interfaces;
using FoodtekAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodtekAPI.Services
{
    public class FavoriteService : IFavorite
    {
        private readonly FoodtekDbContext _Context;
        public FavoriteService(FoodtekDbContext Context)
        {
            _Context = Context;
        }
        public async Task<string> AddToFavorite(FavoriteDTO FavoriteDTO)
        {
            var favorite = await _Context.FavoriteItems
            .Where(x => x.ClientId == FavoriteDTO.ClientId)
            .SingleOrDefaultAsync();

            if (favorite == null)
            {
                return "User Not Found!";
            }
            favorite.ItemId = FavoriteDTO.ItemsID;
            _Context.Update(favorite);
            _Context.SaveChanges();

            return "Add Successfully";
        }

        public async Task<string> RemoveFromFavorite(int itemId)
        {
            var favorite = _Context.FavoriteItems.Where(c => c.ItemId == itemId).FirstOrDefault();//
            if (favorite == null)
            {
                return "Item does not exist";
            }


            _Context.Remove(favorite);
            _Context.SaveChanges();

            return "Wishlist Item Removed Successfully";
        }
    }
}

