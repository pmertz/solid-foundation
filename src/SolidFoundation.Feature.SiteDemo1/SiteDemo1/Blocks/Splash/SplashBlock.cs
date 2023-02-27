using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Constants;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Models;
using SolidFoundation.Foundation.Foundation.Models.BaseModels;

namespace SolidFoundation.Feature.SiteDemo1.SiteDemo1.Blocks.Splash;

[ContentType(
    DisplayName = "Splash Block",
    GUID = "{8D9BE421-C294-4C07-A1D5-84DFC1D86C18}",
    Description = "Splash Block with Image",
    GroupName = SiteDemo1CmsGroupNames.SiteDemo1Blocks)]
public class SplashBlock : SiteBlock, ISiteDemo1ContentBlocks
{
    [CultureSpecific]
    [Display(Name = "Text", Order = 10)]
    public virtual XhtmlString? Text { get; set; }
    
    [CultureSpecific]
    [Display(Name = "Image", Order = 20)]
    [UIHint(UIHint.Image)]    
    public virtual ContentReference? Image  { get; set; }
    
    [CultureSpecific]
    [Display(Name = "Image Alt Text", Order = 30)]
    public virtual string? ImageAltText  { get; set; }
}