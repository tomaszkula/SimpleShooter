namespace TSG.Game
{
    using System;
    using TSG.Model;
    using UnityEngine;

    public class TSG_Leaderboard : MonoBehaviour
    {
        public event Action<int, LeaderboardEntryModel> onHighscoreUpdate = null;

        [Header("Variables")]
        [SerializeField] int maxHighscoresCount = 10;

        LeaderboardEntryModel[] highscores = new LeaderboardEntryModel[0];

        public int MaxHighscoresCount => maxHighscoresCount;

        //[Header("Events")]

        private void Awake()
        {
            highscores = new LeaderboardEntryModel[maxHighscoresCount];
        }

        public void Setup(PlayerModel _model)
        {
            _model.die += OnPlayerDeath;
        }

        public void OnPlayerDeath(PlayerModel _playerModel)
        {
            LeaderboardEntryModel _leaderboardEntryModel = new LeaderboardEntryModel("Test", _playerModel.Score);
            addHighscore(_leaderboardEntryModel);
        }

        public LeaderboardEntryModel GetHighscore(int _highscoreId)
        {
            if (_highscoreId < 0 || _highscoreId >= highscores.Length)
            {
                return null;
            }

            return highscores[_highscoreId];
        }

        private bool addHighscore(LeaderboardEntryModel _leaderboardEntryModel)
        {
            for (int i = 0; i < highscores.Length; i++)
            {
                if (highscores[i] == null)
                {
                    updateHighscorePosition(i, _leaderboardEntryModel);
                    return true;
                }
                else if (highscores[i].Score < _leaderboardEntryModel.Score)
                {
                    lowerHighscoresFrom(i);
                    updateHighscorePosition(i, _leaderboardEntryModel);
                    return true;
                }
            }

            return false;
        }

        private void lowerHighscoresFrom(int _highscoreId)
        {
            if (_highscoreId < 0 || _highscoreId >= highscores.Length)
            {
                return;
            }

            for (int i = highscores.Length - 1; i > _highscoreId; i--)
            {
                updateHighscorePosition(i, highscores[i - 1]);
            }
        }

        private void updateHighscorePosition(int _highscoreId, LeaderboardEntryModel _highscore)
        {
            highscores[_highscoreId] = _highscore;
            onHighscoreUpdate?.Invoke(_highscoreId, _highscore);
        }
    }
}