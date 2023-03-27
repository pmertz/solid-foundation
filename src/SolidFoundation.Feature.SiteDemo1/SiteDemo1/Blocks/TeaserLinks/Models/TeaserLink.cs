using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.Shell.ObjectEditing;
using SolidFoundation.Foundation.OptimizelyExtensions.SelectionFactories;

namespace SolidFoundation.Feature.SiteDemo1.SiteDemo1.Blocks.TeaserLinks.Models;

public class TeaserLink
{
    [Display(Name = "Link Text", Order = 10)]
    public virtual string? LinkText { get; set; }
    
    [Display(Name = "Page Link", Order = 20)]
    public virtual PageReference? PageLink { get; set; }
    
    [SelectOne(SelectionFactoryType = typeof(EnumSelectionFactory<TeaserLinkCssClasses>))]
    [Display(Name = "Link Css Class", Order = 20)]
    public virtual TeaserLinkCssClasses? CssClass { get; set; }
}