using System.Collections.Generic;

namespace SolidFoundation.Feature.SiteDemo1.SiteDemo1.Pages.Products.Models;

public class CategoryRollupViewModel
{
    public CategoryRollupViewModel(string categoryName, string keySellingPoint, IEnumerable<ProductLink> productLinks)
    {
        CategoryName = categoryName;
        KeySellingPoint = keySellingPoint;
        ProductLinks = productLinks;
    }

    public string CategoryName { get; }

    public string KeySellingPoint { get;  }
    
    public IEnumerable<ProductLink> ProductLinks { get; }
}