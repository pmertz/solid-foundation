using System.Globalization;
using EPiServer.Core;

namespace SolidFoundation.Foundation.Foundation.SiteSettings.Models;

public interface ISiteSettingsPage : IContentData
{
    CultureInfo Language { get;  }
    CultureInfo MasterLanguage { get;  }
    ContentArea? SiteSettings { get;  }
}