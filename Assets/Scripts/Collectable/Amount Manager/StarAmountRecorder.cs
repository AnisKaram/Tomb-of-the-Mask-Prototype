public class StarAmountRecorder : CollectableRecorder
{
    private int m_starAmount;
    public override event AmountUpdated StarAmountUpdated;

    public int starAmount => m_starAmount;

    public override void RecordStar(int amount)
    {
        m_starAmount += amount;
        StarAmountUpdated?.Invoke(amount);
    }
}