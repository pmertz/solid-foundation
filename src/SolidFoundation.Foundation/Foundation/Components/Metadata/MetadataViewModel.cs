namespace SolidFoundation.Foundation.Foundation.Components.Metadata
{
    public class MetadataViewModel
    {
        public MetadataViewModel(string pageTitle)
        {
            PageTitle = pageTitle;
        }

        public string PageTitle { get; init; }
        public string? MetaRobots { get; set; }
        public string? PageDescription { get; set; }
    }
}