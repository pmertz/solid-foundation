using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Constants;
using SolidFoundation.Foundation.Foundation.Models.BaseModels;

namespace SolidFoundation.Feature.SiteDemo1.SiteDemo1.Pages.Blog;

[ContentType(DisplayName = "Blog Post",
    GUID = "{5DAC7032-FB76-4892-AB45-A8FE08837916}",
    GroupName = SiteDemo1CmsGroupNames.SiteDemo1Pages)]
[AvailableContentTypes(Availability.None)]
public class BlogPost : SitePage
{
    [CultureSpecific]
    [Display(Name = "Headline", Order = 10)]
    public virtual string? Headline { get; set; }
    
    [CultureSpecific]
    [Display(Name = "Product Description", Order = 20)]
    public virtual XhtmlString? Body { get; set; }        
}