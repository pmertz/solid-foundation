namespace SolidFoundation.Foundation.Foundation.Validation.ContentAreaItemRange;

[AttributeUsage(AttributeTargets.Property)]
public class ContentAreaItemRangeAttribute : Attribute
{
    public ContentAreaItemRangeAttribute(int minimum, int maximum)
    {
        Minimum = minimum;
        Maximum = maximum;
    }

    public int Minimum { get; set; }

    public int Maximum { get; set; }

    public string? ErrorMessage { get; set; }
}