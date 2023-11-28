using Microsoft.Extensions.DependencyInjection;
using SolidFoundation.Foundation.OptimizelyExtensions.Validation.ContentAreaItemRange;

namespace SolidFoundation.Foundation.OptimizelyExtensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOptimizelyExtensions(this IServiceCollection services)
    {
        services
            .AddScoped<IContentAreaItemRangePropertyValidationService, ContentAreaItemRangePropertyValidationService>();
        return services;
    }
}