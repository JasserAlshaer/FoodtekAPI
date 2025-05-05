namespace FoodtekAPI.DTOs.Item
{
    public class ItemDTO
    {
        public string NameAr { get; set; }
        public string NameEn{ get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }

        public float Price { get; set; }
        public int Rate { get; set; }
        public int NumberOfReview {  get; set; }

    }
}
