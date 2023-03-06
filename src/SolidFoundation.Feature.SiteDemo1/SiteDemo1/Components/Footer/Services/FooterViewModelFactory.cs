using System.Collections.Generic;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Components.Footer.Models;
using SolidFoundation.Foundation.Foundation.SiteSettings.Services;

namespace SolidFoundation.Feature.SiteDemo1.SiteDemo1.Components.Footer.Services;

public class FooterViewModelFactory : IFooterViewModelFactory
{
    private readonly ISiteSettingsService _siteSettingsService;

    public FooterViewModelFactory(ISiteSettingsService siteSettingsService)
    {
        _siteSettingsService = siteSettingsService;
    }

    public FooterViewModel Create()
    {
        var footerSettings = _siteSettingsService.GetSettingByBlockType<FooterSiteSettingsBlock>();
        
        var viewModel = new FooterViewModel(footerSettings.SocialMediaFooterLinks ?? new List<SocialMediaFooterLink>())
        {
            CopyrightMessage = footerSettings?.CopyrightMessage ?? "<style class='color:red'>CopyrightMessage does not exist</style>"
        };
        return viewModel;
    }
}