using UnityEngine;
using System;

public enum GameState {MainMenu, Playing, Paused, GameOver}
public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set;}
    
    public GameState currentState = GameState.MainMenu;
    public event Action<GameState> OnStateChanged;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    void Start()
    {
        SetState(GameState.MainMenu);
    }

    public void StartGame()
    {
        SetState(GameState.Playing);
    }
    public void GameOver()
    {
        SetState(GameState.GameOver);
    }

    private void SetState(GameState newState)
    {
        currentState = newState;
        OnStateChanged?.Invoke(newState);
    }
}
