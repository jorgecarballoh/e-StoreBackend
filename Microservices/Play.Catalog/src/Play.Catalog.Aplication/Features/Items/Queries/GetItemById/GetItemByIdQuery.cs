using System;
using MediatR;
using Play.Catalog.Aplication.Features.Items.Dtos;

namespace Play.Catalog.Aplication.Features.Items.Queries.GetItemById
{
    public record GetItemByIdQuery(Guid Id) : IRequest<ItemDto>;
}

