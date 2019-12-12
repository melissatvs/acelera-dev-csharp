using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Models
{
    public class CodenationContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Acceleration> Accelerations { get; set; }
        public DbSet<Submission> Submissions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=codenation;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<Candidate>().HasKey(c => new { c.UserId, c.AccelerationId, c.CompanyId });
            modelBuilder.Entity<Submission>().HasKey(s => new { s.UserId, s.ChallengeId });


            /* milionesima tentativa e deu errado não entendi esse esquema aqui
             * 
             * coloquei as referencias duplicadas para funcionar esses forceps abaixo e nao vai nem com bomba
             * 
            */           

            modelBuilder.Entity<Challenge>().HasMany(ch => ch.Accelerations).WithOne(ac => ac.Challenge).IsRequired();
            modelBuilder.Entity<Challenge>().HasMany(ch => ch.Submissions).WithOne(su => su.Challenge).IsRequired();

            modelBuilder.Entity<Company>().HasMany(co => co.Candidates).WithOne(ca => ca.Company).IsRequired();

            modelBuilder.Entity<Acceleration>().HasMany(ac => ac.Candidates).WithOne(ca => ca.Acceleration).IsRequired();

            modelBuilder.Entity<User>().HasMany(us => us.Candidates).WithOne(ca => ca.User).IsRequired();
            modelBuilder.Entity<User>().HasMany(us => us.Submissions).WithOne(su => su.User).IsRequired();
        }
    }
}