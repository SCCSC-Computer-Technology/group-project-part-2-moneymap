using Microsoft.EntityFrameworkCore;

namespace MoneyMap
{
    public class FinanceContext(DbContextOptions<FinanceContext> options) : DbContext(options)
    {
        public DbSet<Finance> Finances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Finance>().ToTable("Finances"); // table name
        }
    }
}
