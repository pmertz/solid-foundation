using EPiServer;
using EPiServer.Core;
using EPiServer.Validation;

namespace SolidFoundation.Foundation.OptimizelyExtensions.Validation.ContentAreaItemRange;

public class ContentAreaItemRangeValidator : IValidate<IContent>
{
    private readonly IContentAreaItemRangePropertyValidationService _propertyValidationService;

    public ContentAreaItemRangeValidator(IContentAreaItemRangePropertyValidationService propertyValidationService)
    {
        _propertyValidationService = propertyValidationService;
    }

    public IEnumerable<ValidationError> Validate(IContent instance)
    {
        var originalType = instance.GetOriginalType();

        var contentAreaProps = originalType.GetProperties().Where(p => p.PropertyType == typeof(ContentArea));

        foreach (var contentAreaProp in contentAreaProps)
        {
            var error = _propertyValidationService.ValidateProperty(instance, contentAreaProp);
            if(error is not null)
                yield return error;
        }
    }
}