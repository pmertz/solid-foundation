using EPiServer.Core;

namespace SolidFoundation.Foundation.Foundation.Models.ViewModels;

public interface IBlockViewModel<out TBlock>
    where TBlock : BlockData
{
    TBlock CurrentBlock { get; }
}