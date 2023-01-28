namespace PlatformService.Data
{
    using PlatformService.Models;

    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using ( var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext dbContext)
        {
            if(!dbContext.Platforms.Any())
            {
                // Seed data

                Console.WriteLine("Seeding data.");

                dbContext.Platforms.AddRange(
                    new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "JavaScript", Publisher = "Netscape", Cost = "Free"},
                    new Platform() { Name = "PHP", Publisher = "Rasmus Lerdorf", Cost = "Free" },
                    new Platform() { Name = "MSSQL Server Developer", Publisher = "Microsoft", Cost = "Free"},
                    new Platform() { Name = "MySQL Server", Publisher = "Oracle", Cost = "Free"},
                    new Platform() { Name = "Java", Publisher = "Oracle Corporation", Cost = "Free"}
                    );
            }
            else
            {
                //Do nothing, there is already data.
                Console.WriteLine("There is data in context.");
            }
        }
    }
}
