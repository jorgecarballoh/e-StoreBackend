using MediatR;
using Play.Catalog.Aplication.Features.Items.Dtos;
using Play.Catalog.Aplication.Features.Items.Queries.GetItemById;
using Play.Catalog.Aplication.Features.Items.Queries.GetItemsList;
using Play.Catalog.Persistence.Repositories;

namespace Play.Catalog.Api.Installers
{
    public class DataInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ItemRepository>();
            services.AddTransient<IRequestHandler<GetItemsListQuery, IEnumerable<ItemDto>>, GetItemsListQueryHandler>();
            services.AddTransient<IRequestHandler<GetItemByIdQuery, ItemDto>, GetItemByIdQueryHandler>();
        }
    }
}

