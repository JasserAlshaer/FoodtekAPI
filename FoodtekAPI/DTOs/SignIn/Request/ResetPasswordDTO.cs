namespace FoodtekAPI.DTOs.SignIns.Request
{
    public class ResetPasswordDTO
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string OTP { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
