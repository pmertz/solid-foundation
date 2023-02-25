using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace SolidFoundation.Foundation.Foundation.Models.Media
{
    [ContentType(DisplayName = "Pdf File", GUID = "{C974FB68-5AD4-4638-A771-A9BE157A6CA2}")]
    [MediaDescriptor(ExtensionString = "pdf")]
    public class PdfFile : MediaData
    {
    }
}