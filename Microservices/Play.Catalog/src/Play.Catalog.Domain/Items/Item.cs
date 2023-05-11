using Play.Catalog.Domain.ValueObjects;

namespace Play.Catalog.Domain.Items
{
    public class Item : IItem
    {
        public Item(ItemId itemId, string? name, string? description, decimal price, DateTimeOffset createdDate)
        {
            ItemId = itemId;
            Name = name;
            Description = description;
            Price = price;
            CreatedDate = createdDate;
        }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public ItemId ItemId { get; }
    }
}