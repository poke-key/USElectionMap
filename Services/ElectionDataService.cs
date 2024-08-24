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
        //placeholder, actual API call goes here
        return await _httpClient.GetFromJsonAsync<List<ElectionResult>>($"sample-data/election-data-{year}.json");
    }
}