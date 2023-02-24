namespace SolidFoundation.Foundation.Infrastructure.Services;

public interface IContentLanguageService
{
    string GetCurrentContentLanguage();
    string GetTextDirection();
}