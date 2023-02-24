using System.Globalization;
using EPiServer.Core;
using SolidFoundation.Foundation.Foundation.SiteSettings.Models;

namespace SolidFoundation.Foundation.Foundation.SiteSettings.Services;

public interface ISiteSettingsService
{
    /// <summary>
    /// Get site settings block from start page, will throw exception if setting does not exist.
    /// </summary>
    /// <typeparam name="TSiteSettingsBlock"></typeparam>
    /// <param name="language">If language is not specified, IContentLanguageAccessor.Language will be used</param>
    /// <returns>Site settings block of specific type</returns>
    TSiteSettingsBlock? GetSettingByBlockType<TSiteSettingsBlock>(CultureInfo? language = null)
        where TSiteSettingsBlock : ISiteSettingsBlock;

    /// <summary>
    /// Try GetSetting By BlockType
    /// </summary>
    /// <typeparam name="TSiteSettingsBlock"></typeparam>
    /// <param name="siteSettingsBlock">The setting block. Is null if not settings block of the specific type is found</param>
    /// <param name="language">If language is not specified, IContentLanguageAccessor.Language will be used</param>
    /// <param name="useFallback">Use fallback to master language</param>
    /// <param name="startPageReference">If startPageLink is not specified, ContentReference.StartPage will be used</param>
    /// <returns>True if settings exists or false if not</returns>
    bool TryGetSettingByBlockType<TSiteSettingsBlock>(out TSiteSettingsBlock? siteSettingsBlock, CultureInfo? language = null, bool useFallback = true, ContentReference? startPageReference = null)
        where TSiteSettingsBlock : ISiteSettingsBlock;
}