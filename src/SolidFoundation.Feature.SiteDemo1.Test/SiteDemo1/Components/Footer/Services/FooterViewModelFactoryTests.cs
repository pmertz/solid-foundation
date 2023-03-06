using System.Collections.Generic;
using NSubstitute;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Components.Footer.Models;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Components.Footer.Services;
using SolidFoundation.Foundation.Foundation.SiteSettings.Services;
using Xunit;

namespace SolidFoundation.Feature.SiteDemo1.Test.SiteDemo1.Components.Footer.Services;

public class FooterViewModelFactoryTests
{
    [Fact]
    public void Create_GivenSocialMediaFooterLinksSettingsIsNotNull_ReturnSocialMediaFooterLinksSettings()
    {
        //arrange
        var siteSettingsService = Substitute.For<ISiteSettingsService>();
        var socialMediaLinks = new List<SocialMediaFooterLink>
            { new() { Name = "Test", CssClass = FooterCssClasses.facebook, Url = "www.facebook.com" } };
        siteSettingsService.GetSettingByBlockType<FooterSiteSettingsBlock>()
            .Returns(new FooterSiteSettingsBlock
            {
                SocialMediaFooterLinks = socialMediaLinks
            });
        var sut = new FooterViewModelFactory(siteSettingsService);

        var result = sut.Create();
        
        Assert.NotNull(result);
        Assert.Equal(socialMediaLinks, result.SocialMediaFooterLinks);
    }
    
    [Fact]
    public void Create_GivenSocialMediaFooterLinksSettingsIsNotNull_ReturnEmptyListOfSocialMediaFooterLinks()
    {
        //arrange
        var siteSettingsService = Substitute.For<ISiteSettingsService>();
        siteSettingsService.GetSettingByBlockType<FooterSiteSettingsBlock>()
            .Returns(new FooterSiteSettingsBlock
            {
                SocialMediaFooterLinks = null
            });
        var sut = new FooterViewModelFactory(siteSettingsService);

        var result = sut.Create();
        
        Assert.NotNull(result);
        Assert.NotNull(result.SocialMediaFooterLinks);
    }
    
    [Fact]
    public void Create_GivenCopyrightMessageSettingsIsNull_ReturnDefaultCopyrightMessage()
    {
        //arrange
        var siteSettingsService = Substitute.For<ISiteSettingsService>();
        siteSettingsService.GetSettingByBlockType<FooterSiteSettingsBlock>()
            .Returns(new FooterSiteSettingsBlock
            {
                SocialMediaFooterLinks = new List<SocialMediaFooterLink>
                    { new() { Name = "Test", CssClass = FooterCssClasses.facebook, Url = "www.facebook.com" } },
                CopyrightMessage = null
            });
        var sut = new FooterViewModelFactory(siteSettingsService);

        var result = sut.Create();
        
        Assert.NotNull(result);
        Assert.Equal("<style class='color:red'>CopyrightMessage does not exist</style>", result.CopyrightMessage);
    }
    
    [Fact]
    public void Create_GivenCopyrightMessageSettingsIsNotNull_ReturnCopyrightMessageFromSettings()
    {
        //arrange
        var siteSettingsService = Substitute.For<ISiteSettingsService>();
        siteSettingsService.GetSettingByBlockType<FooterSiteSettingsBlock>()
            .Returns(new FooterSiteSettingsBlock
            {
                SocialMediaFooterLinks = new List<SocialMediaFooterLink>
                    { new() { Name = "Test", CssClass = FooterCssClasses.facebook, Url = "www.facebook.com" } },
                CopyrightMessage = "Test Copyright message"
            });
        var sut = new FooterViewModelFactory(siteSettingsService);

        var result = sut.Create();
        
        Assert.NotNull(result);
        Assert.Equal("Test Copyright message", result.CopyrightMessage);
    }    
}