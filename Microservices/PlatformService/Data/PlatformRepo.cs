namespace PlatformService.Data
{
    using PlatformService.Models;
    using System.Collections.Generic;

    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _dbContext;

        public PlatformRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreatePlatform(Platform platform)
        {
            // check if exists
            if (platform == null)
            {
                throw new ArgumentNullException("Plaform is null");
            }
            else
            {
                _dbContext.Platforms.Add(platform);                
            }
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _dbContext.Platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
            return _dbContext.Platforms.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_dbContext.SaveChanges()>=0);
        }
    }
}
