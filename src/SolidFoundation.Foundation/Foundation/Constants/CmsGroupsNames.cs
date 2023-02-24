using System.ComponentModel.DataAnnotations;
using EPiServer.DataAnnotations;

namespace SolidFoundation.Foundation.Foundation.Constants;

[GroupDefinitions]
public static class CmsGroupNames
{
    [Display(Name = "Content", Order = 510)]
    public const string Content = "Content";

    public const string GlobalContentBlocks = "Global Content Blocks";

    public const string InlineBlock = "Inline block";

    public const string SiteSettings = "Site Setting blocks";
}