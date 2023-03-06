using EPiServer.Shell.ObjectEditing;
using SolidFoundation.Foundation.Foundation.SelectionFactories;

namespace SolidFoundation.Feature.SiteDemo1.SiteDemo1.Components.Footer.Models;

public class SocialMediaFooterLink
{
    public string? Name { get; set; }
    
    public virtual string? Url { get; set; }
    
    [SelectOne(SelectionFactoryType = typeof(EnumSelectionFactory<FooterCssClasses>))]
    public virtual FooterCssClasses? CssClass { get; set; }
}