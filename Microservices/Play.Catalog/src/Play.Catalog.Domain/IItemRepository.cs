using Play.Catalog.Domain.Items;
using Play.Catalog.Domain.ValueObjects;

namespace Play.Catalog.Domain
{
    public interface IItemRepository
    {
        /// <summary>
        /// Return an item
        /// </summary>
        /// <param name="itemId">Item id</param>
        /// <returns></returns>
        Task<IItem> GetAsync(ItemId itemId);
        /// <summary>
        /// Return a list of items
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyCollection<Item>> GetAllAsync();
    }
}