using System.Linq;
using System.Reflection;
using EPiServer.Core;
using NSubstitute;
using SolidFoundation.Foundation.Foundation.Validation.ContentAreaItemRange;
using Xunit;

namespace SolidFoundation.Foundation.Test.Foundation.Validation.ContentAreaItemRange;

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
}