namespace FoodtekAPI.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int CartId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public float TotalPrice { get; set; }
    }
}
