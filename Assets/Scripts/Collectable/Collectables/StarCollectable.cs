using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollectable : Collectable
{
    public override void Collect(int amount)
    {
        GameManager.instance.starAmountRecorder.RecordStar(amount);
    }
}