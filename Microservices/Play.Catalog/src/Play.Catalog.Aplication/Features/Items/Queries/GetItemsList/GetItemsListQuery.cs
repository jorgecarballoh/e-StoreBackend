using MediatR;
using Play.Catalog.Aplication.Features.Items.Dtos;

namespace Play.Catalog.Aplication.Features.Items.Queries.GetItemsList
{
    public record GetItemsListQuery : IRequest<IEnumerable<ItemDto>>;
}