using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectable : Collectable
{
    public override void Collect(int amount)
    {
        GameManager.instance.coinAmountController.RecordCoin(amount);
    }
}