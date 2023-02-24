using System.Globalization;
using EPiServer;
using EPiServer.Core;
using SolidFoundation.Foundation.Foundation.SiteSettings.Models;

namespace SolidFoundation.Foundation.Foundation.SiteSettings.Services;

public class SiteSettingsService : ISiteSettingsService
    {
        private readonly IContentLoader _contentLoader;
        private readonly IContentLanguageAccessor _contentLanguageAccessor;

        public SiteSettingsService(IContentLoader contentLoader, IContentLanguageAccessor contentLanguageAccessor)
        {
            _contentLoader = contentLoader;
            _contentLanguageAccessor = contentLanguageAccessor;
        }

        public TSiteSettingsBlock? GetSettingByBlockType<TSiteSettingsBlock>(CultureInfo? language = null)
            where TSiteSettingsBlock : ISiteSettingsBlock
        {
            return TryGetSettingByBlockType(out TSiteSettingsBlock? siteSettingsBlock, language)
                ? siteSettingsBlock
                : throw new Exception(
                    $"{typeof(TSiteSettingsBlock).Name}' site settings block is not found. Make sure that it exists!");
        }
        
        public bool TryGetSettingByBlockType<TSiteSettingsBlock>(out TSiteSettingsBlock? siteSettingsBlock, CultureInfo? language = null, bool useFallback = true, ContentReference? startPageReference = null)
            where TSiteSettingsBlock : ISiteSettingsBlock
        {
            language ??= _contentLanguageAccessor.Language;

            siteSettingsBlock = default;
            if (ContentReference.StartPage == ContentReference.EmptyReference && startPageReference is null)
            {
                return false;

            }
            var startPage = _contentLoader.Get<ISiteSettingsPage>(startPageReference ?? ContentReference.StartPage);
            if (startPage.SiteSettings is null)
            {
                return false;
            }
            var filteredItems = startPage.SiteSettings.Items.Select(i => i.ContentLink).ToList();
            siteSettingsBlock = _contentLoader
                .GetItems(filteredItems, language)
                .OfType<TSiteSettingsBlock>()
                .FirstOrDefault();
            if (siteSettingsBlock is null && useFallback) //fall back to settings in master language
            {
                siteSettingsBlock = _contentLoader
                    .GetItems(filteredItems, startPage.MasterLanguage)
                    .OfType<TSiteSettingsBlock>()
                    .FirstOrDefault();
            }
            return siteSettingsBlock != null;
        }
    }