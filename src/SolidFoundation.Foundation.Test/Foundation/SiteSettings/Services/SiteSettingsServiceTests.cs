using System;
using System.Collections.Generic;
using System.Globalization;
using EPiServer;
using EPiServer.Core;
using NSubstitute;
using SolidFoundation.Foundation.Foundation.SiteSettings.Models;
using SolidFoundation.Foundation.Foundation.SiteSettings.Services;
using Xunit;
// ReSharper disable SuspiciousTypeConversion.Global

namespace SolidFoundation.Foundation.Test.Foundation.SiteSettings.Services;

public class SiteSettingsServiceTests
    {
        [Fact]
        public void TryGetSettingByBlockType_GivenLanguageArgIsNull_ReturnSettingsBlockUsingLanguageFromContentLanguageAccessor()
        {
            //arrange
            var contentAreaMock = Substitute.For<ContentArea>();
            contentAreaMock.Items.Returns(new List<ContentAreaItem> { new ContentAreaItem { ContentLink = new ContentReference(666) } });
            var siteSettingsContentAreaMock = Substitute.For<ContentArea>();
            var siteSettingsPageMock = Substitute.For<ISiteSettingsPage>();
            siteSettingsPageMock.SiteSettings.Returns(siteSettingsContentAreaMock);
            siteSettingsPageMock.Language.Returns(new CultureInfo("en-US"));

            var contentLoaderMock = Substitute.For<IContentLoader>();
            contentLoaderMock.Get<ISiteSettingsPage>(Arg.Any<ContentReference>()).Returns(siteSettingsPageMock);

            var testSiteSettingsUsMaster = Substitute.For<IContent, ILocalizable, TestSiteSettings>();
            ((ILocalizable)testSiteSettingsUsMaster).Language.Returns(new CultureInfo("en-US"));
            var testSiteSettingsGb = Substitute.For<IContent, ILocalizable, TestSiteSettings>();
            ((ILocalizable)testSiteSettingsGb).Language.Returns(new CultureInfo("en-GB"));

            contentLoaderMock.GetItems(Arg.Any<IEnumerable<ContentReference>>(), Arg.Is<CultureInfo>(c => c.Name == "en-US")).Returns(new List<IContent> { testSiteSettingsUsMaster });
            contentLoaderMock.GetItems(Arg.Any<IEnumerable<ContentReference>>(), Arg.Is<CultureInfo>(c => c.Name == "en-GB")).Returns(new List<IContent> { testSiteSettingsGb });
            var contentLanguageAccessorMock = Substitute.For<IContentLanguageAccessor>();
            contentLanguageAccessorMock.Language.Returns(new CultureInfo("en-GB"));

            var sut = new SiteSettingsService(contentLoaderMock, contentLanguageAccessorMock);
            ContentReference.StartPage = new PageReference(new ContentReference(99));

            //act
            var result = sut.TryGetSettingByBlockType(out TestSiteSettings? siteSettings);

            //assert
            Assert.True(result);
            Assert.IsAssignableFrom<TestSiteSettings>(siteSettings);
            Assert.Equal("en-GB", ((ILocalizable)siteSettings!)?.Language.Name);
        }

        [Fact]
        public void TryGetSettingByBlockType_GivenStartPageLinkIsNotNull_ReturnTrueAndOutSettingsBlock()
        {
            //arrange
            var contentAreaMock = Substitute.For<ContentArea>();
            contentAreaMock.Items.Returns(new List<ContentAreaItem> { new ContentAreaItem { ContentLink = new ContentReference(666) } });
            var siteSettingsContentAreaMock = Substitute.For<ContentArea>();
            var siteSettingsPageMock = Substitute.For<ISiteSettingsPage>();
            siteSettingsPageMock.SiteSettings.Returns(siteSettingsContentAreaMock);

            var contentLoaderMock = Substitute.For<IContentLoader>();
            contentLoaderMock.Get<ISiteSettingsPage>(Arg.Any<ContentReference>()).Returns(siteSettingsPageMock);

            ContentReference.StartPage = new PageReference(new ContentReference(99));
            var startPageLink = new PageReference(new ContentReference(98));

            var testSiteSettings = Substitute.For<IContent, ILocalizable, TestSiteSettings>();

            contentLoaderMock.GetItems(Arg.Any<IEnumerable<ContentReference>>(), Arg.Any<CultureInfo>()).Returns(new List<IContent> { testSiteSettings });
            var contentLanguageAccessorMock = Substitute.For<IContentLanguageAccessor>();

            var sut = new SiteSettingsService(contentLoaderMock, contentLanguageAccessorMock);

            //act
            var result = sut.TryGetSettingByBlockType(out TestSiteSettings? siteSettings, startPageReference: startPageLink);

            //assert
            Assert.True(result);
            Assert.IsAssignableFrom<TestSiteSettings>(siteSettings);
        }

        [Fact]
        public void TryGetSettingByBlockType_GivenSettingsExistsInSpecificLanguage_ReturnTrueAndOutSettingsBlockInSpecificLanguage()
        {
            //arrange
            var contentAreaMock = Substitute.For<ContentArea>();
            contentAreaMock.Items.Returns(new List<ContentAreaItem> { new ContentAreaItem { ContentLink = new ContentReference(666) } });
            var siteSettingsContentAreaMock = Substitute.For<ContentArea>();
            var siteSettingsPageMock = Substitute.For<ISiteSettingsPage>();
            siteSettingsPageMock.SiteSettings.Returns(siteSettingsContentAreaMock);
            siteSettingsPageMock.Language.Returns(new CultureInfo("en-US"));

            var contentLoaderMock = Substitute.For<IContentLoader>();
            contentLoaderMock.Get<ISiteSettingsPage>(Arg.Any<ContentReference>()).Returns(siteSettingsPageMock);

            var testSiteSettingsUsMaster = Substitute.For<IContent, ILocalizable, TestSiteSettings>();
            ((ILocalizable)testSiteSettingsUsMaster).Language.Returns(new CultureInfo("en-US"));
            var testSiteSettingsGb = Substitute.For<IContent, ILocalizable, TestSiteSettings>();
            ((ILocalizable)testSiteSettingsGb).Language.Returns(new CultureInfo("en-Gb"));

            contentLoaderMock.GetItems(Arg.Any<IEnumerable<ContentReference>>(), Arg.Is<CultureInfo>(c => c.Name == "en-US")).Returns(new List<IContent> { testSiteSettingsUsMaster });
            contentLoaderMock.GetItems(Arg.Any<IEnumerable<ContentReference>>(), Arg.Is<CultureInfo>(c => c.Name == "en-GB")).Returns(new List<IContent> { testSiteSettingsGb });
            var contentLanguageAccessorMock = Substitute.For<IContentLanguageAccessor>();

            var sut = new SiteSettingsService(contentLoaderMock, contentLanguageAccessorMock);
            ContentReference.StartPage = new PageReference(new ContentReference(99));

            //act
            var result = sut.TryGetSettingByBlockType(out TestSiteSettings? siteSettings, new CultureInfo("en-GB"));

            //assert
            Assert.True(result);
            Assert.IsAssignableFrom<TestSiteSettings>(siteSettings);
            Assert.Equal("en-GB", ((ILocalizable)siteSettings!).Language.Name);
        }

        [Fact]
        public void TryGetSettingByBlockType_GivenSettingsDoesNotExistInSpecificLanguageButExistsInMasterLanguage_ReturnTrueAndOutSettingsInMasterLanguage()
        {
            //arrange
            var contentAreaMock = Substitute.For<ContentArea>();
            contentAreaMock.Items.Returns(new List<ContentAreaItem> { new ContentAreaItem { ContentLink = new ContentReference(666) } });
            var siteSettingsContentAreaMock = Substitute.For<ContentArea>();
            var siteSettingsPageMock = Substitute.For<ISiteSettingsPage>();
            siteSettingsPageMock.SiteSettings.Returns(siteSettingsContentAreaMock);
            siteSettingsPageMock.Language.Returns(new CultureInfo("en-GB"));
            siteSettingsPageMock.MasterLanguage.Returns(new CultureInfo("en-US"));

            var contentLoaderMock = Substitute.For<IContentLoader>();
            contentLoaderMock.Get<ISiteSettingsPage>(Arg.Any<ContentReference>()).Returns(siteSettingsPageMock);

            var testSiteSettingsUs = Substitute.For<IContent, ILocalizable, TestSiteSettings>();
            ((ILocalizable)testSiteSettingsUs).Language.Returns(new CultureInfo("en-US"));

            contentLoaderMock.GetItems(Arg.Any<IEnumerable<ContentReference>>(), Arg.Is<CultureInfo>(c => c.Name == "en-US")).Returns(new List<IContent> { testSiteSettingsUs });
            contentLoaderMock.GetItems(Arg.Any<IEnumerable<ContentReference>>(), Arg.Is<CultureInfo>(c => c.Name == "en-GB")).Returns(new List<IContent>
                {
                    null!
                });
            var contentLanguageAccessorMock = Substitute.For<IContentLanguageAccessor>();

            var sut = new SiteSettingsService(contentLoaderMock, contentLanguageAccessorMock);
            ContentReference.StartPage = new PageReference(new ContentReference(99));

            //act
            var result = sut.TryGetSettingByBlockType(out TestSiteSettings? siteSettings, new CultureInfo("en-GB"));

            //assert
            Assert.True(result);
            Assert.IsAssignableFrom<TestSiteSettings>(siteSettings);
            Assert.Equal("en-US", ((ILocalizable)siteSettings!).Language.Name);
        }

        
        [Fact]
        public void TryGetSettingByBlockType_GivenSettingsDoesNotExists_ReturnFalse()
        {
            //arrange
            var siteSettingsContentAreaMock = Substitute.For<ContentArea>();
            var siteSettingsPageMock = Substitute.For<ISiteSettingsPage>();
            siteSettingsPageMock.SiteSettings.Returns(siteSettingsContentAreaMock);

            var contentLoaderMock = Substitute.For<IContentLoader>();
            contentLoaderMock.Get<ISiteSettingsPage>(Arg.Any<ContentReference>()).Returns(siteSettingsPageMock);

            contentLoaderMock.GetItems(Arg.Any<IEnumerable<ContentReference>>(), Arg.Any<CultureInfo>()).Returns(new List<IContent>());

            var testSiteSettings2 = Substitute.For<IContent, TestSiteSettings2 >();

            contentLoaderMock.GetItems(Arg.Any<IEnumerable<ContentReference>>(), Arg.Any<CultureInfo>()).Returns(new List<IContent> { testSiteSettings2 });
            var contentLanguageAccessorMock = Substitute.For<IContentLanguageAccessor>();

            var sut = new SiteSettingsService(contentLoaderMock, contentLanguageAccessorMock);
            ContentReference.StartPage = new PageReference(new ContentReference(99));

            //act
            var result = sut.TryGetSettingByBlockType(out TestSiteSettings? siteSettings);

            //assert
            Assert.False(result);
            Assert.Null(siteSettings);
        }

        [Fact]
        public void TryGetSettingByBlockType_GivenSettingsContentAreaIsNull_ReturnFalse()
        {
            //arrange
            var siteSettingsPageMock = Substitute.For<ISiteSettingsPage>();
            siteSettingsPageMock.SiteSettings.Returns(default(ContentArea));

            var contentLoaderMock = Substitute.For<IContentLoader>();
            contentLoaderMock.Get<ISiteSettingsPage>(Arg.Any<ContentReference>()).Returns(siteSettingsPageMock);

            var contentLanguageAccessorMock = Substitute.For<IContentLanguageAccessor>();

            var sut = new SiteSettingsService(contentLoaderMock, contentLanguageAccessorMock);
            ContentReference.StartPage = new PageReference(new ContentReference(99));

            //act
            var result = sut.TryGetSettingByBlockType(out TestSiteSettings? siteSettings);

            //assert
            Assert.False(result);
            Assert.Null(siteSettings);
        }

        [Fact]
        public void TryGetSettingByBlockType_GivenStartPageIsContentReferenceEmptyAndStartPageLinkIsNull_ReturnFalse()
        {
            //arrange
            var siteSettingsPageMock = Substitute.For<ISiteSettingsPage>();
            siteSettingsPageMock.SiteSettings.Returns(default(ContentArea));

            var contentLoaderMock = Substitute.For<IContentLoader>();
            contentLoaderMock.Get<ISiteSettingsPage>(Arg.Any<ContentReference>()).Returns(siteSettingsPageMock);

            var contentLanguageAccessorMock = Substitute.For<IContentLanguageAccessor>();

            var sut = new SiteSettingsService(contentLoaderMock, contentLanguageAccessorMock);
            ContentReference.StartPage = new PageReference(ContentReference.EmptyReference);

            //act
            var result = sut.TryGetSettingByBlockType(out TestSiteSettings? siteSettings);

            //assert
            Assert.False(result);
            Assert.Null(siteSettings);
        }

        [Fact]
        public void GetSettingByBlockType_GivenSettingsExists_ReturnSiteSettingsBlock()
        {
            //arrange
            var contentAreaMock = Substitute.For<ContentArea>();
            contentAreaMock.Items.Returns(new List<ContentAreaItem> { new ContentAreaItem { ContentLink = new ContentReference(666) } });
            var siteSettingsContentAreaMock = Substitute.For<ContentArea>();
            var siteSettingsPageMock = Substitute.For<ISiteSettingsPage>();
            siteSettingsPageMock.SiteSettings.Returns(siteSettingsContentAreaMock);

            var contentLoaderMock = Substitute.For<IContentLoader>();
            contentLoaderMock.Get<ISiteSettingsPage>(Arg.Any<ContentReference>()).Returns(siteSettingsPageMock);

            var testSiteSettings = Substitute.For<IContent, TestSiteSettings>();

            contentLoaderMock.GetItems(Arg.Any<IEnumerable<ContentReference>>(), Arg.Any<CultureInfo>()).Returns(new List<IContent> { testSiteSettings });

            var contentLanguageAccessorMock = Substitute.For<IContentLanguageAccessor>();

            var sut = new SiteSettingsService(contentLoaderMock, contentLanguageAccessorMock);
            ContentReference.StartPage = new PageReference(new ContentReference(99));
            //act
            var result = sut.GetSettingByBlockType<TestSiteSettings>();

            //assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<TestSiteSettings>(result);
        }

        [Fact]
        public void GetSettingByBlockType_GivenSettingsDoesNotExist_ThrowException()
        {
            //arrange
            var contentAreaMock = Substitute.For<ContentArea>();
            contentAreaMock.Items.Returns(new List<ContentAreaItem> { new ContentAreaItem { ContentLink = new ContentReference(666) } });
            var siteSettingsContentAreaMock = Substitute.For<ContentArea>();
            var siteSettingsPageMock = Substitute.For<ISiteSettingsPage>();
            siteSettingsPageMock.SiteSettings.Returns(siteSettingsContentAreaMock);

            var contentLoaderMock = Substitute.For<IContentLoader>();
            contentLoaderMock.Get<ISiteSettingsPage>(Arg.Any<ContentReference>()).Returns(siteSettingsPageMock);

            var testSiteSettings2 = Substitute.For<IContent, TestSiteSettings2>();

            contentLoaderMock.GetItems(Arg.Any<IEnumerable<ContentReference>>(), Arg.Any<CultureInfo>()).Returns(new List<IContent> { testSiteSettings2 });

            var contentLanguageAccessorMock = Substitute.For<IContentLanguageAccessor>();

            var sut = new SiteSettingsService(contentLoaderMock, contentLanguageAccessorMock);
            ContentReference.StartPage = new PageReference(new ContentReference(99));

            //act / assert
            Assert.ThrowsAny<Exception>(() => sut.GetSettingByBlockType<TestSiteSettings>());
        }
    }

    public class TestSiteSettings : BlockData, ISiteSettingsBlock
    {
    }
    public class TestSiteSettings2 : BlockData, ISiteSettingsBlock
    {
    }