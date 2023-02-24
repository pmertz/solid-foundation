using SolidFoundation.Foundation.Foundation.Models.Blocks.MetaData;
using Xunit;

namespace SolidFoundation.Foundation.Test.Foundation.Components.Metadata;

public class MetadataBlockTests
{
    [Fact]
    public void SetDefaultValues_SetsDefaultValues()
    {
        var sut = new MetaDataBlock();
        sut.SetDefaultValues(null!);
        Assert.Equal("index, follow", sut.MetaRobots);
    }
}