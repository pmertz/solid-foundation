using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Pages.Products.Models;

namespace SolidFoundation.Feature.SiteDemo1.SiteDemo1.Pages.Products.Services;

public interface IProductsPageViewModelFactory
{
    ProductsPageViewModel Create(ProductsPage productsPage);
}