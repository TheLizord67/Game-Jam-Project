[System.Serializable]

public class LeaderboardEntry
{
    public string key;
    public int value;

    public LeaderboardEntry() { }

    public LeaderboardEntry(string key, int value)
    {
        this.key = key; 
        this.value = value;
    }
}
