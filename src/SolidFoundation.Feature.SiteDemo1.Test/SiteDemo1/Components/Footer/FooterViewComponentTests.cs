using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using NSubstitute;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Components.Footer;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Components.Footer.Models;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Components.Footer.Services;
using Xunit;

namespace SolidFoundation.Feature.SiteDemo1.Test.SiteDemo1.Components.Footer;

public class FooterViewComponentTests
{
    [Fact]
    public void Invoke_ReturnsViewResultWithViewModel()
    {
        //arrange
        var viewModel = new FooterViewModel(Substitute.For<IList<SocialMediaFooterLink>>());
        var footerViewModelFactory = Substitute.For<IFooterViewModelFactory>();
        footerViewModelFactory.Create().Returns(viewModel);
        
        var sut = new FooterViewComponent(footerViewModelFactory);
        
        //act
        var result = sut.Invoke();
        
        //assert
        var viewResult = Assert.IsType<ViewViewComponentResult>(result);
        Assert.NotNull(viewResult.ViewData);
        var viewModelResult = Assert.IsType<FooterViewModel>(viewResult.ViewData.Model);
        Assert.Equal(viewModel, viewModelResult);
    }
}