using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollectableRecorder : MonoBehaviour
{
    public delegate void AmountUpdated(int amount);
    public virtual event AmountUpdated CoinAmountUpdated;
    public virtual event AmountUpdated StarAmountUpdated;

    public virtual void RecordCoin(int amount) { }
    public virtual void SetCoins(int amount) { }

    public virtual void RecordStar(int amount) { }
}