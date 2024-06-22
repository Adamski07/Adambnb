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
                .ForMember(dest => dest.LandlordAvatarURL, opt => opt.MapFrom(src => src.LandLord.Avatar.Url))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (int)src.Type));

            CreateMap<Location, LocationV2DTO>()
                .ForMember(dest => dest.ImageURL, opt => opt.MapFrom(src => GetCoverImageUrl(src.Images)))
                .ForMember(dest => dest.LandlordAvatarURL, opt => opt.MapFrom(src => src.LandLord.Avatar.Url))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (int)src.Type))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.PricePerDay));

            CreateMap<Location, LocationDTO>();
            CreateMap<Location, LocationDetailsDto>()
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images))
                .ForMember(dest => dest.Landlord, opt => opt.MapFrom(src => src.LandLord));
            CreateMap<Image, ImageDto>();
            CreateMap<LandLord, LandlordDto>();

        }

        private string GetCoverImageUrl(List<Image> images)
        {
            if (images != null && images.Any())
            {
                var coverImage = images.FirstOrDefault(img => img.IsCover);
                return coverImage?.Url;
            }
            return null;
        }
    }

}