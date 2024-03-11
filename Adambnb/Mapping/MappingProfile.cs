namespace Adambnb.Mapping
{
    using AutoMapper;
    using Adambnb.Models;
    using Adambnb.DTOs;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Location, LocationDTO>()
                .ForMember(dest => dest.ImageURL, opt => opt.MapFrom(src => GetCoverImageUrl(src.Images)))
                .ForMember(dest => dest.LandlordAvatarURL, opt => opt.MapFrom(src => src.LandLord.Avatar.Url));
        }

        private string GetCoverImageUrl(List<Image> images)
        {
            var coverImage = images.FirstOrDefault(img => img.IsCover);
            return coverImage?.Url;
        }
    }

}
