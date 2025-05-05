using FoodtekAPI.Entites;

namespace FoodtekAPI.Models
{
    public class Cart:MainEntity
    {
        public int ClientId { get; set; }
        public int CartId { get; set; }
        public float TotalPrice { get; set; }
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
