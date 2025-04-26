using Microsoft.AspNetCore.Mvc;
using MoneyMap.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using MoneyMap.Data;
using System.Threading.Tasks;

namespace MoneyMap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly MoneyMapDbContext _context;

        public UserLoginController(MoneyMapDbContext context)
        {
            _context = context;
        }

        // POST: api/Login/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            // Step 1: Check if the user exists by the provided username
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

            // Step 2: If user not found, return Unauthorized status
            if (user == null)
                return Unauthorized("Invalid username or password.");

            // Step 3: Compare the hashed password from the database with the provided password
            if (user.PasswordHash != HashPassword(password))
                return Unauthorized("Invalid username or password.");

            // Step 4: If authentication is successful, return success message
            return Ok("Login successful.");
        }

        // Helper method to hash the password using SHA-256
        private static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}

