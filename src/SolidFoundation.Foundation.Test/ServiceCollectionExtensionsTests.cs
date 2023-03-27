using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Xunit;

namespace SolidFoundation.Foundation.Test;

public class ServiceCollectionExtensionsTests
{
    [Fact]
    public void AddFoundation_Ok()
    {
        //arrange
        var serviceCollectionMock = Substitute.For<IServiceCollection>();

        //act
        serviceCollectionMock.AddFoundation();

        //assert
        serviceCollectionMock.Received().Add(Arg.Any<ServiceDescriptor>());
    }
}