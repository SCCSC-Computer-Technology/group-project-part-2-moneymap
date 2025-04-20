using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Configuration;

namespace MoneyMap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] RegisterController.LoginModel loginModel)
        {
            try
            {
                string connectionString = "Server=(localdb)\\mssqllocaldb;AttachDbFilename=|DataDirectory|\\users.mdf;Integrated Security=True;";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email AND Password = @Password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", loginModel.Email);
                        cmd.Parameters.AddWithValue("@Password", loginModel.Password);

                        int result = (int)cmd.ExecuteScalar();
                        return Ok(new { success = result > 0 });
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"SQL Error: {sqlEx.Message}");
                return StatusCode(500, new { success = false, message = "Database error occurred." });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
                return StatusCode(500, new { success = false, message = "An internal server error occurred." });
            }
        }
    }
    public class RegisterController : ControllerBase
    {
        private readonly string _connectionString;

        public RegisterController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        [HttpPost]
        public IActionResult Post([FromForm] string email, [FromForm] string password)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Users (Email, Password) VALUES (@Email, @Password)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            return Ok("User registered.");
        }
        public class LoginModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}
