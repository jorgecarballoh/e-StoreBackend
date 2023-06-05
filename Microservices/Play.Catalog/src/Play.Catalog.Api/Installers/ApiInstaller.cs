
namespace Play.Catalog.Api.Installers
{
    public class ApiInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers(option => {
                option.SuppressAsyncSuffixInActionNames = false;
            });
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}

