using UnityEngine;
using System;

public enum GameState
{
    GameWon,
    GameLost,
    GamePaused,
    GameStarted
}

public class GameManager : MonoBehaviour
{
    private static GameManager m_instance;

    private StarAmountRecorder m_starAmountRecorder;
    private CoinAmountRecorder m_coinAmountRecorder;
    private SwipeDetectorManager m_swipeDetectorManager;

    [SerializeField] private GameState m_gameState;


    public static GameManager instance => m_instance;

    public StarAmountRecorder starAmountRecorder => m_starAmountRecorder;
    public CoinAmountRecorder coinAmountRecorder => m_coinAmountRecorder;


    public delegate void GameStateAction();
    public static event GameStateAction GameWon;
    // .. add more events soon

    private void Awake()
    {
        if (m_instance == null) { m_instance = this; }

        m_starAmountRecorder = GetComponent<StarAmountRecorder>();
        m_coinAmountRecorder = GetComponent<CoinAmountRecorder>();
        m_swipeDetectorManager = GetComponentInChildren<SwipeDetectorManager>();
    }

    private void Start()
    {
        ChangeGameState(GameState.GameStarted);
        m_coinAmountRecorder.SetCoins(DataSaver.instance.GetCoins());
    }

    public void ChangeGameState(GameState gameState)
    {
        m_gameState = gameState;
        switch (gameState)
        {
            case GameState.GameWon:
                m_swipeDetectorManager.DisableTouch();
                DataSaver.instance.SaveData(m_coinAmountRecorder.coinAmount, -1, m_starAmountRecorder.starAmount, 0, m_starAmountRecorder.starAmount);
                GameWon?.Invoke();
                break;
            case GameState.GameLost:
                // add soon...
                break;
            case GameState.GamePaused:
                // add soon...
                break;
            case GameState.GameStarted:
                // add soon...
                break;
        }
    }
}