using System;
using Play.Catalog.Aplication.Profiles;

namespace Play.Catalog.Api.Installers
{
    public class AutoMapperInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
        }
    }
}

