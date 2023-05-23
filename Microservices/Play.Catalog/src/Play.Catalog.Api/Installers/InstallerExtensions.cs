namespace Play.Catalog.Api.Installers
{
    public static class InstallerExtensions
    {
        public static void InstallServicesFromAssemblyContaining<T>(this IServiceCollection services, IConfiguration configuration)
        {
            var installers = typeof(T).Assembly.ExportedTypes
                .Where(x => typeof(IInstaller).IsAssignableFrom(x) && x is { IsInterface: false, IsAbstract: false })
                .Select(Activator.CreateInstance).Cast<IInstaller>().ToList();

            installers.ForEach(installer => installer.InstallServices(services, configuration));
        }
    }
}

