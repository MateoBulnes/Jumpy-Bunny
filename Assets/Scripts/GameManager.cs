using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState{
    Menu, InGame, GameOver
}

public class GameManager : MonoBehaviour
{
    public GameState currentGameState = GameState.Menu;
    private static GameManager sharedInstance;
    public Canvas mainMenu;
    public Canvas gameMenu;
    public Canvas gameOverMenu;
    private int collectedCoins = 0;
    private void Awake()
    {
        sharedInstance = this;
    }
    public static GameManager GetInstance()
    {
        return sharedInstance;
    }
    // Starts our game
    public void StartGame()
    {
        LevelGenerator.sharedInstance.CreateInitialBlocks();
        PlayerController.GetInstance().StartGame();
        ChangeGameState(GameState.InGame);
        ViewInGame.GetInstance().ShowHighestScore();
    }
    private void Start()
    {
        currentGameState = GameState.Menu;
        mainMenu.enabled = true;
        gameMenu.enabled = false;
        gameOverMenu.enabled = false;
    }
    private void Update()
    {
        if (Input.GetButtonDown("s") && currentGameState != GameState.InGame)
        {
            ChangeGameState(GameState.InGame);
            StartGame();
        }
    }
    // Called when player dies
    public void GameOver()
    {
        LevelGenerator.sharedInstance.RemoveAllBlocks();
        ChangeGameState(GameState.GameOver);
        GameOverView.GetInstance().UpdateGui();
    }
    //Called when the player quits the game and goes back to the main menu
    public void BackToMainMenu()
    {
        ChangeGameState(GameState.Menu);
    }
    private void ChangeGameState(GameState newGameState)
    {
        switch (newGameState)
        {
            case GameState.Menu:
                mainMenu.enabled = true;
                gameMenu.enabled = false;
                gameOverMenu.enabled = false;
                break;
            case GameState.InGame:
                mainMenu.enabled = false;
                gameMenu.enabled = true;
                gameOverMenu.enabled = false;
                break;
            case GameState.GameOver:
                mainMenu.enabled = false;
                gameMenu.enabled = false;
                gameOverMenu.enabled = true;
                break;
            default:
                newGameState = GameState.Menu;
                break;
        }
        currentGameState = newGameState;
    }
    public void CollectCoins()
    {
        collectedCoins++;
        ViewInGame.GetInstance().UpdateCoins();
    }
    public int GetCollectedCoins()
    {
        return collectedCoins;
    }
}
