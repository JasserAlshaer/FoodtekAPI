using System.Data;
using FoodtekAPI.DTOs.SignIns.Request;
using FoodtekAPI.DTOs.SignIns.Response;
using FoodtekAPI.Helpers.ValidationFields;
using FoodtekAPI.Models;
using FoodtekAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace FoodtekAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ItemService _itemService;
        private readonly GetTopRecommendedItemService _getTopRecommendedItemService;

        public AuthController(ItemService itemService, GetTopRecommendedItemService getTopRecommendedItemService)
        {
            _itemService = itemService;
            _getTopRecommendedItemService = getTopRecommendedItemService;
        }
       

        [HttpPost("[action]")]
        // [Route("SignIn")]
        public async Task<IActionResult> SignIn(SignInInputDTO input)
        {
            var response = new SignInOutputDTO();
            try
            {
                if (!ValidationHelpers.IsValidatePassword(input.Password) && ValidationHelpers.IsValidEmail(input.Email))
                    throw new Exception("Email or Password are required");
                string historicalConnectionstring = "Data Source=DESKTOP-L9JMAV8\\SQLEXPRESS;Initial Catalog=\"Restarant DB (1).bacpac\";Integrated Security=True;Trust Server Certificate=True";

                SqlConnection connection = new SqlConnection(historicalConnectionstring);
                string Query = $"Select ID,Name From Users where Email={input.Email}'' And Password='{input.Password}'";
                SqlCommand command = new SqlCommand(Query, connection);
                command.CommandType = System.Data.CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                //mapping
                if (dataTable.Rows.Count == 0)
                    throw new Exception("Invalid Email / Password");
                if (dataTable.Rows.Count > 0)
                    throw new Exception("Query contains more than one element");
                foreach (DataRow row in dataTable.Rows)
                {
                    response.ID = Convert.ToInt32(row["ID"]);
                    response.Name = row["Name"].ToString();
                }
                return Ok(response);
            }
            catch (Exception Ex)
            {
                return StatusCode(500, $"An Error was occured {Ex.Message}");
            }


        }


        [HttpPut("[action]")]
        
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO input)
        {
            try
            {
                if (!ValidationHelpers.IsValidatePassword(input.Password) || !ValidationHelpers.IsValidEmail(input.Email))
                    throw new Exception("Email or Password are not valid");

                string connectionString = "Data Source=DESKTOP-L9JMAV8\\SQLEXPRESS;Initial Catalog=\"Restarant DB (1).bacpac\";Integrated Security=True;Trust Server Certificate=True";

                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;
                command.CommandTimeout = 20;
                command.CommandText = $"UPDATE Users SET Password = @Password WHERE Email =@Email";
                command.Parameters.AddWithValue("@Password", input.Password);
                command.Parameters.AddWithValue("@Email", input.Email);
                connection.Open();
                var result = command.ExecuteNonQuery();
                connection.Close();
                if (result > 0)
                    return StatusCode(200, "Password Reset Success");
                else
                    return StatusCode(404, "No user found with this email");



            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }
        //[HttpPost]
        [HttpPost("[action]")]
      

        public async Task<IActionResult> Registration([FromBody] RegistrationDTO input)
        {

            try
            {
                if (!ValidationHelpers.IsValidEmail(input.Email) || ValidationHelpers.IsValidatePassword(input.Password) || ValidationHelpers.IsValidPhone(input.Phonenum)
                    || ValidationHelpers.IsValidName(input.firstname) || !ValidationHelpers.IsValidatteBirthDate(input.BirthDate))
                   throw new Exception("Email or Password are not valid");
                
                    string connectionString = "Data Source=DESKTOP-L9JMAV8\\SQLEXPRESS;Initial Catalog=\"Restarant DB (1).bacpac\";Integrated Security=True;Trust Server Certificate=True";

                    SqlConnection connection = new SqlConnection(connectionString);

                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;
                    command.CommandTimeout = 20;
                    command.CommandText = $"INSERT INTO Users [firstname].[Email].[BirthDate].[Phonenum].[Password]VALUSE('{input.firstname}','{input.lastname}','{input.Email}','{input.Phonenum}','{input.Password}','{input.BirthDate}')";

                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result > 0)
                        return StatusCode(201, "Account is created");
                    else
                        return StatusCode(404, "failed to create account");

                
                return StatusCode(404, "failed to create account");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"an error was occured {ex.Message}");
            }

        }
        [HttpGet("top-rated-items")]
        public async Task<IActionResult> GetTopRatedItems()
        {
            var result = await _itemService.GetTopRatedItemsAsync();
            return Ok(result);
        }

        [HttpGet("top-recommended-items")]
        public async Task<IActionResult> GetTopRecommendedItems()
        {
            var result = await _getTopRecommendedItemService.GetTopRecommendedItemsAsync();
            return Ok(result);
        }



    }
}
    



   