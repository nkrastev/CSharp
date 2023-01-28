namespace PlatformService.Profiles
{
    using AutoMapper;
    using PlatformService.Dtos;
    using PlatformService.Models;

    public class PlatformsProfile : Profile
    {
        public PlatformsProfile()
        {
            CreateMap<Platform, PlatformReadDto>();
        }
    }
}
