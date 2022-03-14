using UnityEngine;

public class SS_Leaderboard : MonoBehaviour
{
    int score = 0;

    [Header("Events")]
    [SerializeField] SS_GameEvent onLeaderboardUpdateEvent = null;

    #region Callbacks
    public void OnScoreUpdate(SS_GameEventData _gameEventData)
    {
        score = _gameEventData.IntValues[0];
    }

    public void OnPlayerDeath()
    {
        SS_HighScoreData _highScoreData = SS_SaveSystem.SaveData.GetHighScore();
        if(_highScoreData == null)
        {
            _highScoreData = new SS_HighScoreData();
            _highScoreData.Score = -1;
        }

        if(_highScoreData.Score < score)
        {
            _highScoreData.Name = SS_Nickname.Nickname;
            _highScoreData.Score = score;
        }
        SS_SaveSystem.SaveData.SetHighScore(_highScoreData);
        SS_SaveSystem.Save();

        SS_LeaderboardModel _leaderboardModel = new SS_LeaderboardModel();
        SS_LeaderboardEntryModel _leaderboardEntryModel = new SS_LeaderboardEntryModel(_highScoreData.Name, _highScoreData.Score);
        _leaderboardModel.AddItem(_leaderboardEntryModel);
        _leaderboardModel.Sort();

        onLeaderboardUpdateEvent?.Invoke(new SS_GameEventData()
        {
            IntValues = new int[] { _leaderboardModel.IndexOf(_leaderboardEntryModel) },
            ObjectValues = new object[] { _leaderboardModel }
        });
    }
    #endregion
}