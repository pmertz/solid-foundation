using EPiServer;
using EPiServer.Core;

namespace SolidFoundation.Foundation.Foundation.Models.ViewModels;

public class ContentViewModel<TContent> : IContentViewModel<TContent> 
    where TContent : IContent
{
    public ContentViewModel(TContent currentContent)
    {
        CurrentContent = currentContent;
    }

    public TContent CurrentContent { get; }

    public static IContentViewModel<TContent>? CreateForOriginalType(IContent currentContent) 
    {
        var type = typeof(ContentViewModel<>).MakeGenericType(currentContent.GetOriginalType());
        return Activator.CreateInstance(type, currentContent) as IContentViewModel<TContent>;
    }
}