//Group 2 MoneyMap
//Money Budget App

namespace MoneyMap.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }

        // hashed password setup
        public string PasswordHash { get; set; }

        // salt property for password
        public string Salt { get; set; }
    }
}
