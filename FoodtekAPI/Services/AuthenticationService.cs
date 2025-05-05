using FoodtekAPI.DTOs.SignIns.Request;
using FoodtekAPI.Helpers.ValidationFields;
using FoodtekAPI.Helpers.OTPUserSelection;
using FoodtekAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using FoodtekAPI.DTOs.SignIn.Request;
using FoodtekAPI.interfaces;

namespace FoodtekAPI.Services
{
    public class AuthenticationService
    {
        private readonly FoodtekDbContext _foodtekDbContext;
        private readonly OTPBasedOnUserRole _otpBasedOnUserRole;
        private readonly ITokenProvider _tokenProvider;
        public AuthenticationService(FoodtekDbContext foodtekDbContext, OTPBasedOnUserRole otpBasedOnUserRole, ITokenProvider tokenProvider)
        {
            _foodtekDbContext = foodtekDbContext;
            _otpBasedOnUserRole = otpBasedOnUserRole;
            _tokenProvider = tokenProvider;
        }
        public async Task<string> SignIn(SignInInputDTO input)
        {
            try
            {
                var user = await _foodtekDbContext.Users.Where(u => u.Email == input.Email && u.Password == input.Password).FirstOrDefaultAsync();
                if (user == null)
                {
                    return $"No User Found";

                }
                if (!ValidationHelpers.IsValidEmail(input.Email) || !ValidationHelpers.IsValidEmail(input.Password))
                {
                    return $"Not Valid Email or Password";
                }

                _otpBasedOnUserRole.OTPBasedOnUserType(user.Email, "OTP for Sign In.", "Completed Log In.");
                return "Check your email OTP has been sent!";

            }
            catch (Exception ex)
            {
                return $" Can't SignIn Try Again{ex.Message}";
            }
        }

        public async Task<string> SignUp(RegistrationDTO input)
        {
            User user = new User();
            if (!ValidationHelpers.IsValidEmail(input.Email) || !ValidationHelpers.IsValidEmail(input.Password))
            {
                return $"Not Valid Email or Password";
            }
            if (!ValidationHelpers.IsValidName(input.firstname) || !ValidationHelpers.IsValidName(input.lastname))
            {
                return $"Not Valid FirstName or LastName";
            }
            if (!ValidationHelpers.IsValidatteBirthDate(input.BirthDate))
            {
                return $"Not Birthdate";
            }
            user.Email = input.Email;
            user.Password = input.Password;
            user.FirstName = input.firstname;
            user.LastName = input.lastname;
            user.CreatedBy = "System";
            user.CreationDate = DateTime.Now;

            Random random = new Random();
            var otp = random.Next(1111, 9999);
            user.OTP = otp.ToString();

            user.ExpireOTP = DateTime.Now.AddMinutes(10);
            _foodtekDbContext.Users.Add(user);
            _foodtekDbContext.SaveChanges();
            // send otp code via email
            _otpBasedOnUserRole.OTPBasedOnUserType(user.Email, "OTP for Sign Up.", "Completed Log Up.");
            return "Verifying Your email using otp";
        }

        public async Task<bool> ResetPersonPassword(ResetPasswordDTO input)
        {
            var user = _foodtekDbContext.Users.Where(u => u.Email == input.Email && u.OTP == input.OTP
            && u.IsLoggedIn == false && u.ExpireOTP > DateTime.Now).SingleOrDefault();
            if (user == null)
            {
                return false;
            }
            if (input.Password != input.ConfirmPassword)
            {
                return false;
            }
            user.OTP = null;
            user.ExpireOTP = null;

            _foodtekDbContext.Update(user);
            _foodtekDbContext.SaveChanges();

            return true;
        }

        public async Task<string> Verification(VerificationInputDTO input)
        {
            var user = _foodtekDbContext.Users.Where(u => u.Email == input.Email && u.OTP == input.OTPCode
            && u.IsLoggedIn == false && u.ExpireOTP > DateTime.Now).SingleOrDefault();
            if (user == null)
            {
                return "User not found";
            }

            if (input.IsSignup)
            {
                user.IsVerified = true;
                user.ExpireOTP = null;
                user.OTP = null;
                _foodtekDbContext.Update(user);
                _foodtekDbContext.SaveChanges();
                return "Your Account Is Verifyed";
            }
            else
            {
                user.LastLoggedIn = DateTime.Now;
                user.IsLoggedIn = true;
                user.ExpireOTP = null;
                user.OTP = null;

                _foodtekDbContext.Update(user);
                _foodtekDbContext.SaveChanges();
                string jwtToken = _tokenProvider.CreateToken(user);
                return jwtToken;
            }
        }
    }
}
