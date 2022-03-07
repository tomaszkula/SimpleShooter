namespace TSG.Game
{
    using TMPro;
    using TSG.Model;
    using UnityEngine;

    public class TSG_LeaderboardEntryUI : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] TextMeshProUGUI positionTMP = null;
        [SerializeField] TextMeshProUGUI nameTMP = null;
        [SerializeField] TextMeshProUGUI scoreTMP = null;

        [Header("Data")]
        int highscoreId = 0;
        LeaderboardEntryModel highscore = null;

        public void Setup(int _highscoreId, LeaderboardEntryModel _highscore)
        {
            highscoreId = _highscoreId;
            highscore = _highscore;

            refreshUI();
        }

        private void refreshUI()
        {
            if (highscore != null)
            {
                positionTMP.text = $"{highscoreId + 1}";
                nameTMP.text = highscore.Name;
                scoreTMP.text = $"{highscore.Score}";

                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}