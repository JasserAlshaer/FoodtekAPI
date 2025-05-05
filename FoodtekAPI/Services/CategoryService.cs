using FoodtekAPI.DTOs.Category;
using FoodtekAPI.Interfaces;
using FoodtekAPI.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using FoodtekAPI.Interfaces;
namespace FoodtekAPI.Services
{
    public class CategoryService : ICategory
    {
        private readonly FoodtekDbContext _Context;

        public CategoryService(FoodtekDbContext context)
        {
            _Context = context;
        }
        public async Task<List<CategoryDTO>> GetAllCategory()
        {
            var categories = _Context.Categories.ToList(); 

            var categoriesDTOs = categories.Select(d => new CategoryDTO
            {
                ARName = d.NameAr,
                ENName = d.NameEn,
                ImagePath = d.ImagePath,
            }).ToList();

            return categoriesDTOs;
        }
    }
}
