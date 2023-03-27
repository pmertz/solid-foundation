using NSubstitute;
using SolidFoundation.Foundation.Foundation.Components.Metadata.Services;
using SolidFoundation.Foundation.Foundation.Models.BaseModels;
using SolidFoundation.Foundation.Foundation.Models.Blocks.MetaData;
using Xunit;

namespace SolidFoundation.Foundation.Test.Foundation.Components.Metadata.Services;

public class MetadataViewModelFactoryTests
{
    [Fact]
    public void Create_GivenMetaDataIsNull_ShouldReturnViewModelWithPageName()
    {
        var sut = new MetadataViewModelFactory();

        var testPageMock = Substitute.For<SitePage>();
        testPageMock.PageName.Returns("Page name");
        testPageMock.MetaData.Returns(default(MetaDataBlock));
        var viewModel = sut.Create(testPageMock);

        Assert.Equal("Page name", viewModel.PageTitle);
    }
    
    [Fact]
    public void Create_GivenMetaDataTitleIsNull_ShouldReturnViewModelWithPageName()
    {
        var sut = new MetadataViewModelFactory();

        var testPageMock = Substitute.For<SitePage>();
        testPageMock.PageName.Returns("Page name");
        testPageMock.MetaData.Returns(new MetaDataBlock()
        {
            Title = null
        });
        var viewModel = sut.Create(testPageMock);

        Assert.Equal("Page name", viewModel.PageTitle);
    }
    
    [Fact]
    public void Create_GivenMetaRobotsIsNull_ShouldReturnViewModel()
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
            MetaRobots = "index, follow",
            Title = "Page Title"
        });
        var viewModel = sut.Create(testPageMock);

        Assert.Equal(pageDescription, viewModel.PageDescription);
        Assert.Equal("Page Title", viewModel.PageTitle);
        Assert.False(string.IsNullOrEmpty(viewModel.MetaRobots));
    }
}