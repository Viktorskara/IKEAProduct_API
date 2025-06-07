using AutoMapper;
using IKEAProduct_API.Models;
using IKEAProduct_API.Models.Dto;
using IKEAProduct_API.Models.Dto.ReadDTO;

namespace IKEAProduct_API.Config
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {

            CreateMap<Product, ProductListItemDto>()
            .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.ProductType))
            .ForMember(dest => dest.Colours, opt => opt.MapFrom(src => src.ProductColours.Select(pc => pc.Colour)));


            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.Colours, opt => opt.Ignore())
                .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.ProductType))
                .AfterMap((src, dest) =>
                {
                    dest.Colours = src.ProductColours != null
                    ? src.ProductColours
                        .Where(pc => pc.Colour != null)
                        .Select(pc => new ColourDTO
                        {
                            Id = pc.Colour.Id,
                            Name = pc.Colour.Name
                        }).ToList()
                    : new List<ColourDTO>();
                });


            CreateMap<ProductType, ProductTypeDTO>();
            CreateMap<Colour, ColourDTO>();

            CreateMap<ProductCreateDTO, Product>()
                .ForMember(dest => dest.ProductColours, opt => opt.MapFrom(
                    src => src.ColourIds.Select(id => new ProductColour { ColourId = id })));

            

        }
    }
}
