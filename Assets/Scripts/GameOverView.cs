using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverView : MonoBehaviour
{
    public Text coinsLabel;
    public Text scoreText;
    private static GameOverView sharedInstance;

    public static GameOverView GetInstance()
    {
        return sharedInstance;
    }
    private void Awake()
    {
        sharedInstance = this;
    }
 
    public void UpdateGui()
    {
        if(GameManager.GetInstance().currentGameState == GameState.GameOver)
        {
            coinsLabel.text = GameManager.GetInstance().GetCollectedCoins().ToString();
            scoreText.text = PlayerController.GetInstance().GetDistance().ToString();
        }
    }
}
