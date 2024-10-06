public class StarAmountRecorder : CollectableRecorder
{
    private int m_starAmount;

    public override void RecordStar(int amount)
    {
        m_starAmount += amount;
    }

    public override void SetStars(int amount)
    {
        m_starAmount = amount;
    }
}