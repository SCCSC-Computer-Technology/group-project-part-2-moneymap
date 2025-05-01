//Group 2 MoneyMap
//Budget Project

using Microsoft.EntityFrameworkCore;
using MoneyMap.Models;  

namespace MoneyMap.Data
{

    // I combined the Context.cs with this one for efficiency
    // Do we need to add one for login table?
    public class MoneyMapDbContext : DbContext
    {
        public MoneyMapDbContext(DbContextOptions<MoneyMapDbContext> options)
            : base(options)
        {
        }

        // This is the DbSet for the User class where we can perform CRUD operations
        public DbSet<User> Users { get; set; }

        // DbSet for Login table
        public DbSet<Login> Logins { get; set; }

        // This is the DbSet for the Finance class where we can perform CRUD operations
        public DbSet<Finance> Finances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Table names
            modelBuilder.Entity<User>().ToTable("Users");       
            modelBuilder.Entity<Finance>().ToTable("Finances"); 
            modelBuilder.Entity<Login>().ToTable("Logins");

            // decimal precision ('purchases')
            modelBuilder.Entity<Finance>()
            .Property(f => f.Purchases)
            .HasColumnType("DECIMAL(18, 2)");

            // decimal precision ('withdrawals')
            modelBuilder.Entity<Finance>()
                .Property(f => f.Withdrawals)
                .HasColumnType("DECIMAL(18, 2)");

            // decimal precision ('deposits')
            modelBuilder.Entity<Finance>()
                .Property(f => f.Deposits)
                .HasColumnType("DECIMAL(18, 2)");

            // decimal precision ('SavingGoal')
            modelBuilder.Entity<Finance>()
                .Property(f => f.SavingGoal)
                .HasColumnType("DECIMAL(18, 2)");
        }
    }
}

