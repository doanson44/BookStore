using AutoMapper;
using Microsoft.BookStore.ApplicationCore.Entities;
using Microsoft.BookStore.PublicApi.CatalogBrandEndpoints;
using Microsoft.BookStore.PublicApi.CatalogItemEndpoints;
using Microsoft.BookStore.PublicApi.CatalogTypeEndpoints;

namespace Microsoft.BookStore.PublicApi;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CatalogItem, CatalogItemDto>();
        CreateMap<CatalogType, CatalogTypeDto>()
            .ForMember(dto => dto.Name, options => options.MapFrom(src => src.Type));
        CreateMap<CatalogBrand, CatalogBrandDto>()
            .ForMember(dto => dto.Name, options => options.MapFrom(src => src.Brand));
    }
}
