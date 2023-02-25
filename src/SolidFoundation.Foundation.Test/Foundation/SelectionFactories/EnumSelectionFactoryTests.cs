using System.ComponentModel.DataAnnotations;
using System.Reflection;
using EPiServer.Shell.ObjectEditing;
using NSubstitute;
using SolidFounation.TestHelpers;
using SolidFoundation.Foundation.Foundation.SelectionFactories;
using Xunit;

namespace SolidFoundation.Foundation.Test.Foundation.SelectionFactories;

public class EnumSelectionFactoryTests
{
    [Fact]
    public void GetSelections_GivenEnumHasDisplayNameAttributes_ReturnWithNamesFromDisplayNameAttribute()
    {
        // arrange
        var sut = new EnumSelectionFactory<WithDisplayAttributeWithName>();

        // act 
        var result = sut.GetSelections(GetTestExtendedMetadata());

        //assert
        Assert.Collection(result,
            item => Assert.Equal("Display Name Value 1", item.Text),
            item => Assert.Equal("Display Name Value 2", item.Text)
        );
    }

    [Fact]
    public void GetSelections_GivenEnumHasDisplayAttributesButNoName_ReturnValues()
    {
        // arrange
        var sut = new EnumSelectionFactory<WithDisplayAttributeNoName>();

        // act 
        var result = sut.GetSelections(GetTestExtendedMetadata());

        //assert
        Assert.Collection(result,
            item => Assert.Equal("Value1", item.Text),
            item => Assert.Equal("Value2", item.Text)
        );
    }

    [Fact]
    public void GetSelections_GivenEnumHHasNoDisplayAttributes_ReturnValues()
    {
        // arrange
        var sut = new EnumSelectionFactory<NoDisplayAttribute>();

        // act 
        var result = sut.GetSelections(GetTestExtendedMetadata());

        //assert
        Assert.Collection(result,
            item => Assert.Equal("Value1", item.Text),
            item => Assert.Equal("Value2", item.Text)
        );
    }

    private static ExtendedMetadata GetTestExtendedMetadata()
    {
        // IMPORTANT
        var propertyInfo = Substitute.For<PropertyInfo>();
        // IMPORTANT

        var metadata = EditorDescriptorHelper.CreateContentDataMetadata(propertyInfo);
        return metadata;
    }
}

public enum WithDisplayAttributeWithName
{
    [Display(Name = "Display Name Value 1")]
    Value1,

    [Display(Name = "Display Name Value 2")]
    Value2
}

public enum WithDisplayAttributeNoName
{
    [Display]
    Value1,

    [Display]
    Value2
}

public enum NoDisplayAttribute
{
    Value1,
    Value2
}