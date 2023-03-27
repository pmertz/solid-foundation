using EPiServer.Core;
using SolidFoundation.Foundation.OptimizelyExtensions.Validation.ContentAreaItemRange;

namespace SolidFoundation.Foundation.OptimzelyExtensions.Test.Validation.ContentAreaItemRange;

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