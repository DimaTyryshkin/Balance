using Microsoft.EntityFrameworkCore;

namespace Balance.Models
{
    public class SQLiteContext : DbContext
    {
        public DbSet<Operation> Operations { get; set; }

        public SQLiteContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=SQLite.db");
        } 
    }
}
