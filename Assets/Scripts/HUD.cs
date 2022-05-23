using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] public static int score;
    [SerializeField] public static int highScore;
    public Text scoreText;
    public Text moneyText;

    private float timeToIncreaseScore = 0.1f;
    private float scoreTime;

    public static int money;

    void Start()
    {
        LoadDataSaved();
    }

    public void LoadDataSaved()
    {
        highScore = PlayerPrefs.GetInt("Highscore");
        money = PlayerPrefs.GetInt("Money");
    }

    void Update()
    {
        Score();
    }

    void Score()
    {
        if(Fork.started)
        {
            scoreTime -= Time.deltaTime;

            if(scoreTime < 0)
            {
                scoreTime = timeToIncreaseScore;
                score += 1;
                scoreText.text = score.ToString();
            }
        }
    }

    public void Money()
    {
        money += 1;
        moneyText.text = money.ToString();
        PlayerPrefs.SetInt("Money", money);
    }
}
