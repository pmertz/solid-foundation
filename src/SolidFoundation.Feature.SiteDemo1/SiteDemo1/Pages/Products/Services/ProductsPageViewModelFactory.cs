using System.Linq;
using EPiServer;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Pages.Products.Models;

namespace SolidFoundation.Feature.SiteDemo1.SiteDemo1.Pages.Products.Services;

public class ProductsPageViewModelFactory : IProductsPageViewModelFactory
{
    private readonly IContentLoader _contentLoader;
    private readonly ICategoryRollupViewModelFactory _categoryRollupViewModelFactory;

    public ProductsPageViewModelFactory(IContentLoader contentLoader, ICategoryRollupViewModelFactory categoryRollupViewModelFactory)
    {
        _contentLoader = contentLoader;
        _categoryRollupViewModelFactory = categoryRollupViewModelFactory;
    }

    public ProductsPageViewModel Create(ProductsPage productsPage)
    {
        var categoryChildPages = _contentLoader.GetChildren<ProductCategoryPage>(productsPage.ContentLink);
        var viewModel = new ProductsPageViewModel
        {
            Categories = categoryChildPages.Select(_categoryRollupViewModelFactory.Create)
        };
        
        return viewModel;
    }
}