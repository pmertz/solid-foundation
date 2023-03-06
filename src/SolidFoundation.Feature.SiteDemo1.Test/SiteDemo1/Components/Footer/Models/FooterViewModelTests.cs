using System.Collections.Generic;
using NSubstitute;
using SolidFoundation.Feature.SiteDemo1.SiteDemo1.Components.Footer.Models;
using Xunit;

namespace SolidFoundation.Feature.SiteDemo1.Test.SiteDemo1.Components.Footer.Models;

public class FooterViewModelTests
{
    [Fact]
    public void Ctor_ShouldInitialize()
    {
        var argumentInput = Substitute.For<IList<SocialMediaFooterLink>>();
        var sut = new FooterViewModel(argumentInput);
        Assert.Equal(argumentInput, sut.SocialMediaFooterLinks);
    }
}