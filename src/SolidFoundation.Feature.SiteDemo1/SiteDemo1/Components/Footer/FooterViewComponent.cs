using Microsoft.AspNetCore.Mvc;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Components.Footer.Services;

namespace SolidFoundation.Feature.SiteDemo1.SiteDemo1.Components.Footer;

public class FooterViewComponent : ViewComponent
{
    private readonly IFooterViewModelFactory _footerViewModelFactory;

    public FooterViewComponent(IFooterViewModelFactory footerViewModelFactory)
    {
        _footerViewModelFactory = footerViewModelFactory;
    }

    public IViewComponentResult Invoke()
    {
        var viewModel = _footerViewModelFactory.Create();
        return View("~/SiteDemo1/Components/Footer/Default.cshtml", viewModel);
    }
}