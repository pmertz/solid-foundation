using EPiServer.Shell;

namespace SolidFoundation.Foundation.Foundation.SiteSettings.Models;

[UIDescriptorRegistration]
public class SettingsBlockUiDescriptor : UIDescriptor<ISiteSettingsBlock>
{
    public SettingsBlockUiDescriptor()
    {
        DefaultView = CmsViewNames.AllPropertiesView;
        AddDisabledView(CmsViewNames.PreviewView);
        AddDisabledView(CmsViewNames.SideBySideCompareView);
        AddDisabledView(CmsViewNames.OnPageEditView);
    }
}