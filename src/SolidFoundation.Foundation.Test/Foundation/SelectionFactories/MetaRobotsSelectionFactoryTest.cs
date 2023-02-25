using System.Linq;
using System.Reflection;
using NSubstitute;
using SolidFounation.TestHelpers;
using SolidFoundation.Foundation.Foundation.SelectionFactories;
using Xunit;

namespace SolidFoundation.Foundation.Test.Foundation.SelectionFactories;

public class MetaRobotsSelectionFactoryTest
{
    [Fact]
    public void GetSelections_Returns()
    {
        var propertyInfo = Substitute.For<PropertyInfo>();
        var sut = new MetaRobotsSelectionFactory();
        var result = sut.GetSelections(EditorDescriptorHelper.CreateContentDataMetadata(propertyInfo));
        Assert.True(result.Count() == 4);
    }
}