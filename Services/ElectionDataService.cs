using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            return await _httpClient.GetFromJsonAsync<List<ElectionResult>>($"data/election_results_{year}.json");
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Error fetching election data for year {year}: {e.Message}");
            return new List<ElectionResult>();
        }
    }
}