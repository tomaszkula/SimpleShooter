using UnityEngine;

public class TSG_Score : MonoBehaviour
{
    [Header("Variables")]
    int score = 0;

    [Header("Events")]
    [SerializeField] TSG_GameEvent onScoreChange = null;

    private void Start()
    {
        updateScore();
    }

    public void OnEnemyDeath()
    {
        increaseScore();
    }

    private void increaseScore()
    {
        score++;
        updateScore();
    }

    private void updateScore()
    {
        onScoreChange?.Invoke(new TSG_GameEventData()
        {
            IntValues = new int[] { score }
        });
    }
}
