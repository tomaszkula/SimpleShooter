using System.Collections.Generic;
using TSG.Model;

public static class TSG_LeaderboardUtility
{
    public static LeaderboardEntryModel CreateLeaderboardEntry(TSG_SaveableLeaderboardEntry _saveableLeaderboardEntry)
    {
        if (_saveableLeaderboardEntry == null)
        {
            return null;
        }

        LeaderboardEntryModel _leaderboardEntry = new LeaderboardEntryModel(_saveableLeaderboardEntry.Name, _saveableLeaderboardEntry.Score);
        return _leaderboardEntry;
    }

    public static List<LeaderboardEntryModel> CreateLeaderboardEntries(List<TSG_SaveableLeaderboardEntry> _saveableLeaderboardEntries)
    {
        if (_saveableLeaderboardEntries == null)
        {
            return null;
        }

        List<LeaderboardEntryModel> _leaderboardEntries = new List<LeaderboardEntryModel>();
        for (int i = 0; i < _saveableLeaderboardEntries.Count; i++)
        {
            if (_saveableLeaderboardEntries[i] == null)
            {
                continue;
            }

            LeaderboardEntryModel _leaderboardEntry = CreateLeaderboardEntry(_saveableLeaderboardEntries[i]);
            _leaderboardEntries.Add(_leaderboardEntry);
        }
        return _leaderboardEntries;
    }

    public static TSG_SaveableLeaderboardEntry CreateSaveableLeaderboardEntry(LeaderboardEntryModel _leaderboardEntry)
    {
        if (_leaderboardEntry == null)
        {
            return null;
        }

        TSG_SaveableLeaderboardEntry _saveableLeaderboardEntry = new TSG_SaveableLeaderboardEntry();
        _saveableLeaderboardEntry.Name = _leaderboardEntry.Name;
        _saveableLeaderboardEntry.Score = _leaderboardEntry.Score;
        return _saveableLeaderboardEntry;
    }

    public static List<TSG_SaveableLeaderboardEntry> CreateSaveableLeaderboardEntries(List<LeaderboardEntryModel> _leaderboardEntries)
    {
        if (_leaderboardEntries == null)
        {
            return null;
        }

        List<TSG_SaveableLeaderboardEntry> _saveableLeaderboardEntries = new List<TSG_SaveableLeaderboardEntry>();
        for (int i = 0; i < _leaderboardEntries.Count; i++)
        {
            if(_leaderboardEntries[i] == null)
            {
                continue;
            }

            TSG_SaveableLeaderboardEntry _saveableLeaderboardEntry = CreateSaveableLeaderboardEntry(_leaderboardEntries[i]);
            _saveableLeaderboardEntries.Add(_saveableLeaderboardEntry);
        }
        return _saveableLeaderboardEntries;
    }
}
