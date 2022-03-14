using System.Collections.Generic;

public static class SS_LeaderboardUtility
{
    public static SS_LeaderboardEntryModel CreateLeaderboardEntry(SS_HighScoreData _saveableLeaderboardEntry)
    {
        if (_saveableLeaderboardEntry == null)
        {
            return null;
        }

        SS_LeaderboardEntryModel _leaderboardEntry = new SS_LeaderboardEntryModel(_saveableLeaderboardEntry.Name, _saveableLeaderboardEntry.Score);
        return _leaderboardEntry;
    }

    public static List<SS_LeaderboardEntryModel> CreateLeaderboardEntries(List<SS_HighScoreData> _saveableLeaderboardEntries)
    {
        if (_saveableLeaderboardEntries == null)
        {
            return null;
        }

        List<SS_LeaderboardEntryModel> _leaderboardEntries = new List<SS_LeaderboardEntryModel>();
        for (int i = 0; i < _saveableLeaderboardEntries.Count; i++)
        {
            if (_saveableLeaderboardEntries[i] == null)
            {
                continue;
            }

            SS_LeaderboardEntryModel _leaderboardEntry = CreateLeaderboardEntry(_saveableLeaderboardEntries[i]);
            _leaderboardEntries.Add(_leaderboardEntry);
        }
        return _leaderboardEntries;
    }

    public static SS_HighScoreData CreateSaveableLeaderboardEntry(SS_LeaderboardEntryModel _leaderboardEntry)
    {
        if (_leaderboardEntry == null)
        {
            return null;
        }

        SS_HighScoreData _saveableLeaderboardEntry = new SS_HighScoreData();
        _saveableLeaderboardEntry.Name = _leaderboardEntry.Name;
        _saveableLeaderboardEntry.Score = _leaderboardEntry.Score;
        return _saveableLeaderboardEntry;
    }

    public static List<SS_HighScoreData> CreateSaveableLeaderboardEntries(List<SS_LeaderboardEntryModel> _leaderboardEntries)
    {
        if (_leaderboardEntries == null)
        {
            return null;
        }

        List<SS_HighScoreData> _saveableLeaderboardEntries = new List<SS_HighScoreData>();
        for (int i = 0; i < _leaderboardEntries.Count; i++)
        {
            if(_leaderboardEntries[i] == null)
            {
                continue;
            }

            SS_HighScoreData _saveableLeaderboardEntry = CreateSaveableLeaderboardEntry(_leaderboardEntries[i]);
            _saveableLeaderboardEntries.Add(_saveableLeaderboardEntry);
        }
        return _saveableLeaderboardEntries;
    }
}
