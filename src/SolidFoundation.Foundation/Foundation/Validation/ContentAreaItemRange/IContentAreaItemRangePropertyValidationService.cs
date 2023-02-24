using System.Reflection;
using EPiServer.Core;
using EPiServer.Validation;

namespace SolidFoundation.Foundation.Foundation.Validation.ContentAreaItemRange;

public interface IContentAreaItemRangePropertyValidationService
{
    ValidationError ValidateProperty(IContent content, PropertyInfo contentAreaProp);
}