using nackademin24_umbraco.Business.Extensions;
using nackademin24_umbraco.Business.ScheduledJobs.Interfaces;
using nackademin24_umbraco.Business.ViewModels;
using System.Text;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace nackademin24_umbraco.Business.Services;

public class SitemapService(IUmbracoContextAccessor umbracoContextAccessor) : ISitemapService
{
    private readonly IUmbracoContextAccessor _umbracoContextAccessor = umbracoContextAccessor;

    public IEnumerable<IPublishedContent> Pages()
    {
        if (_umbracoContextAccessor.TryGetUmbracoContext(out var umbracoContext))
        {
            var content = umbracoContext.Content;

            if (content != null)
            {
                var startPage = content.GetAtRoot().DescendantsOrSelf<Start>().FirstOrDefault();

                if (startPage != null)
                {
                    return startPage.DescendantsOrSelf<IPublishedContent>()
                        .Where(page => page is IBase basePage && page.IsPublished()).ToList();
                }
            }
        }
        return [];
    }
    public string GenerateSitemapXml(SitemapViewModel model)
    {
        if (_umbracoContextAccessor.TryGetUmbracoContext(out var umbracoContext))
        {
            var currentCulture = umbracoContext.PublishedRequest?.Culture ?? string.Empty;
            var stringBuilder = new StringBuilder();

            var localizedPages = model.Pages.Where(x  => x.IsPublished(currentCulture)).Select(x => new
            {
                Page = x,
                Url = x.GetFullUrl(currentCulture),
                LastModified = x.UpdateDate
            }).ToList();

            stringBuilder.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            stringBuilder.AppendLine("<urlset xmlns=\"https://www.sitemaps.org/schemas/sitemap/0.9\">");

            foreach ( var page in localizedPages )
            {
                stringBuilder.AppendLine($"<url><loc>{page.Url}</loc><lastmod>{page.LastModified:yyyy-MM-dd HH:mm:ss}</lastmod></url>");
            }
            stringBuilder.AppendLine("</urlset>");

            return stringBuilder.ToString();
        }

        return string.Empty;
    }

    
}
