using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Constants;
using SolidFoundation.Foundation.Foundation.Models.BaseModels;

namespace SolidFoundation.Feature.SiteDemo1.SiteDemo1.Pages.Article;

[ContentType(DisplayName = "Article Page",
        GUID = "{92DABF3F-96B1-4034-BF76-E97701297DF0}",
        GroupName = SiteDemo1CmsGroupNames.SiteDemo1Pages)]
[AvailableContentTypes(Include = new []{typeof(ArticlePage)})]
public class ArticlePage : SitePage
{
        [CultureSpecific]
        [Display(Name = "Page Headline", Order = 10)]
        public virtual string? PageHeadline { get; set; }
        
        [Display(Name = "Hero Image", Order = 20)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference? HeroImage  { get; set; }        
        
        [CultureSpecific]
        [Display(Name = "Body", Order = 30)]
        public virtual XhtmlString? Body { get; set; }
        
        [CultureSpecific]
        [Display(Name = "Sidebar Headline", Order = 40)]
        public virtual string? SidebarHeadline { get; set; }
        
        [CultureSpecific]
        [Display(Name = "Sidebar Body", Order = 40)]
        public virtual XhtmlString? SidebarBody { get; set; }        
}