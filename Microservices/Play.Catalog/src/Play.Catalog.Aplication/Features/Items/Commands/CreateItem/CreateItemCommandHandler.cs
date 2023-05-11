using System;
using AutoMapper;
using MediatR;
using Play.Catalog.Aplication.Features.Items.Dtos;
using Play.Catalog.Domain.Items;
using Play.Catalog.Persistence.Repositories;

namespace Play.Catalog.Aplication.Features.Items.Commands.CreateItem
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, ItemDto>
    {
        private readonly ItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public CreateItemCommandHandler(ItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<ItemDto> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var itemDto = _mapper.Map<ItemDto>(request);
            var item = _mapper.Map<Item>(itemDto);
            await _itemRepository.CreateAsync(item);
            return itemDto;
        }
    }
}

