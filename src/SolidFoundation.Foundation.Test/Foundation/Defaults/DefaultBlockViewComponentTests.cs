using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using SolidFoundation.Foundation.Foundation.Defaults;
using SolidFoundation.Foundation.Foundation.Models.BaseModels;
using SolidFoundation.Foundation.Foundation.Models.ViewModels;
using Xunit;

namespace SolidFoundation.Foundation.Test.Foundation.Defaults;

public class DefaultBlockViewComponentTests
{
    [Fact]
    public async Task InvokeComponentAsync_ReturnsViewComponentResult_WithPathAndViewModel()
    {
        //arrange
        var testBlock = new TestBlock();
        var sut = new DefaultBlockViewComponent();

        //act
        var result = await sut.InvokeAsync(testBlock);

        //assert
        var viewResult = Assert.IsType<ViewViewComponentResult>(result);
        Assert.NotNull(viewResult.ViewData);
        Assert.NotNull(viewResult.ViewData!.Model);
        Assert.IsType<BlockViewModel<TestBlock>>(viewResult.ViewData.Model);
        Assert.Equal($"~/Foundation/Defaults/{nameof(TestBlock)}.cshtml", viewResult.ViewName);
    }
}

public class TestBlock : SiteBlock
{
}