using System;
namespace Play.Catalog.Aplication.Features.Items.Dtos
{
    public record ItemDto(Guid Id, string Name, string Description, decimal Price, DateTimeOffset DateCreated);
}

