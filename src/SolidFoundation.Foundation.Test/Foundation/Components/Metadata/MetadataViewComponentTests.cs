using System.Threading.Tasks;
using EPiServer.Core;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using NSubstitute;
using SolidFoundation.Foundation.Foundation.Components.Metadata;
using SolidFoundation.Foundation.Foundation.Components.Metadata.Services;
using SolidFoundation.Foundation.Foundation.Models.BaseModels;
using SolidFoundation.Foundation.Foundation.Models.Blocks.MetaData;
using SolidFoundation.Foundation.Foundation.Models.ViewModels;
using Xunit;

namespace SolidFoundation.Foundation.Test.Foundation.Components.Metadata;

public class MetadataViewComponentTests
{
    [Fact]
    public async Task InvokeAsync_GivenPageIsNotSitePage_ReturnEmptyContent()
    {
        //arrange
        var sut = new MetadataViewComponent(Substitute.For<IMetadataViewModelFactory>());
        var testPageMock = Substitute.For<PageData>();
        var viewModelMock = Substitute.For<IContentViewModel<PageData>>();
        viewModelMock.CurrentContent.Returns(testPageMock);

        //act
        var result = await sut.InvokeAsync(viewModelMock);

        //assert
        var viewResult = Assert.IsType<ContentViewComponentResult>(result);
        Assert.Empty(viewResult.Content);
    }

    [Fact]
    public async Task InvokeAsync_ReturnsViewComponentResultWithViewModel()
    {
        //arrange
        var metadataViewModelFactory = Substitute.For<IMetadataViewModelFactory>();
        metadataViewModelFactory.Create(Arg.Any<SitePage>()).Returns(new MetadataViewModel("Some Test Page Title"));
        var sut = new MetadataViewComponent(metadataViewModelFactory);
        var testPageMock = Substitute.For<SitePage>();
        testPageMock.MetaData.Returns(new MetaDataBlock()
            { Description = "This is a unit test" });
        var viewModelMock = Substitute.For<IContentViewModel<SitePage>>();
        viewModelMock.CurrentContent.Returns(testPageMock);

        //act
        var result = await sut.InvokeAsync(viewModelMock);

        //assert
        var viewResult = Assert.IsType<ViewViewComponentResult>(result);
        Assert.NotNull(viewResult);
        Assert.IsType<MetadataViewModel>(viewResult.ViewData.Model);
    }
}