public class ElectionResult
{
    public int Id { get; set; }
    public int Year { get; set; }
    public string CountyFips { get; set; }
    public string CountyName { get; set; }
    public string State { get; set; }
    public double DemocratVotePercentage { get; set; }
    public double RepublicanVotePercentage { get; set; }
}