using Newtonsoft.Json;

namespace nackademin24_umbraco.Business.Models;

public class Root
{
    [JsonProperty("Search")]
    public List<Movie> Search { get; set; }

    [JsonProperty("totalResults")]
    public string TotalResults { get; set; }

    [JsonProperty("Response")]
    public string Response { get; set; }
}

public class Movie
{
    [JsonProperty("Title")]
    public string Title { get; set; }

    [JsonProperty("Year")]
    public string Year { get; set; }

    [JsonProperty("imdbID")]
    public string imdbID { get; set; }

    [JsonProperty("Type")]
    public string Type { get; set; }

    [JsonProperty("Poster")]
    public string Poster { get; set; }
}