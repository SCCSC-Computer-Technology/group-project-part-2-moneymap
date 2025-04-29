namespace MoneyMap.wwwroot
using Microsoft.EntityFrameworkCore;

public class UsersDbContext : DbContext
{
    public DbSet<User> Users { get; set; }  // Connects to your Users table

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=users;Trusted_Connection=True;");
    }
}