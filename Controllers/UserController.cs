//Group 2 MoneyMap
//Money Budget App

using Microsoft.AspNetCore.Mvc;
using MoneyMap.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using MoneyMap.Data;
using System.Linq;

namespace MoneyMap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MoneyMapDbContext _context;

        public UserController(MoneyMapDbContext context)
        {
            _context = context;
        }

        // POST: api/User/register
        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string password)
        {
            // Check if username already exists
            if (await _context.Users.AnyAsync(u => u.Username == username))
                return BadRequest("Username already exists. Please try again.");

            // Hash password using SHA-256
            var passwordHash = HashPassword(password);

            var user = new User
            {
                Username = username,
                PasswordHash = passwordHash
            };

            // Save user to the database
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("User registration successful!");
        }

        // Hashing the password using SHA-256
        private static string HashPassword(string password)
        {
            // Create SHA-256 hash
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes); // Convert byte array to Base64 string
        }

        // POST: api/User/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            // Retrieve user by username
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null)
                return Unauthorized("Invalid username or password.");

            // Compare the hashed password
            if (user.PasswordHash != HashPassword(password))
                return Unauthorized("Invalid username or password.");

            return Ok("Login successful.");
        }        
    }
}


