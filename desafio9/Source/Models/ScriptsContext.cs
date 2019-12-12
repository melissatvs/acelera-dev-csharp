using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Models
{
    public class ScriptsContext : DbContext
    {
        public virtual DbSet<Quote> Quotes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=scripts.db");
        }
    }
}