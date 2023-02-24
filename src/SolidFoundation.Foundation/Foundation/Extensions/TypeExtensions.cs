namespace SolidFoundation.Foundation.Foundation.Extensions;

public static class TypeExtensions
{
    public static string GetRelativePathFromType(this Type type)
    {
        var namespaceWithoutAssembly = type.Namespace.Replace(type.Assembly.GetName().Name, string.Empty);
        return namespaceWithoutAssembly.Replace('.', '/');
    }
}