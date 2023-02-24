using EPiServer.Core;
using EPiServer.DataAnnotations;
// ReSharper disable SuspiciousTypeConversion.Global

namespace SolidFoundation.Foundation.Foundation.Models.BaseModels;

public abstract class SiteBlock : BlockData, IHideCategory
{
    [Ignore]
    public int BlockId => this is not IContent content ? 0 : content.ContentLink.ID;

    [Ignore]
    public string BlockName => this is not IContent content ? string.Empty : content.Name;
}