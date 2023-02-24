using EPiServer.Shell.ObjectEditing;

namespace SolidFoundation.Foundation.Foundation.SelectionFactories;

public class MetaRobotsSelectionFactory : ISelectionFactory
{
    public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
    {
        return new ISelectItem[]
        {
            new SelectItem() {Text = "index, follow", Value = "index, follow"},
            new SelectItem() {Text = "index, nofollow", Value = "index, nofollow"},
            new SelectItem() {Text = "noindex, follow", Value = "noindex, follow"},
            new SelectItem() {Text = "noindex, nofollow", Value = "noindex, nofollow"}
        };
    }
}