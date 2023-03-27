using System.Collections.Generic;

namespace SolidFoundation.Feature.SiteDemo1.SiteDemo1.Pages.Products.Models;

public class ProductsPageViewModel
{
    public IEnumerable<CategoryRollupViewModel> Categories { get; set; } = new List<CategoryRollupViewModel>();
}