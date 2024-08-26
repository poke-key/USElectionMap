public class ElectionDataService
{
    private readonly Random _random = new Random();

    public Task<List<ElectionResult>> GetElectionDataAsync(int year)
    {
        var mockData = new List<ElectionResult>();
        for (int i = 1; i <= 3000; i++) // Generating data for 3000 counties
        {
            var democratPercentage = _random.NextDouble() * 100;
            mockData.Add(new ElectionResult
            {
                Year = year,
                CountyFips = i.ToString("D5"),
                CountyName = $"County {i}",
                State = "State",
                DemocratVotePercentage = democratPercentage,
                RepublicanVotePercentage = 100 - democratPercentage
            });
        }
        return Task.FromResult(mockData);
    }
}