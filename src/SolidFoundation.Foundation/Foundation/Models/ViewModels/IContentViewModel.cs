using EPiServer.Core;

namespace SolidFoundation.Foundation.Foundation.Models.ViewModels;

public interface IContentViewModel<out TContent>
    where TContent : IContent
{
    TContent CurrentContent { get; }
}