namespace PlatformService.Data
{
    using Microsoft.EntityFrameworkCore;
    using PlatformService.Models;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base (options)
        {

        }

        public DbSet<Platform> Platforms { get; set; }

    }
}
