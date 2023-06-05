using System;
using AutoMapper;
using Play.Catalog.Api.Domain.Items;
using Play.Catalog.Api.Dtos;

namespace Play.Catalog.Api.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Item, ItemDto>().ReverseMap();
            CreateMap<CreateItemDto, Item>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src=> Guid.NewGuid()))
                .ForMember(dest=>dest.CreatedDate,opt => opt.MapFrom(src=> DateTimeOffset.UtcNow))
                .ReverseMap();
            CreateMap<ItemDto, CreateItemDto>().ReverseMap();
            CreateMap<UpdateItemDto, Item>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price)).ReverseMap();
        }
    }
}

