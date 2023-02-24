using EPiServer.Core;

namespace SolidFoundation.Foundation.Infrastructure.Services;

public class ContentLanguageService : IContentLanguageService
{
    private readonly IContentLanguageAccessor _contentLanguageAccessor;

    public ContentLanguageService(IContentLanguageAccessor contentLanguageAccessor)
    {
        _contentLanguageAccessor = contentLanguageAccessor;
    }

    public string GetCurrentContentLanguage()
    {
        var currentLanguage = _contentLanguageAccessor.Language;
        return currentLanguage.Name.ToLower();
    }

    public string GetTextDirection()
    {
        var currentLanguage = _contentLanguageAccessor.Language;
        return currentLanguage.TextInfo.IsRightToLeft ? "rtl" : "ltr";
    }
}