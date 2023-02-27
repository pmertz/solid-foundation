using System.ComponentModel.DataAnnotations;
using EPiServer.DataAnnotations;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Constants;
using SolidFoundation.Foundation.Foundation.Models.BaseModels;

namespace SolidFoundation.Feature.SiteDemo1.SiteDemo1.Pages.Blog;

[ContentType(DisplayName = "Blog Post",
    GUID = "{413D858D-813D-4A84-9F32-D019C5F72254}",
    GroupName = SiteDemo1CmsGroupNames.SiteDemo1Pages)]
[AvailableContentTypes(Include = new []{typeof(BlogPost)})]
public class BlogPage : SitePage
{
    [CultureSpecific]
    [Display(Name = "Headline", Order = 10)]
    public virtual string? Headline { get; set; }
}