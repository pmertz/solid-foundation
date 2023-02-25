using SolidFoundation.Foundation.Foundation.Models.BaseModels;

namespace SolidFoundation.Foundation.Foundation.Components.Metadata.Services
{
    public class MetadataViewModelFactory : IMetadataViewModelFactory
    {
        public MetadataViewModel Create(SitePage sitePage)
        {
            var model = new MetadataViewModel(sitePage.MetaData?.Title ?? sitePage.PageName)
            {
                MetaRobots = sitePage.MetaData?.MetaRobots,
                PageDescription = sitePage.MetaData?.Description
            };

            return model;
        }
    }
}