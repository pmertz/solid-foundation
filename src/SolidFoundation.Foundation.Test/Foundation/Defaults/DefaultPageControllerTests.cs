using Microsoft.AspNetCore.Mvc;
using SolidFoundation.Foundation.Foundation.Defaults;
using SolidFoundation.Foundation.Foundation.Models.BaseModels;
using SolidFoundation.Foundation.Foundation.Models.ViewModels;
using Xunit;

namespace SolidFoundation.Foundation.Test.Foundation.Defaults;

public class DefaultPageControllerTests
{
    [Fact]
    public void Index_ReturnsReturnsViewResult_WithPathAndViewModel()
    {
        //arrange
        var testPage = new DefaultPageControllerTestPage();
        var sut = new DefaultPageController();

        //act
        var result = sut.Index(testPage);

        //assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var viewModel = Assert.IsType<ContentViewModel<DefaultPageControllerTestPage>>(viewResult.Model);
        Assert.Equal(testPage, viewModel.CurrentContent);
        Assert.Equal($"~/Foundation/Defaults/{nameof(DefaultPageControllerTestPage)}.cshtml", viewResult.ViewName);
    }
}

public class DefaultPageControllerTestPage : SitePage
{
}