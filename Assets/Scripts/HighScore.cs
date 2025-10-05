using System;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    private static Text _UI_TEXT;
    private static int _SCORE = 1000;

    private Text txtCom;
    private const string highScore = "HighScore";
    void Awake()
    {
        _UI_TEXT = GetComponent<Text>();

        if (PlayerPrefs.HasKey(highScore))
        {
            SCORE = PlayerPrefs.GetInt(highScore);
        }
        PlayerPrefs.SetInt(highScore,SCORE);
    }

    public static int SCORE
    {
        get{return _SCORE;}
        private set
        {
            _SCORE = value;
            PlayerPrefs.SetInt(highScore, _SCORE);
            if (_UI_TEXT != null)
            {
                _UI_TEXT.text = "High Score: " + value.ToString("#,0");
            }
        }
    }

    public static void TRY_SET_HIGH_SCORE(int scoreToTry)
    {
        if(scoreToTry <= SCORE) return;
        SCORE = scoreToTry;
    }

    [Tooltip("Check this box to reset the HighScore in PlayerPrefs")]
    public bool resetHighScoreNow = false;

    private void OnDrawGizmos()
    {
        if (resetHighScoreNow)
        {
            resetHighScoreNow = false;
            PlayerPrefs.SetInt(highScore, 1000);
            Debug.LogWarning("PlayerPrefs HighScore reset to 1,000.");
        }
    }
}
