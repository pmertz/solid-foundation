using System.Reflection;
using EPiServer.Core;
using EPiServer.Validation;

namespace SolidFoundation.Foundation.OptimizelyExtensions.Validation.ContentAreaItemRange;

public interface IContentAreaItemRangePropertyValidationService
{
    ValidationError ValidateProperty(IContent content, PropertyInfo contentAreaProp);
}