using System.Collections.Generic;

namespace SolidFoundation.Feature.SiteDemo1.SiteDemo1.Pages.Products.Models;

public class ProductsPageViewModel
{
    public IEnumerable<CategoryViewModel> Categories { get; set; }   
}