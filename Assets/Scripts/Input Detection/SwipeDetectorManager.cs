using UnityEngine;
using UnityEngine.Events;

public enum SwipeDirections
{
    left,
    right,
    up,
    down,
    Null
}


public class SwipeDetectorManager : MonoBehaviour
{
    #region Fields
    private Inputs m_inputs;

    private int m_isTouchStarted;
    private SwipeDirections m_swipeDirection;
    private float m_deltaThreshold = 2f;
    #endregion


    #region Events
    public static event UnityAction<SwipeDirections, Vector2> SwipeDetected;
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
            Vector2 swipeDelta = m_inputs.Gameplay.Swipe.ReadValue<Vector2>();

            if (swipeDelta.x != 0f && swipeDelta.y != 0f) { return; } // filter the delta of the finger

            if (swipeDelta.x < -m_deltaThreshold)
            {
                m_swipeDirection = SwipeDirections.left;
                InvokeSwipeEvent(m_swipeDirection, Vector2.left);
            }
            if (swipeDelta.x > m_deltaThreshold)
            {
                m_swipeDirection = SwipeDirections.right;
                InvokeSwipeEvent(m_swipeDirection, Vector2.right);
            }
            if (swipeDelta.y < -m_deltaThreshold)
            {
                m_swipeDirection = SwipeDirections.down;
                InvokeSwipeEvent(m_swipeDirection, Vector2.down);
            }
            if (swipeDelta.y > m_deltaThreshold)
            {
                m_swipeDirection = SwipeDirections.up;
                InvokeSwipeEvent(m_swipeDirection, Vector2.up);
            }
            return;
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
    }
    private void OnTouchCanceled()
    {
        m_isTouchStarted = BinaryUtil.RemoveFlag(m_isTouchStarted, 1);
    }

    private void InvokeSwipeEvent(SwipeDirections swipe, Vector2 direction)
    {
        SwipeDetected?.Invoke(swipe, direction);
    }
    #endregion
}