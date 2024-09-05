public class ElectionResult
{
    public int Year { get; set; }
    public string CountyFips { get; set; }
    public string CountyName { get; set; }
    public string State { get; set; }
    public double DemocratVotePercentage { get; set; }
    public double RepublicanVotePercentage { get; set; }

    public override string ToString()
    {
        return $"Year: {Year}, County: {CountyName}, State: {State}, Dem: {DemocratVotePercentage:F2}%, Rep: {RepublicanVotePercentage:F2}%";
    }
}