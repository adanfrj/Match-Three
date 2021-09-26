using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static int highScore;
    public int tileRatio;
    private int currentScore;
    public int comboRatio;
    public int HighScore { get { return highScore; } }
    public int CurrentScore { get { return currentScore; } }

    #region Singleton

    private static ScoreManager _instance = null;

    public static ScoreManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ScoreManager>();

                if (_instance == null)
                {
                    Debug.LogError("Fatal Error: ScoreManager not Found");
                }
            }

            return _instance;
        }
    }

    #endregion

    private void Start()
    {
        ResetCurrentScore();
    }

    public void SetHighScore()
    {
        highScore = currentScore;
    }

    public void ResetCurrentScore()
    {
        currentScore = 0; 
    }

    public void IncrementCurrentScore(int tileCount, int comboCount)
    {
        currentScore += (tileCount * tileRatio) * (comboCount * comboRatio);
        SoundManager.Instance.PlayScore(comboCount > 1);
    }

}
