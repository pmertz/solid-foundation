using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
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
    [Display(GroupName = SystemTabNames.Settings, Order = -100)]
    [AllowedTypes(typeof(ISiteSettingsBlock))]
    public virtual ContentArea? SiteSettings { get; set; }
    
    [CultureSpecific]
    [Display(Name = "Hero Image", Order = 10)]
    [UIHint(UIHint.Image)]
    public virtual ContentReference? HeroImage  { get; set; }        

    [CultureSpecific]
    [Display(Name = "Hero Text", Order = 20)]
    public virtual string? HeroLinkText { get; set; }
    
    [CultureSpecific]
    [Display(Name = "Hero Page Link", Order = 20)]
    public virtual PageReference? HeroPageLink { get; set; }
    
    [Display(Name = "Page Content", Description = "Area for content blocks. Add or create content here.", Order = 40)]
    public virtual ContentArea? PageContent { get; set; }
}