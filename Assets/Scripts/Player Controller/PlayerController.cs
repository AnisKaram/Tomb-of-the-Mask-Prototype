using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D m_rigidbody2D;
    private BoxCollider2D m_boxCollider2D;

    public bool canDash;

    public Vector3 m_dashDirection;
    public SwipeDirections m_swipeDirection;
    public float m_thurst = 0.05f;

    public LayerMask m_groundMask;

    public float distance;

    private void Awake()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_boxCollider2D = GetComponent<BoxCollider2D>();

        m_swipeDirection = SwipeDirections.Null;

        // testing
        distance = m_boxCollider2D.bounds.extents.x;

        SwipeDetectorManager.SwipeDetected += OnSwipeDetected;
    }

    private void OnDestroy()
    {
        SwipeDetectorManager.SwipeDetected -= OnSwipeDetected;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            OnSwipeDetected(SwipeDirections.Left);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            OnSwipeDetected(SwipeDirections.Right);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            OnSwipeDetected(SwipeDirections.Up);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            OnSwipeDetected(SwipeDirections.Down);
        }
    }

    private void OnSwipeDetected(SwipeDirections swipeDirection)
    {
        if (canDash) { return; }

        if (swipeDirection == m_swipeDirection) { return; }

        m_swipeDirection = swipeDirection;

        // Dash direction
        if (swipeDirection == SwipeDirections.Left || swipeDirection == SwipeDirections.Right)
        {
            m_dashDirection = transform.right;
        }
        else if (swipeDirection == SwipeDirections.Up || swipeDirection == SwipeDirections.Down)
        {
            m_dashDirection = transform.up;
        }

        // Thrust
        if (swipeDirection == SwipeDirections.Up || swipeDirection == SwipeDirections.Right)
        {
            m_thurst = 0.05f;
        }
        else if (swipeDirection == SwipeDirections.Down || swipeDirection == SwipeDirections.Left)
        {
            m_thurst = -0.05f;
        }

        canDash = true;
    }

    // -----
    // TODO Move the code to the states and StateMachine
    // -----

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canDash)
        {
            DashPlayer();

            bool idle = Physics2D.BoxCast(m_boxCollider2D.bounds.center, m_boxCollider2D.bounds.size, 0f, Vector2.left, m_boxCollider2D.bounds.extents.x, m_groundMask);
            Debug.Log($"is idle: {idle}");
        }
    }

    // Direction is transform.up or right
    private void DashPlayer()
    {
        m_rigidbody2D.AddForce(m_dashDirection * m_thurst, ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canDash && collision.collider.CompareTag("Ground"))
        {
            //canDash = false;
        }
    }
}
