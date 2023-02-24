using EPiServer;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using SolidFoundation.Foundation.Foundation.Extensions;
using SolidFoundation.Foundation.Foundation.Models.BaseModels;
using SolidFoundation.Foundation.Foundation.Models.ViewModels;

namespace SolidFoundation.Foundation.Foundation.Defaults;

[TemplateDescriptor(Inherited = true)]
public class DefaultPageController : PageController<SitePage>
{
    public ActionResult Index(SitePage currentContent)
    {
        var model = ContentViewModel<SitePage>.CreateForOriginalType(currentContent);
        var originalType = currentContent.GetOriginalType();
        var pageName = originalType.Name;
        var viewPath = $"~{originalType.GetRelativePathFromType()}/{pageName}.cshtml";
        return View(viewPath, model);
    }
}