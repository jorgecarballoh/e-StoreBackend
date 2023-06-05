using System;
using AutoMapper;
using Play.Catalog.Api.Profiles;

namespace Play.Catalog.Api.Installers
{
    public class MapperInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
        }
    }
}

