namespace TSG.Game
{
    using TSG.Model;
    using UnityEngine;

    public class TSG_LeaderboardUI : MonoBehaviour
    {
        [Header("")]
        [SerializeField] TSG_LeaderboardEntryUI leaderEntryUIPrefab = null;

        TSG_LeaderboardEntryUI[] leaderboardEntryUIs = new TSG_LeaderboardEntryUI[0];

        [Header("References")]
        [SerializeField] RectTransform container = null;

        TSG_Leaderboard leaderboard = null;

        public void Setup(TSG_Leaderboard _leaderboard)
        {
            leaderboard = _leaderboard;

            leaderboard.onHighscoreUpdate += UpdateHightscore;

            leaderboardEntryUIs = new TSG_LeaderboardEntryUI[leaderboard.MaxHighscoresCount];
            for (int i = 0; i < leaderboardEntryUIs.Length; i++)
            {
                UpdateHightscore(i, leaderboard.GetHighscore(i));
            }
        }

        public void UpdateHightscore(int _highscoreId, LeaderboardEntryModel _highscore)
        {
            if(_highscoreId < 0 && _highscoreId >= leaderboardEntryUIs.Length)
            {
                return;
            }

            if (leaderboardEntryUIs[_highscoreId] == null)
            {
                leaderboardEntryUIs[_highscoreId] = Instantiate(leaderEntryUIPrefab, container);
            }

            leaderboardEntryUIs[_highscoreId].Setup(_highscoreId, _highscore);
        }
    }
}