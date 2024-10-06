using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager m_instance;

    private StarAmountRecorder m_starAmountRecorder;
    private CoinAmountRecorder m_coinAmountRecorder;


    public static GameManager instance => m_instance;

    public StarAmountRecorder starAmountController => m_starAmountRecorder;
    public CoinAmountRecorder coinAmountController => m_coinAmountRecorder;


    private void Awake()
    {
        if (m_instance == null) { m_instance = this; }

        m_starAmountRecorder = GetComponent<StarAmountRecorder>();
        m_coinAmountRecorder = GetComponent<CoinAmountRecorder>();
    }
}