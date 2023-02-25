using Microsoft.Extensions.DependencyInjection;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Pages.Home;
using SolidFoundation.Foundation.Foundation.Models.BaseModels;

namespace SolidFoundation.Feature.SiteDemo1;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSiteDemo1(this IServiceCollection services)
    {
        services.Scan(scan => scan.FromAssemblyOf<HomePage>().AddClasses().AsMatchingInterface().WithScopedLifetime());
        return services;
    }
}