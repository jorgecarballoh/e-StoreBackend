namespace Play.Catalog.Domain.ValueObjects
{
    public readonly struct ItemId : IEquatable<ItemId>
    {
        public Guid Id { get; }
        public ItemId(Guid id) => this.Id = id;

        public override bool Equals(object? obj) => obj is ItemId o && this.Equals(o);

        public bool Equals(ItemId other) => this.Id == other.Id;

        public override int GetHashCode() => HashCode.Combine(this.Id);
        public static bool operator ==(ItemId left, ItemId right) => left.Equals(right);

        public static bool operator !=(ItemId left, ItemId right) => !(left == right);

        public override string ToString() => this.Id.ToString();
    }
}