using System;
using AutoMapper;
using MediatR;
using Play.Catalog.Aplication.Features.Items.Dtos;
using Play.Catalog.Domain.ValueObjects;
using Play.Catalog.Persistence.Repositories;

namespace Play.Catalog.Aplication.Features.Items.Queries.GetItemById
{
    public class GetItemByIdQueryHandler : IRequestHandler<GetItemByIdQuery, ItemDto>
    {
        private readonly ItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public GetItemByIdQueryHandler(ItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<ItemDto> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
        {
            var dto = await _itemRepository.GetAsync(new ItemId(request.Id));
            var item = _mapper.Map<ItemDto>(dto);
            return item;
        }
    }
}

