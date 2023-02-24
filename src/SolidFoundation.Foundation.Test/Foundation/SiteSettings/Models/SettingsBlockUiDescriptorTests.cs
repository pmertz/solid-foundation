using EPiServer.DataAbstraction;
using EPiServer.ServiceLocation;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using SolidFoundation.Foundation.Foundation.SiteSettings.Models;
using Xunit;

namespace SolidFoundation.Foundation.Test.Foundation.SiteSettings.Models;

public class SettingsBlockUiDescriptorTests
{
    [Fact]
    public void Constructor_WithoutArguments_Succeeds()
    {
        var services = new ServiceCollection();
        ServiceCollectionServiceExtensions.AddScoped<IContentTypeRepository>(services, _ => Substitute.For<IContentTypeRepository>());
        ServiceLocator.SetScopedServiceProvider(services.BuildServiceProvider());

        var sut = new SettingsBlockUiDescriptor();

        Assert.NotNull(sut);
    }
}