using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Xunit;

namespace SolidFoundation.Feature.SiteDemo1.Test;

public class ServiceCollectionExtensionsTests
{
    [Fact]
    public void AddFoundation_Ok()
    {
        //arrange
        var serviceCollectionMock = Substitute.For<IServiceCollection>();

        //act
        serviceCollectionMock.AddSiteDemo1();

        //assert
        serviceCollectionMock.Received().Add(Arg.Any<ServiceDescriptor>());
    }
}