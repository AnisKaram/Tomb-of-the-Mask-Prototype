using UnityEngine;

public class InputDetectorManager : MonoBehaviour
{
    private Inputs m_inputs;

    private bool isTouchStarted;
    private Vector2 m_touchStartPosition;
    private const float m_swipeThreshold = 0.9f;

    private void Awake()
    {
        m_inputs = new Inputs();

        m_inputs.Enable();

        m_inputs.Gameplay.Touch.started += _ => OnTouchStarted();
        m_inputs.Gameplay.Touch.canceled += _ => OnTouchCanceled();
    }
    private void Update()
    {
        if (isTouchStarted)
        {
            Vector2 touchPosition = m_inputs.Gameplay.Touch.ReadValue<Vector2>();
            Vector2 direction2D = (touchPosition - m_touchStartPosition).normalized;

            // Dot product
            if (Vector2.Dot(Vector2.right, direction2D) > m_swipeThreshold) // Swipe right.
            {
                Debug.Log($"RIGHT");
                return;
            }
            if (Vector2.Dot(Vector2.left, direction2D) > m_swipeThreshold) // Swipe left.
            {
                Debug.Log($"LEFT");
                return;
            }
            if (Vector2.Dot(Vector2.up, direction2D) > m_swipeThreshold) // Swipe up.
            {
                Debug.Log($"UP");
                return;
            }
            if (Vector2.Dot(Vector2.down, direction2D) > m_swipeThreshold) // Swipe down.
            {
                Debug.Log($"DOWN");
            }
        }
    }
    private void OnDestroy()
    { 
        m_inputs.Gameplay.Touch.started -= _ => OnTouchStarted();
        m_inputs.Gameplay.Touch.canceled -= _ => OnTouchCanceled();

        m_inputs.Disable();
    }

    private void OnTouchStarted()
    {
        isTouchStarted = true;
        m_touchStartPosition = m_inputs.Gameplay.Touch.ReadValue<Vector2>();
    }
    private void OnTouchCanceled()
    {
        isTouchStarted = false;
    }
}