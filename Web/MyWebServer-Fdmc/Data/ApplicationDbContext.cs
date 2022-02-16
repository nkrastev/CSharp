namespace Fdmc.Data
{
    using Fdmc.Data.Models;    
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    { 
        public DbSet<User> Users { get; set; }      
        public DbSet<Kitten> Kittens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            base.OnModelCreating(modelBuilder);
        }
    }
}
