using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWonModel : MonoBehaviour
{
    #region Fields
    private GameWonPresenter m_gameWonPresenter;
    #endregion


    #region Unity Methods
    private void Awake()
    {
        m_gameWonPresenter = GetComponent<GameWonPresenter>();

        GameManager.GameWon += OnGameWon; 
    }
    private void OnDestroy()
    {
        GameManager.GameWon -= OnGameWon;
    }
    #endregion


    #region Private Methods
    private void OnGameWon()
    {
        m_gameWonPresenter.ShowGameWon();
    }
    #endregion
}