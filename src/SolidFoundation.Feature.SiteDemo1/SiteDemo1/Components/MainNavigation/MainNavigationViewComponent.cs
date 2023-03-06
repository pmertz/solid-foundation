using System.Collections.Generic;
using System.Linq;
using EPiServer;
using EPiServer.Core;
using Microsoft.AspNetCore.Mvc;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Pages.Home;
using SolidFoundation.Foundation.Foundation.Models.ViewModels;

namespace SolidFoundation.Feature.SiteDemo1.SiteDemo1.Components.MainNavigation;

public class MainNavigationViewComponent : ViewComponent
{
    private readonly IContentLoader _contentLoader;
    private readonly IContentLanguageAccessor _contentLanguageAccessor;

    public MainNavigationViewComponent(IContentLoader contentLoader, IContentLanguageAccessor contentLanguageAccessor)
    {
        _contentLoader = contentLoader;
        _contentLanguageAccessor = contentLanguageAccessor;
    }

    public IViewComponentResult Invoke(IContent currentContent)
    {
        var home = _contentLoader.Get<PageData>(ContentReference.StartPage);
        var children =
            _contentLoader.GetChildren<PageData>(ContentReference.StartPage, _contentLanguageAccessor.Language);

        var contentReferencesForNavigation = new List<PageData> { home };
        contentReferencesForNavigation.AddRange(children);
        return View("~/SiteDemo1/Components/MainNavigation/Default.cshtml", (NavigationItems: contentReferencesForNavigation, CurrentContentLink : currentContent.ContentLink));
    }
}