using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Web;
using SolidFoundation.Foundation.Foundation.Constants;
using SolidFoundation.Foundation.Foundation.SelectionFactories;
// ReSharper disable Mvc.TemplateNotResolved

namespace SolidFoundation.Foundation.Foundation.Models.Blocks.MetaData;

[ContentType(DisplayName = "Meta Data Block",
    GUID = "{F7DB3402-AB39-469A-98A4-52104F89D3FD}",
    Description = "Inline block only used on SitePage",
    GroupName = CmsGroupNames.InlineBlock,
    AvailableInEditMode = false
)]
public class MetaDataBlock : BlockData
{
    [CultureSpecific]
    [Display(Name = "Title", GroupName = CmsTabNames.MetaData, Order = 100, Description = "You can override the title tag to better match user queries. Please try to restrict the title tag to 60 characters max. It won’t appear on the page but is likely to appear on search engines results pages as the clickable title of the snippet. It will display the page name by default.")]
    public virtual string? Title { get; set; }

    [CultureSpecific]
    [UIHint(UIHint.Textarea)]
    [Display(Name = "Description", Description = "Enter custom Meta Description that includes a Call-to-Action phrase such as Discover…, Learn more... Recommended character length is 150.", GroupName = CmsTabNames.MetaData, Order = 200)]
    public virtual string? Description { get; set; }

    [Display(Name = "Meta Robots", GroupName = CmsTabNames.MetaData, Order = 300)]
    [SelectOne(SelectionFactoryType = typeof(MetaRobotsSelectionFactory))]
    public virtual string? MetaRobots { get; set; }

    public override void SetDefaultValues(ContentType contentType)
    {
        MetaRobots = "index, follow";
        base.SetDefaultValues(contentType);
    }
}