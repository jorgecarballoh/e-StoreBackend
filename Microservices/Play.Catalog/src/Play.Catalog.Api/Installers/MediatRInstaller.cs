
using Play.Catalog.Aplication.Features.Items.Commands.CreateItem;
using Play.Catalog.Aplication.Features.Items.Queries.GetItemById;

namespace Play.Catalog.Api.Installers
{
    public class MediatRInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(c => c.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        }
    }
}

