using System.Collections.Generic;
using System.Globalization;
using EPiServer;
using EPiServer.Core;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using NSubstitute;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Components.MainNavigation;
using Xunit;

namespace SolidFoundation.Feature.SiteDemo1.Test.SiteDemo1.Components.MainNavigation;

public class MainNavigationViewComponentTests
{
    [Fact]
    public void Invoke_ReturnsViewWithViewModel()
    {
        //arrange
        var homePage = Substitute.For<PageData>();
        homePage.ContentLink.Returns(new ContentReference(10));
        var itemPage = Substitute.For<PageData>();
        var currentPage = Substitute.For<PageData>();
        currentPage.ContentLink.Returns(new ContentReference(20));
        
        var contentLoader = Substitute.For<IContentLoader>();
        contentLoader.Get<PageData>(Arg.Any<ContentReference>()).Returns(homePage);
        contentLoader.GetChildren<PageData>(Arg.Any<ContentReference>(), Arg.Any<CultureInfo>())
            .Returns(new[] { itemPage,  currentPage });
        var contentLanguageAccessor = Substitute.For<IContentLanguageAccessor>();
        ContentReference.StartPage = new PageReference(homePage.ContentLink);
        
        var sut = new MainNavigationViewComponent(contentLoader, contentLanguageAccessor);
        
        //act
        var result = sut.Invoke(currentPage);
        
        //assert
        var viewResult = Assert.IsType<ViewViewComponentResult>(result);
        Assert.NotNull(viewResult.ViewData);
        var viewModelResult = Assert.IsType<(List<PageData> NavigationItems, ContentReference CurrentContentLink)>(viewResult.ViewData.Model);
        Assert.Collection(viewModelResult.NavigationItems, 
            c => Assert.Equal(homePage, c),
            c => Assert.Equal(itemPage, c),
            c => Assert.Equal(currentPage, c)
            );
        Assert.Equal(currentPage.ContentLink, viewModelResult.CurrentContentLink);
    }
}