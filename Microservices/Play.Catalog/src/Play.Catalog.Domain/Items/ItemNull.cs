using Play.Catalog.Domain.ValueObjects;

namespace Play.Catalog.Domain.Items
{
    public sealed class ItemNull : IItem
    {
        public static ItemNull Instance { get; } = new ItemNull();
        public ItemId ItemId => new ItemId(Guid.Empty);
        public string? Name { get; } = string.Empty;
        public string? Description { get; } = string.Empty;
        public decimal Price { get; } = decimal.MinValue;
        public DateTimeOffset CreatedDate { get; } = DateTimeOffset.MinValue;
    }
}