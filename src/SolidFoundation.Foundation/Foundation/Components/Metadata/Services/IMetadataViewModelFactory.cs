using SolidFoundation.Foundation.Foundation.Models.BaseModels;

namespace SolidFoundation.Foundation.Foundation.Components.Metadata.Services
{
    public interface IMetadataViewModelFactory
    {
        MetadataViewModel Create(SitePage sitePage);
    }
}