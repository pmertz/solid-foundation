using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.DataAnnotations;

namespace SolidFoundation.Feature.Commerce.Models;

[CatalogContentType(
    DisplayName = "Default Product", 
    GUID = "{515B80D9-BB72-495C-89B6-916FA9C2F695}")]
public class DefaultProduct : ProductContent
{
}