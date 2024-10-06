using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollectableRecorder : MonoBehaviour
{
    public virtual void RecordCoin(int amount) { }
    public virtual void SetCoins(int amount) { }

    public virtual void RecordStar(int amount) { }
    public virtual void SetStars(int amount) { }
}