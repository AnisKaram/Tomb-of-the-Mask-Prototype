using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameWonView : MonoBehaviour
{
    #region Fields
    private GameWonPresenter m_gameWonPresenter;

    [SerializeField] private Button m_nextButton;
    [SerializeField] private Button m_menuButton;
    #endregion


    #region Unity Methods
    private void Awake()
    {
        m_gameWonPresenter = GetComponent<GameWonPresenter>();
    }
    #endregion


    #region Public Methods
    public void InitializeButtons()
    {
        m_nextButton.onClick.AddListener(new UnityAction(OnNextButtonClicked));
        m_menuButton.onClick.AddListener(new UnityAction(OnMenuButtonClicked));
    }
    #endregion


    #region Private Methods
    private void OnNextButtonClicked()
    {
        m_gameWonPresenter.NextLevel();
    }
    private void OnMenuButtonClicked()
    {
        m_gameWonPresenter.QuitLevel();
    }
    #endregion
}