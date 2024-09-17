using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D m_rigidbody2D;
    private BoxCollider2D m_boxCollider2D;

    public bool isDashing;

    public Vector3 m_dashDirection;
    public Vector2 m_castDirection;
    public SwipeDirections m_swipeDirection;
    private float m_thrust = 0.2f;

    private int m_groundMask;

    private void Awake()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_boxCollider2D = GetComponent<BoxCollider2D>();

        m_swipeDirection = SwipeDirections.Null;

        m_groundMask = (1 << 10);

        SwipeDetectorManager.SwipeDetected += OnSwipeDetected;
    }
    private void OnDestroy()
    {
        SwipeDetectorManager.SwipeDetected -= OnSwipeDetected;
    }
    // TODO Delete after done testing
    private void Update()
    {
        if (isDashing) { return; }

        if (Input.GetKeyDown(KeyCode.A))
        {
            OnSwipeDetected(SwipeDirections.left, Vector2.left);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            OnSwipeDetected(SwipeDirections.right, Vector2.right);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            OnSwipeDetected(SwipeDirections.up, Vector2.up);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            OnSwipeDetected(SwipeDirections.down, Vector2.down);
        }
    }

    private void OnSwipeDetected(SwipeDirections swipeDirection, Vector2 direction)
    {
        if (swipeDirection == m_swipeDirection) { return; } // avoid same swipe direction
        
        m_castDirection = direction;
        m_swipeDirection = swipeDirection;

        // Dash direction
        if (swipeDirection == SwipeDirections.left || swipeDirection == SwipeDirections.right)
        {
            m_dashDirection = transform.right;
        }
        else if (swipeDirection == SwipeDirections.up || swipeDirection == SwipeDirections.down)
        {
            m_dashDirection = transform.up;
        }

        // Thrust
        if (swipeDirection == SwipeDirections.up || swipeDirection == SwipeDirections.right)
        {
            m_thrust = 0.2f;
        }
        else if (swipeDirection == SwipeDirections.down || swipeDirection == SwipeDirections.left)
        {
            m_thrust = -0.2f;
        }

        isDashing = true;
    }

    // -----
    // TODO Move the code to the states and StateMachine
    // -----

    private void FixedUpdate()
    {
        if (isDashing)
        {
            DashPlayer();
            if (IsPlayerIdle()) { isDashing = false; }
        }
    }

    private void DashPlayer()
    {
        m_rigidbody2D.AddForce(m_dashDirection * m_thrust, ForceMode2D.Force);
    }

    private bool IsPlayerIdle()
    {
        bool idle = Physics2D.BoxCast(
            origin: m_boxCollider2D.bounds.center,
            size: m_boxCollider2D.bounds.size,
            angle: 0f,
            direction: m_castDirection,
            distance: m_boxCollider2D.bounds.extents.x,
            layerMask: m_groundMask);
        return idle;
    }
}
