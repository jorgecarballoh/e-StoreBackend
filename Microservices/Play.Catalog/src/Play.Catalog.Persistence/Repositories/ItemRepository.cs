using MongoDB.Driver;
using Play.Catalog.Domain;
using Play.Catalog.Domain.ValueObjects;
using Play.Catalog.Domain.Items;

namespace Play.Catalog.Persistence.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private const string _collectionName = "items";
        private readonly IMongoCollection<Item> _dbCollection;
        private readonly FilterDefinitionBuilder<Item> _filterBuilder = Builders<Item>.Filter;

        public ItemRepository()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("Catalog");
            _dbCollection = database.GetCollection<Item>(_collectionName);
        }

        public async Task CreateAsync(Item item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            await _dbCollection.InsertOneAsync(item);
        }

        public async Task<IReadOnlyCollection<Item>> GetAllAsync()
        {
            IReadOnlyCollection<Item> items = await _dbCollection.Find(_filterBuilder.Empty).ToListAsync();
            return items;
        }

        public async Task<IItem> GetAsync(ItemId itemId)
        {
            FilterDefinition<Item> filter = _filterBuilder.Eq(entity => entity.ItemId, itemId);

            var item = await _dbCollection.Find(filter).SingleOrDefaultAsync();

            if (item is null) return ItemNull.Instance;

            return item;
        }
    }
}

