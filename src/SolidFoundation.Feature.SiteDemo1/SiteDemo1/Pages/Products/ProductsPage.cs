using System.ComponentModel.DataAnnotations;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Constants;
using SolidFoundation.Foundation.Foundation.Models.BaseModels;

namespace SolidFoundation.Feature.SiteDemo1.SiteDemo1.Pages.Products;

[ContentType(DisplayName = "Products Page",
    GUID = "{FC34B77E-2D2E-4080-A7C6-D76409DCBF9A}",
    GroupName = SiteDemo1CmsGroupNames.SiteDemo1Pages)]
[AvailableContentTypes(Include = new []{typeof(ProductCategoryPage)})]
public class ProductsPage : SitePage
{
    [CultureSpecific]
    [Display(Name = "Page Headline", Order = 10)]
    public virtual string? PageHeadline { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
        PageHeadline = "Products";
    }
}