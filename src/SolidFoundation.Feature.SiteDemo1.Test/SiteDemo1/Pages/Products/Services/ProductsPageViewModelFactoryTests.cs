using System.Collections.Generic;
using EPiServer;
using EPiServer.Core;
using NSubstitute;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Pages.Products;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Pages.Products.Models;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Pages.Products.Services;
using Xunit;

namespace SolidFoundation.Feature.SiteDemo1.Test.SiteDemo1.Pages.Products.Services;

public class ProductsPageViewModelFactoryTests
{
    [Fact]
    public void Create_ShouldReturnViewModel()
    {
        //arrange
        var contentLoader = Substitute.For<IContentLoader>();
        var listOfCategoryPageMocks = new List<ProductCategoryPage>
        {
            CreateProductCategoryPageMock(10),
            CreateProductCategoryPageMock(20)
        };
        contentLoader.GetChildren<ProductCategoryPage>(Arg.Any<ContentReference>())
            .Returns(listOfCategoryPageMocks);
        var categoryRollupViewModelFactory = Substitute.For<ICategoryRollupViewModelFactory>();
        categoryRollupViewModelFactory.Create(Arg.Any<ProductCategoryPage>())
            .Returns(arg =>
            {
                var categoryPage = (ProductCategoryPage)arg[0];
                return new CategoryRollupViewModel($"Catagory-{categoryPage.ContentLink.ID}", "some-key selling points",
                    new List<ProductLink>());
            });

        var sut = new ProductsPageViewModelFactory(contentLoader, categoryRollupViewModelFactory);

        var productsPage = new ProductsPage();

        //act
        var result = sut.Create(productsPage);
        
        //assert
        Assert.NotNull(result);
        Assert.NotNull(result.Categories);
        Assert.Collection(result.Categories, 
            item => {Assert.Equal("Catagory-10", item.CategoryName);},
            item => {Assert.Equal("Catagory-20", item.CategoryName);}
            );
    }

    private static ProductCategoryPage CreateProductCategoryPageMock(int id)
    {
        var mock = Substitute.For<ProductCategoryPage>();
        mock.ContentLink.Returns(new ContentReference(id));
        return mock;
    }
}