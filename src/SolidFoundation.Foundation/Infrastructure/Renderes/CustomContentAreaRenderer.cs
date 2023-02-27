using System.Diagnostics.CodeAnalysis;
using EPiServer.Core;
using EPiServer.Web;
using EPiServer.Web.Mvc.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SolidFoundation.Foundation.Infrastructure.Renderes;

[ExcludeFromCodeCoverage(Justification = "Too complex to unit test very simple logic.")]
public class CustomContentAreaRenderer : ContentAreaRenderer
{
    private readonly IContentAreaLoader _contentAreaLoader;

    public CustomContentAreaRenderer(IContentAreaLoader contentAreaLoader)
    {
        _contentAreaLoader = contentAreaLoader;
    }

    protected override void RenderContentAreaItem(IHtmlHelper htmlHelper, ContentAreaItem contentAreaItem, string templateTag, string htmlTag,
        string cssClass)
    {
        var hasChildContainers = htmlHelper.ViewContext.ViewData["HasItemContainers"] as bool? ?? true;

        if (hasChildContainers)
        {
            base.RenderContentAreaItem(htmlHelper, contentAreaItem, templateTag, htmlTag, cssClass);
        }
        else
        {
            var contentData = _contentAreaLoader.LoadContent(contentAreaItem);
            htmlHelper.RenderContentData(contentData, true, templateTag);
        }
    }
}