using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace SolidFoundation.Foundation.Foundation.Models.Media;

[ContentType(DisplayName = "ImageFile", GUID = "c27dda52-ea4f-4af4-908b-771819f76a8a")]
[MediaDescriptor(ExtensionString = "jpg,jpeg,jpe,ico,gif,bmp,png,jfif")]
public class ImageFile : ImageData
{
}