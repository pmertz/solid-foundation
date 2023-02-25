using System;
using System.Collections.Generic;
using System.Reflection;
using EPiServer.Core;
using NSubstitute;
using SolidFounation.TestHelpers;
using SolidFoundation.Foundation.Foundation.EditorDescriptors;
using SolidFoundation.Foundation.Foundation.Models.BaseModels;
using Xunit;

namespace SolidFoundation.Foundation.Test.Foundation.EditorDescriptors;

public class HideCategoryEditorDescriptorTests
{
    [Fact]
    public void PropertyWithOwnerContentAndInterface_ShowForEditIsFalse()
    {
        //arrange
        var ownerContent = new TestPageData();

        // IMPORTANT
        var propertyInfo = Substitute.For<PropertyInfo>();
        propertyInfo.Name.Returns("icategorizable_category");
        // IMPORTANT

        var metadata = EditorDescriptorHelper.CreateContentDataMetadata(propertyInfo);
        metadata.OwnerContent = ownerContent;

        //act
        var sut = new HideCategoryEditorDescriptor();
        sut.ModifyMetadata(metadata, new List<Attribute>());

        //assert
        Assert.False(metadata.ShowForEdit);
    }

    [Fact]
    public void PropertyWithOwnerContentAndNoInterface_ChangeShowForEditIsTrue()
    {
        //arrange
        var ownerContent = new PageData();

        // IMPORTANT
        var propertyInfo = Substitute.For<PropertyInfo>();
        propertyInfo.Name.Returns("icategorizable_category");
        // IMPORTANT

        var metadata = EditorDescriptorHelper.CreateContentDataMetadata(propertyInfo);
        metadata.OwnerContent = ownerContent;

        //act
        var sut = new HideCategoryEditorDescriptor();
        sut.ModifyMetadata(metadata, new List<Attribute>());

        //assert
        Assert.True(metadata.ShowForEdit);
    }

    [Fact]
    public void PropertyWithOwnerContentAndInterfaceButIncorrectPropertyName_ChangeShowForEditIsTrue()
    {
        //arrange
        var ownerContent = new TestPageData();

        // IMPORTANT
        var propertyInfo = Substitute.For<PropertyInfo>();
        propertyInfo.Name.Returns("pagename");
        // IMPORTANT

        var metadata = EditorDescriptorHelper.CreateContentDataMetadata(propertyInfo);
        metadata.OwnerContent = ownerContent;

        //act
        var sut = new HideCategoryEditorDescriptor();
        sut.ModifyMetadata(metadata, new List<Attribute>());

        //assert
        Assert.True(metadata.ShowForEdit);
    }

    public class TestPageData : PageData, IHideCategory
    {
    }
}