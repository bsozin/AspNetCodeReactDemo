using AutoMapper;

namespace AspNetCodeReact.Services.Mapping
{
    /// <summary>
    /// Настройки маппинга моделей
    /// </summary>
    internal sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Data.Models.Brand, DTO.NamedId>();

            CreateMap<Data.Models.BodyType, DTO.NamedId>();

            CreateMap<Data.Models.Car, DTO.Car>();

            CreateMap<DTO.UpdateCarRequest, Data.Models.Car>()
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ForMember(dst => dst.BodyTypeId, opt => opt.MapFrom(src => src.BodyTypeId))
                .ForMember(dst => dst.BrandId, opt => opt.MapFrom(src => src.BrandId))
                .ForMember(dst => dst.DealerUrl, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.DealerUrl) ? null : src.DealerUrl))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.SeatsCount, opt => opt.MapFrom(src => src.SeatsCount))
                .ForMember(dst => dst.BodyType, opt => opt.Ignore())
                .ForMember(dst => dst.Brand, opt => opt.Ignore())
                .ForMember(dst => dst.CreationDate, opt => opt.Ignore());
        }
    }
}
