using EPiServer.Core;

namespace SolidFoundation.Foundation.Foundation.Models.ViewModels;

public class BlockViewModel<TBlock> : IBlockViewModel<TBlock> 
    where TBlock : BlockData
{
    public BlockViewModel(TBlock currentBlock) => CurrentBlock = currentBlock;

    public TBlock CurrentBlock { get; }
}