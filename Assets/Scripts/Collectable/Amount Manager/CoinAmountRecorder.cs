public class CoinAmountRecorder : CollectableRecorder
{
    private int m_coinAmount;

    public override void RecordCoin(int amount)
    {
        m_coinAmount += amount;
    }

    public override void SetCoins(int amount)
    {
        m_coinAmount = amount;
    }
}