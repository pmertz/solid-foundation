using System.Linq;
using EPiServer;
using EPiServer.Web.Routing;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Pages.Products.Models;

namespace SolidFoundation.Feature.SiteDemo1.SiteDemo1.Pages.Products.Services;

public class ProductsPageViewModelFactory : IProductsPageViewModelFactory
{
    private readonly IContentLoader _contentLoader;
    private readonly IUrlResolver _urlResolver;

    public ProductsPageViewModelFactory(IContentLoader contentLoader, IUrlResolver urlResolver)
    {
        _contentLoader = contentLoader;
        _urlResolver = urlResolver;
    }

    public ProductsPageViewModel Create(ProductsPage productsPage)
    {
        var categoryChildPages = _contentLoader.GetChildren<ProductCategoryPage>(productsPage.ContentLink);
        var viewModel = new ProductsPageViewModel
        {
            Categories = categoryChildPages.Select(CreateCategoryViewModel)
        };
        
        return viewModel;
    }

    private CategoryViewModel CreateCategoryViewModel(ProductCategoryPage productCategoryPage)
    {
        var productItemChildPages = _contentLoader.GetChildren<ProductItemPage>(productCategoryPage.ContentLink);
        var productLinks = productItemChildPages.Select(CreateProductLink);

        var categoryViewModel = new CategoryViewModel(productCategoryPage.CategoryName,
            productCategoryPage.KeySellingPoint, productLinks);
        return categoryViewModel;
    }

    private ProductLink CreateProductLink(ProductItemPage productItemPage)
    {
        var productLink = new ProductLink(productItemPage.Name, _urlResolver.GetUrl(productItemPage.ProductImage),
            _urlResolver.GetUrl(productItemPage.ContentLink));
        return productLink;
    }
}