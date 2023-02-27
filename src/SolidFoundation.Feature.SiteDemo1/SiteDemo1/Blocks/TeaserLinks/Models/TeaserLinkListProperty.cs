using EPiServer.Core;
using EPiServer.PlugIn;

namespace SolidFoundation.Feature.SiteDemo1.SiteDemo1.Blocks.TeaserLinks.Models;

[PropertyDefinitionTypePlugIn(GUID = "{FE0702A6-6F4E-49E2-B3AE-949CF97F4904}")]
public class TeaserLinkListProperty : PropertyList<TeaserLink>
{
}