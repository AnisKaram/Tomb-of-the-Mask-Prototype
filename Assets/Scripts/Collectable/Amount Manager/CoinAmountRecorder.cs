public class CoinAmountRecorder : CollectableRecorder
{
    private int m_coinAmount;
    public override event AmountUpdated CoinAmountUpdated;

    public int coinAmount => m_coinAmount;

    public override void RecordCoin(int amount)
    {
        m_coinAmount += amount;
        CoinAmountUpdated?.Invoke(m_coinAmount);
    }

    public override void SetCoins(int amount)
    {
        m_coinAmount = amount;
        CoinAmountUpdated?.Invoke(m_coinAmount);
    }
}