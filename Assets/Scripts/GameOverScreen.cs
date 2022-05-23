using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;

    void Start()
    {
        scoreText.text = HUD.score.ToString();
        CheckHighscore();
    }

    void CheckHighscore()
    {
        if(HUD.score > HUD.highScore)
        {
            HUD.highScore = HUD.score;
        }
        PlayerPrefs.SetInt("Highscore", HUD.highScore);
        highscoreText.text = HUD.highScore.ToString();
    }
}
