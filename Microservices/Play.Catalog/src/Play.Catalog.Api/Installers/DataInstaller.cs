
using Play.Catalog.Api.Domain.Items;
using Play.Common.MongoDB;

namespace Play.Catalog.Api.Installers
{
    public class DataInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAMongo().AddMongoRepository<Item>("items");
        }
    }
}

