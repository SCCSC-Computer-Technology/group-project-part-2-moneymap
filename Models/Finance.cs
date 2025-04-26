//Group 2 MoneyMap
//Money Budget App

using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyMap.Models
{
    public class Finance
    {
        public int Id { get; set; }

        // Foreign key (from User table)
        public int UserId { get; set; }     // This will show the relationship to User table
        public decimal Purchases { get; set; }
        public decimal Withdrawals { get; set; }
        public decimal Deposits { get; set; }
        public decimal SavingGoal { get; set; }

        //[ForeignKey("UserId")]
        public User User { get; set; }      // This connects back to the User class
    }

}
