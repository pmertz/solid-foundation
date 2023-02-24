using NSubstitute;
using SolidFoundation.Foundation.Foundation.Components.Metadata.Services;
using SolidFoundation.Foundation.Foundation.Models.BaseModels;
using SolidFoundation.Foundation.Foundation.Models.Blocks.MetaData;
using Xunit;

namespace SolidFoundation.Foundation.Test.Foundation.Components.Metadata.Services;

public class MetadataViewModelFactoryTests
{
    [Fact]
    public void Create_ShouldReturnViewModel()
    {
        var pageDescription = "This is a unit test";
        var sut = new MetadataViewModelFactory();

        var testPageMock = Substitute.For<SitePage>();
        testPageMock.PageName.Returns("Page name");
        testPageMock.MetaData.Returns(new MetaDataBlock()
        {
            Description = pageDescription,
            MetaRobots = "index, follow"
        });
        var viewModel = sut.Create(testPageMock);

        Assert.Equal(pageDescription, viewModel.PageDescription);
        Assert.Equal("Page name", viewModel.PageTitle);
        Assert.Equal("index, follow", viewModel.MetaRobots);
    }

    [Fact]
    public void GivenMetaRobotsIsNull_Create_ShouldReturnViewModel()
    {
        var pageDescription = "This is a unit test";
        var sut = new MetadataViewModelFactory();

        var testPageMock = Substitute.For<SitePage>();
        testPageMock.PageName.Returns("Page name");
        testPageMock.MetaData.Returns(new MetaDataBlock()
        {
            Description = pageDescription,
            MetaRobots = ""
        });
        var viewModel = sut.Create(testPageMock);

        Assert.Equal(pageDescription, viewModel.PageDescription);
        Assert.Equal("Page name", viewModel.PageTitle);
        Assert.True(string.IsNullOrEmpty(viewModel.MetaRobots));
    }
}