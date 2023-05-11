using Play.Catalog.Domain.ValueObjects;

namespace Play.Catalog.Domain.Items
{
    public interface IItem
    {
        ItemId ItemId { get; }
    }
}