using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using SolidFoundation.Foundation.Foundation.Extensions;
using SolidFoundation.Foundation.Foundation.Models.BaseModels;
using SolidFoundation.Foundation.Foundation.Models.ViewModels;

namespace SolidFoundation.Foundation.Foundation.Defaults;

[TemplateDescriptor(Inherited = true)]
public class DefaultBlockViewComponent : AsyncBlockComponent<SiteBlock>
{
    protected override async Task<IViewComponentResult> InvokeComponentAsync(SiteBlock currentBlock)
    {
        var model = CreateModel(currentBlock);
        var originalType = currentBlock.GetOriginalType();
        var blockName = originalType.Name;
        var viewPath = $"~{originalType.GetRelativePathFromType()}/{blockName}.cshtml";
        return await Task.FromResult(View(viewPath, model));
    }

    private static IBlockViewModel<BlockData>? CreateModel(BlockData currentBlock)
    {
        var type = typeof(BlockViewModel<>).MakeGenericType(currentBlock.GetOriginalType());
        return Activator.CreateInstance(type, currentBlock) as IBlockViewModel<BlockData>;
    }
}