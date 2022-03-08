namespace TSG.Game
{
    using TSG.Model;
    using UnityEngine;

    public class TSG_Leaderboard : MonoBehaviour
    {
        [Header("Variables")]
        [SerializeField] int maxHighscoresDataCount = 10;

        LeaderboardEntryModel[] highscoresData = new LeaderboardEntryModel[0];
        int score = 0;

        public int MaxHighscoresDataCount => maxHighscoresDataCount;

        [Header("Events")]
        [SerializeField] TSG_GameEvent onHighscoreDataUpdate = null;

        private void Awake()
        {
            highscoresData = new LeaderboardEntryModel[maxHighscoresDataCount];
        }

        private void Start()
        {
            for (int i = 0; i < highscoresData.Length; i++)
            {
                updateHighscoreData(i, highscoresData[i]);
            }
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

        public LeaderboardEntryModel GetHighscore(int _highscoreId)
        {
            if (_highscoreId < 0 || _highscoreId >= highscoresData.Length)
            {
                return null;
            }

            return highscoresData[_highscoreId];
        }

        private bool addHighscore(LeaderboardEntryModel _highscoreData)
        {
            for (int i = 0; i < highscoresData.Length; i++)
            {
                if (highscoresData[i] == null)
                {
                    highscoresData[i] = _highscoreData;
                    updateHighscoreData(i, _highscoreData);
                    return true;
                }
                else if (highscoresData[i].Score < _highscoreData.Score)
                {
                    lowerHighscoresFrom(i);
                    highscoresData[i] = _highscoreData;
                    updateHighscoreData(i, _highscoreData);
                    return true;
                }
            }

            return false;
        }

        private void lowerHighscoresFrom(int _highscoreDataId)
        {
            if (_highscoreDataId < 0 || _highscoreDataId >= highscoresData.Length)
            {
                return;
            }

            for (int i = highscoresData.Length - 1; i > _highscoreDataId; i--)
            {
                highscoresData[i] = highscoresData[i - 1];
                updateHighscoreData(i, highscoresData[i - 1]);
            }
        }

        private void updateHighscoreData(int _highscoreDataId, LeaderboardEntryModel _highscoreData)
        {
            onHighscoreDataUpdate?.Invoke(new TSG_GameEventData()
            {
                IntValues = new int[] { _highscoreDataId },
                ObjectValues = new object[] { _highscoreData }
            });
        }
    }
}