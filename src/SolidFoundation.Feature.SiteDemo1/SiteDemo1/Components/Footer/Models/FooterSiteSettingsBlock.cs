using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using SolidFoundation.Foundation.Foundation.Constants;
using SolidFoundation.Foundation.Foundation.Models.BaseModels;
using SolidFoundation.Foundation.Foundation.SiteSettings.Models;

namespace SolidFoundation.Feature.SiteDemo1.SiteDemo1.Components.Footer.Models;

[ContentType(
    GUID = "{466549F6-72F8-4F5D-9243-5BD9926F02E4}", 
    DisplayName = "Footer Site Settings", 
    Description = "Settings for global footer",
    GroupName = CmsGroupNames.SiteSettings)]
public class FooterSiteSettingsBlock : SiteBlock, ISiteSettingsBlock
{
    [CultureSpecific]
    [Display(Name = "Social Media Footer Links", Order = 10)]
    [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<SocialMediaFooterLink>))]
    public virtual IList<SocialMediaFooterLink>? SocialMediaFooterLinks { get; set; }
    
    [CultureSpecific]
    [Display(Name = "Copyright Message", Order = 20)]
    public virtual string? CopyrightMessage { get; set; }
}