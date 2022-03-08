namespace TSG.Game
{
    using TMPro;
    using UnityEngine;

    public class TopBar : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] TextMeshProUGUI healthTMP = null;
        [SerializeField] TextMeshProUGUI scoreTMP = null;

        public void OnScoreChange(TSG_GameEventData _gameEventData)
        {
            int _score = _gameEventData.IntValues[0];
            updateScoreUI(_score);
        }

        public void OnHealthChange(TSG_GameEventData _gameEventData)
        {
            float _health = _gameEventData.FloatValues[0];
            updateHealthUI(_health);
        }

        private void updateHealthUI(float _health)
        {
            healthTMP.text = $"{_health}";
        }

        private void updateScoreUI(int _score)
        {
            scoreTMP.text = $"{_score}";
        }
    }
}
