using FoodtekAPI.Models;
using System;

namespace FoodtekAPI.interfaces
{
    public interface ITokenProvider
    {
        string CreateToken(User user);

    }
}
