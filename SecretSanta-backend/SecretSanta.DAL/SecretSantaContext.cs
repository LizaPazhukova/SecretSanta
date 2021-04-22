using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace SecretSanta.DAL
{
    public class SecretSantaContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public SecretSantaContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=SecretSantadb;Trusted_Connection=True;");
        }
    }
}
