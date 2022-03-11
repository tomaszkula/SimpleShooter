using System;

namespace TSG.Model
{
	public class LeaderboardEntryModel : IComparable<LeaderboardEntryModel>
	{
		public string Name { get; }
		public int Score { get; }

		public LeaderboardEntryModel(string name, int score)
		{
			Name = name;
			Score = score;
		}

        public int CompareTo(LeaderboardEntryModel _other)
        {
			return _other.Score.CompareTo(Score);
		}
    }
}