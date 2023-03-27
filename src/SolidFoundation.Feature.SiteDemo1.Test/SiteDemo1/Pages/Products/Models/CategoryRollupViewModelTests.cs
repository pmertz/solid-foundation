using System.Collections.Generic;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Pages.Products.Models;
using Xunit;

namespace SolidFoundation.Feature.SiteDemo1.Test.SiteDemo1.Pages.Products.Models;

public class CategoryRollupViewModelTests
{
    [Fact]
    public void Ctor_ShouldInitialize()
    {
        //arrange
        const string name = "Test Category";
        const string keySellingPoint = "test ksp";
        var productLinks = new List<ProductLink> {new("Test", "/images/test.jpg", "/my-product")};

        //act
        var sut = new CategoryRollupViewModel(name, keySellingPoint, productLinks);
        
        //assert
        Assert.Equal(name, sut.CategoryName);
        Assert.Equal(keySellingPoint, sut.KeySellingPoint);
        Assert.Equal(productLinks, sut.ProductLinks);
    }
}