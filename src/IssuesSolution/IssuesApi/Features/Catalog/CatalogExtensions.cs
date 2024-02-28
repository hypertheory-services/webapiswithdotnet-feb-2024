namespace IssuesApi.Features.Catalog;

public static class CatalogExtensions
{
    public static IServiceCollection AddCatalogFeature(this IServiceCollection services)
    {
        //services.AddScoped<IManageTheSoftwareCatalog, EntityFrameworkSoftwareCatalogManager>();


        // anything else - more later here.
        // services.AddHostedService<BackgroundSoftwareMonitor>();
        return services;
    }
}
