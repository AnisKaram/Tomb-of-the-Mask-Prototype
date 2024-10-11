using UnityEngine;

public class CoinCollisionDetection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            if (collision.TryGetComponent(out CoinCollectable coinCollectable))
            {
                coinCollectable.Collect(amount: 1);
                coinCollectable.DestroyObject();
            }
        }
    }
}