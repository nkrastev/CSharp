namespace Data
{
    using Data.Models;
    using Microsoft.EntityFrameworkCore;   

    public class ArtilleryContext : DbContext
    {
        public ArtilleryContext() 
        {

        }
        public ArtilleryContext(DbContextOptions options)
            : base(options)
        {

        }

        //DB Sets
        public DbSet<Country> Countries { get; set; }
        public DbSet<Gun> Guns { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Shell> Shells { get; set; }
        public DbSet<CountryGun> CountryGuns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CountryGun>(e =>
            {
                e.HasKey(k => new { k.CountryId, k.GunId });
            });
        }



    }
}
