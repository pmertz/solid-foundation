using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Blocks.TeaserLinks.Models;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Constants;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Models;
using SolidFoundation.Foundation.Foundation.Models.BaseModels;

namespace SolidFoundation.Feature.SiteDemo1.SiteDemo1.Blocks.TeaserLinks;

[ContentType(
    DisplayName = "Teaser Links Block",
    GUID = "{0EBC4168-3D93-4B8B-AB7F-8EC9D8A6E87A}",
    Description = "Splash Block with Image",
    GroupName = SiteDemo1CmsGroupNames.SiteDemo1Blocks)]
public class TeaserLinksBlock : SiteBlock, ISiteDemo1ContentBlocks
{
    [CultureSpecific]
    [Display(Name = "Teaser Links", Order = 10)]
    [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<TeaserLink>))]
    public virtual IList<TeaserLink>? TeaserLinks { get; set; }
}