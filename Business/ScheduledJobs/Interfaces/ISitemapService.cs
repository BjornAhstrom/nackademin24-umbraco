using nackademin24_umbraco.Business.ViewModels;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace nackademin24_umbraco.Business.ScheduledJobs.Interfaces;

public interface ISitemapService
{
    IEnumerable<IPublishedContent> Pages();
    string GenerateSitemapXml(SitemapViewModel model);
}
