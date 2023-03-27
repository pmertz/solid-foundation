using System;
using System.Collections.Generic;
using System.Reflection;
using EPiServer.Core;
using EPiServer.Validation;
using NSubstitute;
using SolidFoundation.Foundation.OptimizelyExtensions.Models;
using SolidFoundation.Foundation.OptimizelyExtensions.Validation.ContentAreaItemRange;
using Xunit;

namespace SolidFoundation.Foundation.OptimzelyExtensions.Test.Validation.ContentAreaItemRange;

public class ContentAreaItemRangePropertyValidationServiceTests
    {
        [Fact]
        public void ValidateProperty_GivenNoAttribute_ReturnNoError_AndExitEarly()
        {
            var sut = new ContentAreaItemRangePropertyValidationService();
            var testPage = new TestPage();
            var propertyInfoMock = Substitute.For<PropertyInfo>();
            propertyInfoMock.GetCustomAttribute<ContentAreaItemRangeAttribute>().Returns(default(ContentAreaItemRangeAttribute));

            var result = sut.ValidateProperty(testPage, propertyInfoMock);

            Assert.IsType<NoError>(result);
            propertyInfoMock.DidNotReceive().GetValue(Arg.Any<object>());
        }
        
        [Fact]
        public void ValidateProperty_GivenIsNotTypeContentArea_Throw()
        {
            var sut = new ContentAreaItemRangePropertyValidationService();
            var testPage = new TestPage();
            var property = testPage.GetType().GetProperty("NotContentAreaProperty");

            Assert.Throws<ArgumentException>(() => sut.ValidateProperty(testPage, property!));
        }
        
        [Fact]
        public void ValidateProperty_GivenContentAreaPropertyIsNull_ReturnError()
        {
            var sut = new ContentAreaItemRangePropertyValidationService();
            var testPage = new TestPage();
            var property = testPage.GetType().GetProperty("WithAttribute");

            var result = sut.ValidateProperty(testPage, property!);
            
            var error = Assert.IsType<ValidationError>(result);
            Assert.Equal(ValidationErrorSeverity.Error, error.Severity);
        }
        
        [Fact]
        public void ValidateProperty_GivenRangeMinIsGreaterThan0_AndNoItems_ReturnWarning()
        {
            var sut = new ContentAreaItemRangePropertyValidationService();
            var testPage = new TestPage
            {
                WithAttribute = new ContentArea()
            };
            var property = testPage.GetType().GetProperty("WithAttribute");

            var result = sut.ValidateProperty(testPage, property!);
            
            var error = Assert.IsType<ValidationError>(result);
            Assert.Equal(ValidationErrorSeverity.Warning, error.Severity);
        }

        [Fact]
        public void ValidateProperty_GivenRangeMaxIsLesserThan3_And4Items_ReturnError()
        {
            var sut = new ContentAreaItemRangePropertyValidationService();
            var testPage = new TestPage
            {
                WithAttribute = Substitute.For<ContentArea>()
            }; 
            testPage.WithAttribute.Items
                .Returns(new List<ContentAreaItem>() { new(), new(), new(), new() }); //4 items (max 3)
            var property = testPage.GetType().GetProperty("WithAttribute");

            var result = sut.ValidateProperty(testPage, property!);

            var error = Assert.IsType<ValidationError>(result);
            Assert.Equal(ValidationErrorSeverity.Error, error.Severity);
        }

        [Fact]
        public void ValidateProperty_GivenRangeMinIsGreaterThan2_And1Item_ReturnError()
        {
            var sut = new ContentAreaItemRangePropertyValidationService();
            var testPage = new TestPage
            {
                Minimum2Items = Substitute.For<ContentArea>()
            };
            testPage.Minimum2Items.Items
                .Returns(new List<ContentAreaItem>() { new()}); //1 item (min 2)
            var property = testPage.GetType().GetProperty("Minimum2Items");

            var result = sut.ValidateProperty(testPage, property!);

            var error = Assert.IsType<ValidationError>(result);
            Assert.Equal(ValidationErrorSeverity.Error, error.Severity);
        }

        [Fact]
        public void ValidateProperty_GivenRangeMinIs0_AndContentAreaIsNull_ReturnNoError()
        {
            var sut = new ContentAreaItemRangePropertyValidationService();
            var testPage = new TestPage
            {
                WithAttributeMin0 = null
            };
            var property = testPage.GetType().GetProperty("WithAttributeMin0");

            var result = sut.ValidateProperty(testPage, property!);

            Assert.IsType<NoError>(result);
        }

        [Fact]
        public void ValidateProperty_GivenRangeMinIs0_AndNoItems_ReturnNoError()
        {
            var sut = new ContentAreaItemRangePropertyValidationService();
            var testPage = new TestPage
            {
                WithAttributeMin0 = new ContentArea()
            };
            var property = testPage.GetType().GetProperty("WithAttributeMin0");

            var result = sut.ValidateProperty(testPage, property!);
            
            Assert.IsType<NoError>(result);
        }
        
        [Fact]
        public void ValidateProperty_GivenNumberOfItemsIsLessThanMinimum_ReturnError()
        {
            var sut = new ContentAreaItemRangePropertyValidationService();
            var testPage = new TestPage
            {
                WithAttributeMin0 = Substitute.For<ContentArea>()
            };
            testPage.WithAttributeMin0.Items
                .Returns(new List<ContentAreaItem>() { new () });
            var property = testPage.GetType().GetProperty("WithAttributeMin0");

            var result = sut.ValidateProperty(testPage, property!);

            Assert.IsType<NoError>(result);
        } 
        
        [Fact]
        public void ValidateProperty_GivenNumberOfItemsIsGreaterThanMaximum_ReturnError()
        {
            var sut = new ContentAreaItemRangePropertyValidationService();
            var testPage = new TestPage
            {
                Minimum2Items = Substitute.For<ContentArea>()
            };
            testPage.Minimum2Items.Items
                .Returns(new List<ContentAreaItem>() { new (), new (), new (), new () }); //4 items (max 3)
            var property = testPage.GetType().GetProperty("Minimum2Items");

            var result = sut.ValidateProperty(testPage, property!);
            
            var error = Assert.IsType<ValidationError>(result);
            Assert.Equal(ValidationErrorSeverity.Error, error.Severity);
        }
        
        [Fact]
        public void ValidateProperty_GivenCustomErrorMessage_ReturnErrorWithCustomMessage()
        {
            var sut = new ContentAreaItemRangePropertyValidationService();
            var testPage = new TestPage
            {
                WithAttributeIncludingErrorMessage = Substitute.For<ContentArea>()
            };
            testPage.WithAttributeIncludingErrorMessage.Items
                .Returns(new List<ContentAreaItem>() { new (), new (), new (), new () }); //4 items (max 3)
            var property = testPage.GetType().GetProperty("WithAttributeIncludingErrorMessage");

            var result = sut.ValidateProperty(testPage, property!);
            
            var error = Assert.IsType<ValidationError>(result);
            Assert.Equal(ValidationErrorSeverity.Error, error.Severity);
        }        
        
        [Fact]
        public void ValidateProperty_GivenNumberOfItemsIsWithinMinimumAndMaximum_ReturnError()
        {
            var sut = new ContentAreaItemRangePropertyValidationService();
            var testPage = new TestPage
            {
                Minimum2Items = Substitute.For<ContentArea>()
            };
            testPage.Minimum2Items.Items
                .Returns(new List<ContentAreaItem>() { new (), new (), new () }); //4 items (max 3)
            var property = testPage.GetType().GetProperty("Minimum2Items");

            var result = sut.ValidateProperty(testPage, property!);
            
            Assert.IsType<NoError>(result);
        }        
    }
    
    public class TestPage : PageData
    {
        [ContentAreaItemRange(minimum: 1, maximum: 3)]
        public ContentArea? WithAttribute { get; set; }
        
        public ContentArea? NoAttribute { get; set; }
        
        [ContentAreaItemRange(minimum: 1, maximum: 3, ErrorMessage = "You have errors")]
        public ContentArea? WithAttributeIncludingErrorMessage { get; set; }

        [ContentAreaItemRange(minimum: 1, maximum: 3)]
        public string? NotContentAreaProperty { get; set; }
        
        [ContentAreaItemRange(minimum: 0, maximum: 3)]
        public ContentArea? WithAttributeMin0 { get; set; }
        
        [ContentAreaItemRange(minimum: 2, maximum: 3)]
        public ContentArea? Minimum2Items { get; set; } 
    }