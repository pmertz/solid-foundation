namespace SolidFoundation.Feature.SiteDemo1.SiteDemo1.Pages.Products.Models;

public class ProductLink
{
    public ProductLink(string name, string imageUrl, string url)
    {
        Name = name;
        ImageUrl = imageUrl;
        Url = url;
    }

    public string Name { get; }
    public string ImageUrl { get; }
    public string Url { get; }
}