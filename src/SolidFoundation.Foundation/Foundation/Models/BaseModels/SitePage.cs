using EPiServer.Core;
using SolidFoundation.Foundation.Foundation.Models.Blocks.MetaData;

namespace SolidFoundation.Foundation.Foundation.Models.BaseModels;

public abstract class SitePage : PageData, IHideCategory
{
     public virtual MetaDataBlock MetaData { get; set; }
}