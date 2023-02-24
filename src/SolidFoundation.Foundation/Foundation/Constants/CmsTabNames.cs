using System.ComponentModel.DataAnnotations;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Security;

namespace SolidFoundation.Foundation.Foundation.Constants;

[GroupDefinitions]
public static class CmsTabNames
{
    
    [Display(Order = 100)]
    [RequiredAccess(AccessLevel.Edit)]
    public const string MetaData = "Seo";
    
    [Display(Order = 900)]
    public const string SiteSettings = "Site Settings";
    
    [Display(Name = "Settings", Order = 910)]
    public const string Settings = SystemTabNames.Settings;
}