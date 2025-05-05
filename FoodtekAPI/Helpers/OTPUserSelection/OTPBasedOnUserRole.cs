using FoodtekAPI.Helpers.SendingEmail;
using FoodtekAPI.Models;

namespace FoodtekAPI.Helpers.OTPUserSelection
{
    public class OTPBasedOnUserRole
    {
        private readonly FoodtekDbContext _foodtekDbContext;
        private readonly MailingHelper _mailingHelper;
        public OTPBasedOnUserRole(FoodtekDbContext foodtekDbContext, MailingHelper mailingHelper)
        {
            _foodtekDbContext = foodtekDbContext;
            _mailingHelper = mailingHelper;
        }
        public async void OTPBasedOnUserType(string Email,string title, string message) {
            var user =  _foodtekDbContext.Users.Where(x=>x.Email== Email).FirstOrDefault();
            var otp=100;
            Random rand = new Random();
            switch (user.UserId)
            {
                case 1:
                    otp = rand.Next(11111, 99999);
                    user.ExpireOTP = DateTime.Now.AddMinutes(10);
                    //Send code via email
                    _mailingHelper.SendEmail(user.Email,user.OTP, title,message);
                    _foodtekDbContext.Update(user);
                    _foodtekDbContext.SaveChanges();
                    break;

                case 2:
                     otp = rand.Next(11111, 99999);
                    user.ExpireOTP = DateTime.Now.AddMinutes(10);
                    //Send code via email
                    _mailingHelper.SendEmail(user.Email, user.OTP, title, message);
                    _foodtekDbContext.Update(user);
                    _foodtekDbContext.SaveChanges();

                    break;
                case 3:
                     otp = rand.Next(11111, 99999);
                    user.ExpireOTP = DateTime.Now.AddMinutes(60);
                    //Send code via email
                    _mailingHelper.SendEmail(user.Email, user.OTP, title, message);
                    _foodtekDbContext.Update(user);
                    _foodtekDbContext.SaveChanges();

                    break;
                case 5:

                     otp = rand.Next(11111, 99999);
                    user.ExpireOTP = DateTime.Now.AddMinutes(60);
                    //Send code via email
                    _mailingHelper.SendEmail(user.Email, user.OTP, title, message);
                    _foodtekDbContext.Update(user);
                    _foodtekDbContext.SaveChanges();

                    break;
                default:
                    Console.WriteLine("This Role Doesn't Have OTP");
                    break;           
            }

        }
    }
}
