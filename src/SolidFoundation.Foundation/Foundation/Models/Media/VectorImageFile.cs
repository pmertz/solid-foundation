using System.Diagnostics.CodeAnalysis;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Framework.Blobs;
using EPiServer.Framework.DataAnnotations;

namespace SolidFoundation.Foundation.Foundation.Models.Media
{
    [ContentType(GUID = "{0420D28E-292B-4D6E-AADF-2EAFA2FFD523}")]
    [MediaDescriptor(ExtensionString = "svg")]
    [ExcludeFromCodeCoverage(Justification = "Test would bring no value")]
    public class VectorImageFile : ImageData
    {
        /// <summary>
        /// Gets the generated thumbnail for this media.
        /// </summary>
        public override Blob Thumbnail => BinaryData;
    }
}