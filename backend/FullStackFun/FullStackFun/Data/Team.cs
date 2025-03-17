namespace FullStackFun.Data;

public class Team
{
    public int TeamID { get; set; }
    public string TeamName { get; set; }

    // Navigation Property for Relationship
    public List<Bowler> Bowlers { get; set; } = new();
}
