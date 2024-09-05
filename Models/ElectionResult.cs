public class ElectionResult
{
    public int Year { get; set; }
    private string _countyFips;
    public string CountyFips
    {
        get => _countyFips;
        set => _countyFips = value.PadLeft(5, '0'); // Ensure it's always 5 digits
    }
    public string CountyName { get; set; }
    public string State { get; set; }
    public double DemocratVotePercentage { get; set; }
    public double RepublicanVotePercentage { get; set; }

    public override string ToString()
    {
        return $"Year: {Year}, County: {CountyName}, State: {State}, Fips: {CountyFips}, Dem: {DemocratVotePercentage:F2}%, Rep: {RepublicanVotePercentage:F2}%";
    }
}