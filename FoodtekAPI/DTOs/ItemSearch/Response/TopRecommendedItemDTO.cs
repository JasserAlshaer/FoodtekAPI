namespace FoodtekAPI.DTOs.ItemSearch.Response
{
    public class TopRecommendedItemDTO
    {
        public int Id { get; set; }
        public string EnglishName { get; set; }
        public string ArabicName { get; set; }
        public string EnglishDescription { get; set; }
        public string ArabicDescription { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

    }
}
