using UnityEngine;

public class StarCollisionDetection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Star"))
        {
            if (collision.TryGetComponent(out StarCollectable starCollectable))
            {
                starCollectable.Collect(amount: 1);
            }
        }
    }
}