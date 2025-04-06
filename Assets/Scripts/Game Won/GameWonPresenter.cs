using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWonPresenter : MonoBehaviour
{
    #region Fields
    private GameWonView m_gameWonView;

    [SerializeField] private GameObject m_gameWonCanvas;
    #endregion


    #region Unity Methods
    private void Awake()
    {
        m_gameWonView = GetComponent<GameWonView>();
    }
    #endregion


    #region Public Methods
    public void NextLevel()
    {
        // TODO add logic...
        Debug.Log($"Next level");
    }

    public void QuitLevel()
    {
        // TODO add logic...
        Debug.Log($"Quit level");
    }

    public void ShowGameWon()
    {
        // TODO add logic...
        Debug.Log($"Show game won");
        m_gameWonView.InitializeButtons();
        m_gameWonCanvas.SetActive(true);
    }
    #endregion
}