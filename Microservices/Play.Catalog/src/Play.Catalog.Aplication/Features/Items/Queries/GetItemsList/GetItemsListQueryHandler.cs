using AutoMapper;
using MediatR;
using Play.Catalog.Aplication.Features.Items.Dtos;
using Play.Catalog.Persistence.Repositories;

namespace Play.Catalog.Aplication.Features.Items.Queries.GetItemsList
{
    public class GetItemsListQueryHandler : IRequestHandler<GetItemsListQuery, IEnumerable<ItemDto>>
    {
        private readonly ItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public GetItemsListQueryHandler(ItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ItemDto>> Handle(GetItemsListQuery request, CancellationToken cancellationToken)
        {
            var items = await _itemRepository.GetAllAsync();
            var listOfItems = _mapper.Map<List<ItemDto>>(items);
            return listOfItems;
        }
    }
}