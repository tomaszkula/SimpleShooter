using UnityEngine;

public class SS_Score : MonoBehaviour
{
    [Header("Variables")]
    bool isPlayerDead = false;
    int score = 0;

    [Header("Events")]
    [SerializeField] SS_GameEvent onScoreChange = null;

    private void Start()
    {
        updateScore();
    }

    public void OnPlayerDeath()
    {
        isPlayerDead = true;
    }

    public void OnEnemyDeath()
    {
        increaseScore();
    }

    private void increaseScore()
    {
        if(isPlayerDead)
        {
            return;
        }

        score++;
        updateScore();
    }

    private void updateScore()
    {
        onScoreChange?.Invoke(new SS_GameEventData()
        {
            IntValues = new int[] { score }
        });
    }
}
