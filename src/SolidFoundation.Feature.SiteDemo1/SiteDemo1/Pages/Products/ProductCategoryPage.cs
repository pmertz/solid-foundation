using System.ComponentModel.DataAnnotations;
using EPiServer.DataAnnotations;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Constants;
using SolidFoundation.Foundation.Foundation.Models.BaseModels;

namespace SolidFoundation.Feature.SiteDemo1.SiteDemo1.Pages.Products;

[ContentType(DisplayName = "Product Category Page",
    GUID = "{B3860B22-5786-46ED-9853-FE705AD99FF6}",
    GroupName = SiteDemo1CmsGroupNames.SiteDemo1Pages)]
[AvailableContentTypes(Include = new []{typeof(ProductItemPage)})]
public class ProductCategoryPage : SitePage
{
    [CultureSpecific]
    [Display(Name = "Category Name", Order = 10)]
    public virtual string? CategoryName { get; set; }
    
    [CultureSpecific]
    [Display(Name = "Key Selling Point", Order = 20)]
    public virtual string? KeySellingPoint { get; set; }
}