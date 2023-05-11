using System;
using MediatR;
using Play.Catalog.Aplication.Features.Items.Dtos;

namespace Play.Catalog.Aplication.Features.Items.Commands.CreateItem
{
    public record CreateItemCommand(string Name, string Description, decimal Price): IRequest<ItemDto>;
}

