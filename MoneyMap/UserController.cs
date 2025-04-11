using Microsoft.AspNetCore.Mvc;
using MoneyMap.Data;

namespace MoneyMap
{
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("api/login")]
        public IActionResult Login([FromBody] Microsoft.AspNetCore.Identity.Data.LoginRequest request)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == request.Email && u.Password == request.Password);
            if (user == null)
            {
                return Unauthorized("Invalid email or password.");
            }
            return Ok("Login successful.");
        }
    }
}
