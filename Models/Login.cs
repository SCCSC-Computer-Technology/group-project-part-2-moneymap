//Group 2 MoneyMap
//Money Budget App

namespace MoneyMap.Models
{
    public class Login
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
