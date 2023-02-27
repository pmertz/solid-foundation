using EPiServer.Web.Mvc.Html;
using Microsoft.Extensions.DependencyInjection;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Pages.Home;
using SolidFoundation.Foundation.Infrastructure.Renderes;

namespace SolidFoundation.Feature.SiteDemo1;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSiteDemo1(this IServiceCollection services)
    {
        services.AddScoped<ContentAreaRenderer, CustomContentAreaRenderer>();
        services.Scan(scan => scan.FromAssemblyOf<HomePage>().AddClasses().AsMatchingInterface().WithScopedLifetime());
        return services;
    }
}