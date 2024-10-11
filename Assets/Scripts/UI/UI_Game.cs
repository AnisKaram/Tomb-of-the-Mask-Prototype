using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Game : MonoBehaviour
{
    #region Fields
    [SerializeField] private TextMeshProUGUI m_coinAmountText;
    #endregion


    #region Unity Methods
    private void Start()
    {
        GameManager.instance.coinAmountRecorder.CoinAmountUpdated += OnCoinAmountUpdated;
    }
    private void OnDestroy()
    {
        GameManager.instance.coinAmountRecorder.CoinAmountUpdated -= OnCoinAmountUpdated;
    }
    #endregion


    #region Private Methods
    private void OnCoinAmountUpdated(int amount)
    {
        m_coinAmountText.text = $"{amount}";
    }
    #endregion
}