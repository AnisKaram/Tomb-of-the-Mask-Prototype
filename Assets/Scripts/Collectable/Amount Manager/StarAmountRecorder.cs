public class StarAmountRecorder : CollectableRecorder
{
    public int m_starAmount;

    public override void RecordStar(int amount)
    {
        m_starAmount += amount;
    }
}