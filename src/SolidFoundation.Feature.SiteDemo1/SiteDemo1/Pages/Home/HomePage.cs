using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Constants;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Pages.Article;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Pages.Blog;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Pages.Contact;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Pages.Products;
using SolidFoundation.Foundation.Foundation.Models.BaseModels;
using SolidFoundation.Foundation.Foundation.SiteSettings.Models;

namespace SolidFoundation.Feature.SiteDemo1.SiteDemo1.Pages.Home;

[ContentType(DisplayName = "Home Page (root)",
    GUID = "{728BD84C-256F-4F8A-981B-92D45C0FA797}",
    GroupName = SiteDemo1CmsGroupNames.SiteDemo1Pages)]
[AvailableContentTypes(Include = new []{typeof(ArticlePage), typeof(ProductsPage), typeof(BlogPage), typeof(ContactPage)})]
public class HomePage : SitePage, ISiteSettingsPage, ISiteRootNode
{
    [CultureSpecific(false)]
    [Display(GroupName = SystemTabNames.Settings, Order = -1)]
    [AllowedTypes(typeof(ISiteSettingsBlock))]
    public virtual ContentArea? SiteSettings { get; set; }

    [CultureSpecific]
    public virtual string? Headline { get; set; }

    [CultureSpecific]
    public virtual XhtmlString? Body { get; set; }
}