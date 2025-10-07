using nackademin24_umbraco.Business.Models;
using nackademin24_umbraco.Business.Models.Blazor;
using nackademin24_umbraco.Business.Services.Interfaces;
using Newtonsoft.Json;

namespace nackademin24_umbraco.Business.Services;

public class OmdbService : IOmdbService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<OmdbService> _logger;

    public OmdbService(HttpClient httpClient, ILogger<OmdbService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<List<Movie>> SearchAsync(OmdbSearchModel search)
    {
        try
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://www.omdbapi.com/?s={search.Query}&apikey=968a60cf");
            var response = await _httpClient.SendAsync(request);

            if(response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Root>(json);

                if(result != null)
                {
                    return result.Search;
                }
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }

        return [];
    }
}
