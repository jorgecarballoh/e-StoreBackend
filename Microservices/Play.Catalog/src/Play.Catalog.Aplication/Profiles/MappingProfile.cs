using System;
using AutoMapper;
using Play.Catalog.Aplication.Features.Items.Dtos;
using Play.Catalog.Aplication.Features.Items.Queries.GetItemsList;
using Play.Catalog.Domain.Items;

namespace Play.Catalog.Aplication.Profiles
{
	public class MappingProfile : Profile
    {
		public MappingProfile()
		{
			CreateMap<Item, ItemDto>();
        }
	}
}

