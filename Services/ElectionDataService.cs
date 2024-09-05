using System.Net.Http.Json;

public class ElectionDataService
{
    private readonly HttpClient _httpClient;

    public ElectionDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ElectionResult>> GetElectionDataAsync(int year)
    {
        try
        {
            var results = await _httpClient.GetFromJsonAsync<List<ElectionResult>>($"data/election_results_{year}.json");
            Console.WriteLine($"Loaded {results.Count} results for year {year}");
            return results;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Error fetching election data for year {year}: {e.Message}");
            return new List<ElectionResult>();
        }
    }
}