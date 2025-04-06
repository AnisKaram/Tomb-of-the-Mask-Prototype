using UnityEngine;

public class GameWonCollisionDetection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GameWon"))
        {
            GameManager.instance.ChangeGameState(GameState.GameWon);
        }
    }
}