using Microsoft.Extensions.DependencyInjection;
using SolidFoundation.Foundation.Foundation.Models.BaseModels;

namespace SolidFoundation.Foundation;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFoundation(this IServiceCollection services)
    {
        services.Scan(scan => scan.FromAssemblyOf<SitePage>().AddClasses().AsMatchingInterface().WithScopedLifetime());
        return services;
    }
}