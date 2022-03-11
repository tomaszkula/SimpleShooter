namespace TSG.Game
{
    using TSG.Model;
    using UnityEngine;

    public class TSG_Leaderboard : MonoBehaviour
    {
        int score = 0;

        [Header("Events")]
        [SerializeField] TSG_GameEvent onLeaderboardUpdateEvent = null;

        #region Callbacks
        public void OnScoreUpdate(TSG_GameEventData _gameEventData)
        {
            score = _gameEventData.IntValues[0];
        }

        public void OnPlayerDeath()
        {
            TSG_HighScoreData _highScoreData = TSG_SaveSystem.SaveData.GetHighScore();
            if(_highScoreData == null)
            {
                _highScoreData = new TSG_HighScoreData();
                _highScoreData.Score = -1;
            }

            if(_highScoreData.Score < score)
            {
                _highScoreData.Name = TSG_Nickname.Nickname;
                _highScoreData.Score = score;
            }
            TSG_SaveSystem.SaveData.SetHighScore(_highScoreData);
            TSG_SaveSystem.Save();

            LeaderboardModel _leaderboardModel = new LeaderboardModel();
            LeaderboardEntryModel _leaderboardEntryModel = new LeaderboardEntryModel(_highScoreData.Name, _highScoreData.Score);
            _leaderboardModel.AddItem(_leaderboardEntryModel);
            _leaderboardModel.Sort();

            onLeaderboardUpdateEvent?.Invoke(new TSG_GameEventData()
            {
                IntValues = new int[] { _leaderboardModel.IndexOf(_leaderboardEntryModel) },
                ObjectValues = new object[] { _leaderboardModel }
            });
        }
        #endregion
    }
}