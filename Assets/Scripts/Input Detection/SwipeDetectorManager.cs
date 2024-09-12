using UnityEngine;
using UnityEngine.Events;


public enum SwipeDirections
{
    Left,
    Right,
    Up,
    Down,
    Null
}


public class SwipeDetectorManager : MonoBehaviour
{
    #region Fields
    private Inputs m_inputs;

    public int m_isTouchStarted;
    private SwipeDirections m_swipeDirection;
    private Vector2 m_touchStartPosition;

    private const float m_swipeThreshold = 0.9f;
    #endregion


    #region Events
    public static event UnityAction<SwipeDirections> SwipeDetected;
    #endregion


    #region Unity Methods
    private void Awake()
    {
        m_inputs = new Inputs();

        m_inputs.Enable();

        m_swipeDirection = SwipeDirections.Null;

        m_inputs.Gameplay.Touch.started += _ => OnTouchStarted();
        m_inputs.Gameplay.Touch.canceled += _ => OnTouchCanceled();
    }
    private void Update()
    {
        if (BinaryUtil.BitmaskAND(m_isTouchStarted, 1))
        {
            Vector2 touchPosition = m_inputs.Gameplay.Touch.ReadValue<Vector2>();
            Vector2 direction2D = (touchPosition - m_touchStartPosition).normalized;

            // Dot product
            if (/*m_swipeDirection != SwipeDirections.Right && */Vector2.Dot(Vector2.right, direction2D) > m_swipeThreshold) // Swipe right.
            {
                Debug.Log($"RIGHT");
                m_swipeDirection = SwipeDirections.Right;
                InvokeSwipeEvent(m_swipeDirection);
                //return;
            }
            else if (/*m_swipeDirection != SwipeDirections.Left && */Vector2.Dot(Vector2.left, direction2D) > m_swipeThreshold) // Swipe left.
            {
                Debug.Log($"LEFT");
                m_swipeDirection = SwipeDirections.Left;
                InvokeSwipeEvent(m_swipeDirection);
                //return;
            }
            else if (/*m_swipeDirection != SwipeDirections.Up && */Vector2.Dot(Vector2.up, direction2D) > m_swipeThreshold) // Swipe up.
            {
                Debug.Log($"UP");
                m_swipeDirection = SwipeDirections.Up;
                InvokeSwipeEvent(m_swipeDirection);
                //return;
            }
            else if (/*m_swipeDirection != SwipeDirections.Down && */ Vector2.Dot(Vector2.down, direction2D) > m_swipeThreshold) // Swipe down.
            {
                Debug.Log($"DOWN");
                m_swipeDirection = SwipeDirections.Down;
                InvokeSwipeEvent(m_swipeDirection);
            }
        }
    }
    private void OnDestroy()
    { 
        m_inputs.Gameplay.Touch.started -= _ => OnTouchStarted();
        m_inputs.Gameplay.Touch.canceled -= _ => OnTouchCanceled();

        m_inputs.Disable();
    }
    #endregion


    #region Private Methods
    private void OnTouchStarted()
    {
        m_isTouchStarted = BinaryUtil.SetFlag(m_isTouchStarted, 1);
        m_touchStartPosition = m_inputs.Gameplay.Touch.ReadValue<Vector2>();
    }
    private void OnTouchCanceled()
    {
        m_isTouchStarted = BinaryUtil.RemoveFlag(m_isTouchStarted, 1);
    }

    private void InvokeSwipeEvent(SwipeDirections swipe)
    {
        SwipeDetected?.Invoke(swipe);
    }
    #endregion
}