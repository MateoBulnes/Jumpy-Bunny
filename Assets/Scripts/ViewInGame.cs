using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewInGame : MonoBehaviour
{
    public Text coinsLabel;
    public Text scoreText;
    public Text highScoreText;
    private static ViewInGame sharedInstance;

    private void Awake()
    {
        sharedInstance = this;
    }
    public static ViewInGame GetInstance()
    {
        return sharedInstance;
    }
    public void ShowHighestScore()
    {
        highScoreText.text = PlayerController.GetInstance().GetMaxScore().ToString();
    }
    void Update()
    {
       
        if (GameManager.GetInstance().currentGameState == GameState.InGame)
        {
            scoreText.text = PlayerController.GetInstance().GetDistance().ToString();
        }
    }
    public void UpdateCoins()
    {
        coinsLabel.text = GameManager.GetInstance().GetCollectedCoins().ToString();
    }
}
