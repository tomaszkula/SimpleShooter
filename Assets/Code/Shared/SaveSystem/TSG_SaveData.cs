using System;

[Serializable]
public class TSG_SaveData
{
    public TSG_HighScoreData HighScore = null;

    public TSG_HighScoreData GetHighScore()
    {
        return HighScore;
    }

    public void SetHighScore(TSG_HighScoreData _highScore)
    {
        HighScore = _highScore;
    }
}
