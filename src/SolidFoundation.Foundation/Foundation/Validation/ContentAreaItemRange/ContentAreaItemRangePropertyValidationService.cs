using System.Reflection;
using EPiServer.Core;
using EPiServer.Validation;
using SolidFoundation.Foundation.Foundation.Models;

namespace SolidFoundation.Foundation.Foundation.Validation.ContentAreaItemRange;

public class ContentAreaItemRangePropertyValidationService : IContentAreaItemRangePropertyValidationService
    {
        public ValidationError ValidateProperty(IContent content, PropertyInfo contentAreaProp)
        {
            var range = contentAreaProp.GetCustomAttribute<ContentAreaItemRangeAttribute>();
            if (range is null)
                return new NoError();

            if (contentAreaProp.PropertyType != typeof(ContentArea))
                throw new ArgumentException("ContentAreaItemRange attribute is used on a non ContentArea property.");
            
            var contentAreaValue = contentAreaProp.GetValue(content);
            if(contentAreaValue is null && range.Minimum == 0)
            {
                return new NoError();
            }

            if (contentAreaValue is not ContentArea contentArea)
            {
                return CreateError(range.ErrorMessage, ValidationErrorSeverity.Error, contentAreaProp.Name, range);
            }

            var itemCount = contentArea.Items.Count;
            if (range.Minimum > 0 && itemCount == 0)
            {
                return CreateError(range.ErrorMessage, ValidationErrorSeverity.Warning, contentAreaProp.Name, range);
            }
            
            if (itemCount < range.Minimum || itemCount > range.Maximum)
            {
                return CreateError(range.ErrorMessage, ValidationErrorSeverity.Error, contentAreaProp.Name, range);
            }

            return new NoError();
        }
        
        private static ValidationError CreateError(string? errorMessage, ValidationErrorSeverity severity, string propertyName, ContentAreaItemRangeAttribute rangeAttribute)
        {
            return new ValidationError
            {
                ErrorMessage = errorMessage ?? $"{propertyName} should contain between {rangeAttribute.Minimum} and {rangeAttribute.Maximum} items",
                Severity = severity,
                ValidationType = ValidationErrorType.PropertyValidation,
                PropertyName = propertyName
            };            
        }
    }