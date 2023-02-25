using System.Collections.Generic;

namespace SolidFoundation.Feature.SiteDemo1.SiteDemo1.Components.Footer.Models;

public class FooterViewModel
{
    public FooterViewModel(IList<SocialMediaFooterLink> socialMediaFooterLinks)
    {
        SocialMediaFooterLinks = socialMediaFooterLinks;
    }

    public IList<SocialMediaFooterLink> SocialMediaFooterLinks { get; }
    public string CopyrightMessage { get; set; }
}