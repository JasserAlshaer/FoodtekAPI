namespace FoodtekAPI.DTOs.SignIns.Request
{
    public class RegistrationDTO
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Phonenum { get; set; }

        public string firstname { get; set; }

        public string lastname { get; set; }

        public DateTime BirthDate { get; set; }

        // public DateTime BirthDate { get; set; }
        //data type of BirthDate



    }
}
