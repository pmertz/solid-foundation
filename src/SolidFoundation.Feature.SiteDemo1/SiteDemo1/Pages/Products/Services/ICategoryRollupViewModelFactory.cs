using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Pages.Products.Models;

namespace SolidFoundation.Feature.SiteDemo1.SiteDemo1.Pages.Products.Services;

public interface ICategoryRollupViewModelFactory
{
    CategoryRollupViewModel Create(ProductCategoryPage productCategoryPage);
}