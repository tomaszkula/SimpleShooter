using System;

public class SS_LeaderboardEntryModel : IComparable<SS_LeaderboardEntryModel>
{
	public string Name { get; }
	public int Score { get; }

	public SS_LeaderboardEntryModel(string name, int score)
	{
		Name = name;
		Score = score;
	}

    public int CompareTo(SS_LeaderboardEntryModel _other)
    {
		return _other.Score.CompareTo(Score);
	}
}