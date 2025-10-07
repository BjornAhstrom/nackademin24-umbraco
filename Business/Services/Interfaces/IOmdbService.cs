using nackademin24_umbraco.Business.Models;
using nackademin24_umbraco.Business.Models.Blazor;

namespace nackademin24_umbraco.Business.Services.Interfaces;

public interface IOmdbService
{
    Task<List<Movie>> SearchAsync(OmdbSearchModel search);
}
