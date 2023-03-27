using System.Linq;
using EPiServer;
using EPiServer.Web.Routing;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Pages.Products.Models;

namespace SolidFoundation.Feature.SiteDemo1.SiteDemo1.Pages.Products.Services;

public class CategoryRollupViewModelFactory : ICategoryRollupViewModelFactory
{
    private readonly IContentLoader _contentLoader;
    private readonly IUrlResolver _urlResolver;

    public CategoryRollupViewModelFactory(IContentLoader contentLoader, IUrlResolver urlResolver)
    {
        _contentLoader = contentLoader;
        _urlResolver = urlResolver;
    }

    public CategoryRollupViewModel Create(ProductCategoryPage productCategoryPage)
    {
        var productItemChildPages = _contentLoader.GetChildren<ProductItemPage>(productCategoryPage.ContentLink);
        var productLinks = productItemChildPages.Select(CreateProductLink);

        var categoryViewModel = new CategoryRollupViewModel(productCategoryPage.CategoryName,
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