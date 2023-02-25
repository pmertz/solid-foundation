using EPiServer.Core;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using SolidFoundation.Foundation.Foundation.Models.BaseModels;

namespace SolidFoundation.Foundation.Foundation.EditorDescriptors;

[EditorDescriptorRegistration(TargetType = typeof(CategoryList))]
public class HideCategoryEditorDescriptor : EditorDescriptor
{
    public override void ModifyMetadata(
        ExtendedMetadata metadata,
        IEnumerable<Attribute> attributes)
    {
        base.ModifyMetadata(metadata, attributes);

        dynamic mayQuack = metadata;
        var ownerContent = mayQuack.OwnerContent as IContent;
        if (!(ownerContent is IHideCategory))
            return;

        if (metadata.PropertyName == "icategorizable_category")
        {
            metadata.ShowForEdit = false;
        }
    }
}