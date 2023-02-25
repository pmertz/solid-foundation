using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using EPiServer.Shell.ObjectEditing;

namespace SolidFoundation.Foundation.Foundation.SelectionFactories;

public class EnumSelectionFactory<TEnum> : ISelectionFactory
    where TEnum : Enum
{
    public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
    {
        var values = Enum.GetValues(typeof(TEnum));
        foreach (TEnum value in values)
        {
            yield return new SelectItem
            {
                Text = GetDisplayName(value),
                Value = value
            };
        }
    }

    private static string GetDisplayName(TEnum value)
    {
        var stringValue = value.ToString();
        
        var fieldInfo = value.GetType().GetField(stringValue);

        var attribute = fieldInfo!.GetCustomAttribute<DisplayAttribute>();

        return attribute?.Name ?? stringValue;
    }
}