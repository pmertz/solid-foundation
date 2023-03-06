using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Constants;
using SolidFoundation.Foundation.Foundation.Models.BaseModels;

namespace SolidFoundation.Feature.SiteDemo1.SiteDemo1.Pages.Contact;

[ContentType(DisplayName = "Contact Page",
    GUID = "{5D622F96-C706-4B7E-9325-C7216BFDE2E8}",
    GroupName = SiteDemo1CmsGroupNames.SiteDemo1Pages)]
[AvailableContentTypes(Availability.None)]
public class ContactPage : SitePage
{
    [CultureSpecific]
    public virtual string? PageHeadline { get; set; }
}