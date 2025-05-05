using FoodtekAPI.DTOs.SignIns.Request;
using FoodtekAPI.Interfaces;
using FoodtekAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace FoodtekAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthEFController : ControllerBase
    {
        private readonly ItemService _itemService;
        private readonly GetTopRecommendedItemService _getTopRecommendedItemService;
        private readonly  AuthenticationService _authenticationService;
        private readonly IAuthantication _IAuthentication;

        public AuthEFController(ItemService itemService, GetTopRecommendedItemService getTopRecommendedItemService, 
            AuthenticationService authenticationService, IAuthantication IAuthentication)
        {
            _itemService = itemService;
            _getTopRecommendedItemService = getTopRecommendedItemService;
            _authenticationService = authenticationService;
            _IAuthentication = IAuthentication;
        }

        public async Task<IActionResult> SignIn(SignInInputDTO input)
        {
            try
            {
                var token = await _authenticationService.SignIn(input);
                if (string.IsNullOrEmpty(token) || token == "User not found")
                    return Unauthorized(new { message = "Invalid credentials." });

                return Ok(new { token = token });
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        public async Task<IActionResult> SignUp(RegistrationDTO input) {

            try
            {
                var token= await _authenticationService.SignUp(input);
                return Ok(token);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        public async Task<IActionResult> ResetPassword(ResetPasswordDTO input)
        {
            try
            {
                await _authenticationService.ResetPersonPassword(input);
                return Ok(200);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

    }
}

