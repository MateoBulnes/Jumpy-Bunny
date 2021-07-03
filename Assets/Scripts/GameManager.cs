using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState{
    Menu, InGame, GameOver
}

public class GameManager : MonoBehaviour
{
    public GameState currentGameState = GameState.Menu;
    private static GameManager sharedInstance;
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
        ChangeGameState(GameState.InGame);
    }
    private void Start()
    {
        //StartGame();
        currentGameState = GameState.Menu;
    }
    private void Update()
    {
        if (Input.GetButtonDown("s"))
        {
            ChangeGameState(GameState.InGame);
        }
    }
    // Called when player dies
    public void GameOver()
    {
        ChangeGameState(GameState.GameOver);
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
                //load main menu scene
                break;
            case GameState.InGame:
                //Unity scene must show the real game
                break;
            case GameState.GameOver:
                // show game over scene
                break;
            default:
                newGameState = GameState.Menu;
                break;
        }
        currentGameState = newGameState;
    }
}
