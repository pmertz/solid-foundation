using System.Collections.Generic;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web.Routing;
using NSubstitute;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Pages.Products;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Pages.Products.Services;
using Xunit;

namespace SolidFoundation.Feature.SiteDemo1.Test.SiteDemo1.Pages.Products.Services;

public class CategoryRollupViewModelFactoryTests
{
    [Fact]
    public void Create_ShouldReturnViewModel()
    {
        //arrange
        var contentLoader = Substitute.For<IContentLoader>();
        var listOfProductItemPageMocks = new List<ProductItemPage>
        {
            CreateProductItemPageMock(10),
            CreateProductItemPageMock(20)
        };
        contentLoader.GetChildren<ProductItemPage>(Arg.Any<ContentReference>())
            .Returns(listOfProductItemPageMocks);

        var urlResolver = Substitute.For<IUrlResolver>();
        urlResolver.GetUrl(Arg.Any<ContentReference>())
            .Returns(args =>
            {
                var id = ((ContentReference)args[0]).ID;
                var type = id > 100 ? "image" : "page";
                return $"/url-for-{type}-{id}";
            });

        var productCategoryPage = Substitute.For<ProductCategoryPage>();
        productCategoryPage.CategoryName = "Test Category 1";
        productCategoryPage.KeySellingPoint = "Test key selling points";
        
        var sut = new CategoryRollupViewModelFactory(contentLoader, urlResolver);
        
        //act
        var result = sut.Create(productCategoryPage);
        
        //assert
        Assert.NotNull(result);
        Assert.Equal(productCategoryPage.CategoryName, result.CategoryName);
        Assert.Equal(productCategoryPage.KeySellingPoint, result.KeySellingPoint);
        Assert.Collection(result.ProductLinks,
            item =>
            {
                Assert.Equal("Product-10", item.Name); 
                Assert.Equal("/url-for-page-10", item.Url); 
                Assert.Equal("/url-for-image-110", item.ImageUrl);
            },
            item =>
            {
                Assert.Equal("Product-20", item.Name); 
                Assert.Equal("/url-for-page-20", item.Url); 
                Assert.Equal("/url-for-image-120", item.ImageUrl);
            }
            );
    }

    private ProductItemPage CreateProductItemPageMock(int id)
    {
        var mock = Substitute.For<ProductItemPage>();
        mock.ContentLink.Returns(new ContentReference(id));
        mock.Name.Returns($"Product-{id}");
        mock.ProductImage.Returns(new ContentReference(id + 100));
        return mock;
    }
}