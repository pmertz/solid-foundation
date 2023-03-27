using System.Linq;
using System.Reflection;
using EPiServer.Core;
using NSubstitute;
using SolidFoundation.Foundation.OptimizelyExtensions.Validation.ContentAreaItemRange;
using Xunit;

namespace SolidFoundation.Foundation.OptimzelyExtensions.Test.Validation.ContentAreaItemRange;

public class ContentAreaItemRangeValidatorTests
{
    [Fact]
    public void Validate_GivenHaveContentArea_CallPropertyValidationService()
    {
        var contentAreaItemRangePropertyValidationServiceMock =
            Substitute.For<IContentAreaItemRangePropertyValidationService>();
        var sut = new ContentAreaItemRangeValidator(contentAreaItemRangePropertyValidationServiceMock);
        var testPage = new TestPage();

        var result = sut.Validate(testPage).ToList();

        contentAreaItemRangePropertyValidationServiceMock
            .Received()
            .ValidateProperty(Arg.Any<IContent>(), Arg.Any<PropertyInfo>());
    }
    
    [Fact]
    public void Validate_GivenVaildationError_ReturnError()
    {
        var contentAreaItemRangePropertyValidationServiceMock =
            Substitute.For<IContentAreaItemRangePropertyValidationService>();
        var sut = new ContentAreaItemRangeValidator(contentAreaItemRangePropertyValidationServiceMock);
        var testPage = new TestPage();

        var result = sut.Validate(testPage).ToList();

        contentAreaItemRangePropertyValidationServiceMock
            .Received()
            .ValidateProperty(Arg.Any<IContent>(), Arg.Any<PropertyInfo>());
    }    
}