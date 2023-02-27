using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Constants;
using SolidFoundation.Foundation.Foundation.Models.BaseModels;

namespace SolidFoundation.Feature.SiteDemo1.SiteDemo1.Pages.Products;

[ContentType(DisplayName = "Product Item Page",
    GUID = "{9DF0EFD6-756A-434B-BBA3-019C6756EC6E}",
    GroupName = SiteDemo1CmsGroupNames.SiteDemo1Pages)]
[AvailableContentTypes(Availability.None)]
public class ProductItemPage : SitePage
{
    [CultureSpecific]
    [Display(Name = "Product Name", Order = 10)]
    public virtual string? ProductName { get; set; }

    [Display(Name = "Product Image", Order = 20)]
    [UIHint(UIHint.Image)]
    public virtual ContentReference? ProductImage  { get; set; }
    
    [CultureSpecific]
    [Display(Name = "Product Description", Order = 30)]
    public virtual XhtmlString ProductDescription { get; set; }
    
}