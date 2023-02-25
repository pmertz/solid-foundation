using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using SolidFoundation.Foundation.Foundation.Constants;
using SolidFoundation.Foundation.Foundation.Models.Blocks.MetaData;

namespace SolidFoundation.Foundation.Foundation.Models.BaseModels;

public abstract class SitePage : PageData, IHideCategory
{
     [Display(Name = "Meta Data", GroupName = CmsTabNames.MetaData)]
     public virtual MetaDataBlock? MetaData { get; set; }
}