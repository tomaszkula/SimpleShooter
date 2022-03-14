using System;

[Serializable]
public class SS_SaveData
{
    public SS_HighScoreData HighScore = null;

    public SS_HighScoreData GetHighScore()
    {
        return HighScore;
    }

    public void SetHighScore(SS_HighScoreData _highScore)
    {
        HighScore = _highScore;
    }
}
