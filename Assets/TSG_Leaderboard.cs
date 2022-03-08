namespace TSG.Game
{
    using System.Collections.Generic;
    using TSG.Model;
    using UnityEngine;
    using System.Linq;

    public class TSG_Leaderboard : MonoBehaviour
    {
        [Header("Variables")]
        [SerializeField] int maxHighscoresDataCount = 10;

        LeaderboardEntryModel[] leaderboardEntries = new LeaderboardEntryModel[0];
        int score = 0;

        public int MaxHighscoresDataCount => maxHighscoresDataCount;

        [Header("Events")]
        [SerializeField] TSG_GameEvent onHighscoreDataUpdate = null;

        private void Awake()
        {
            leaderboardEntries = new LeaderboardEntryModel[maxHighscoresDataCount];
        }

        private void Start()
        {
            load();
        }

        #region Callbacks
        public void OnSaveLoad()
        {
            load();
        }

        public void OnScoreUpdate(TSG_GameEventData _gameEventData)
        {
            score = _gameEventData.IntValues[0];
        }

        public void OnPlayerDeath()
        {
            LeaderboardEntryModel _highscoreData = new LeaderboardEntryModel("Test", score);
            addHighscore(_highscoreData);
        }
        #endregion

        #region Save System
        private void load()
        {
            List<LeaderboardEntryModel> _leaderboardEntries = TSG_LeaderboardUtility.CreateLeaderboardEntries(TSG_SaveSystem.SaveData.SaveableLeaderboardEntries);
            for (int i = 0; i < _leaderboardEntries.Count && i < leaderboardEntries.Length; i++)
            {
                leaderboardEntries[i] = _leaderboardEntries[i];
            }

            refreshLeaderboardEntries();
        }

        private void save()
        {
            List<TSG_SaveableLeaderboardEntry> _saveableLeaderboardEntries = TSG_LeaderboardUtility.CreateSaveableLeaderboardEntries(leaderboardEntries.ToList());
            TSG_SaveSystem.SaveData.SaveableLeaderboardEntries = _saveableLeaderboardEntries;

            TSG_SaveSystem.Save();
        }
        #endregion

        private void addHighscore(LeaderboardEntryModel _leadeboardEntry)
        {
            for (int i = 0; i < leaderboardEntries.Length; i++)
            {
                if (leaderboardEntries[i] == null)
                {
                    leaderboardEntries[i] = _leadeboardEntry;
                    refreshLeaderboardEntry(i, _leadeboardEntry);
                    break;
                }
                else if (leaderboardEntries[i].Score < _leadeboardEntry.Score)
                {
                    lowerHighscoresFrom(i);
                    leaderboardEntries[i] = _leadeboardEntry;
                    refreshLeaderboardEntry(i, _leadeboardEntry);
                    break;
                }
            }

            save();
        }

        private void lowerHighscoresFrom(int _highscoreDataId)
        {
            if (_highscoreDataId < 0 || _highscoreDataId >= leaderboardEntries.Length)
            {
                return;
            }

            for (int i = leaderboardEntries.Length - 1; i > _highscoreDataId; i--)
            {
                leaderboardEntries[i] = leaderboardEntries[i - 1];
                refreshLeaderboardEntry(i, leaderboardEntries[i - 1]);
            }
        }

        private void refreshLeaderboardEntries()
        {
            for (int i = 0; i < leaderboardEntries.Length; i++)
            {
                refreshLeaderboardEntry(i, leaderboardEntries[i]);
            }
        }

        private void refreshLeaderboardEntry(int _highscoreDataId, LeaderboardEntryModel _highscoreData)
        {
            onHighscoreDataUpdate?.Invoke(new TSG_GameEventData()
            {
                IntValues = new int[] { _highscoreDataId },
                ObjectValues = new object[] { _highscoreData }
            });
        }
    }
}