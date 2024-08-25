using System.Collections.Generic;
using System.Threading.Tasks;

public class ElectionDataService
{
    public Task<List<ElectionResult>> GetElectionDataAsync(int year)
    {
        // Mock data
        var mockData = new List<ElectionResult>
        {
            new ElectionResult { Year = year, CountyName = "Sample County", State = "Sample State", DemocratVotePercentage = 50, RepublicanVotePercentage = 50 }
        };
        return Task.FromResult(mockData);
    }
}