namespace FoodtekAPI.DTOs.Cart
{
    public class CartDTO
    {
        public int CartId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public float TotalPrice { get; set; }
        public string Note { get; set; }
        public int? CartItemID { get; set; }
    }
}
