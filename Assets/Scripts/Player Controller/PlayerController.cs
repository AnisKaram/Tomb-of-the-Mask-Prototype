using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Fields
    private StateMachine m_stateMachine;

    private Rigidbody2D m_rigidbody2D;
    private BoxCollider2D m_boxCollider2D;

    private bool m_isDashing;

    private Vector3 m_dashDirection;
    private Vector2 m_castDirection;
    private SwipeDirections m_swipeDirection;
    private float m_thrust = 0.2f;
    private float m_rotationAngle = 0;

    private int m_groundMask;

    // Added according to the swipe direction enum order.
    private float[] m_swipeAngles = new float[] { -90f, 90f, 180f, 0f };
    private Vector3[] m_dashDirections = new Vector3[] { Vector3.left, Vector3.right, Vector3.up, Vector3.down };
    #endregion


    #region Properties
    public StateMachine stateMachine => m_stateMachine;
    public bool isDashing => m_isDashing;
    #endregion


    #region Unity Methods
    private void Awake()
    {
        m_stateMachine = new StateMachine(this);

        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_boxCollider2D = GetComponent<BoxCollider2D>();

        m_swipeDirection = SwipeDirections.Null;

        m_groundMask = (1 << 10);

        SwipeDetectorManager.SwipeDetected += OnSwipeDetected;
    }
    private void Start()
    {
        m_stateMachine.Initialize(m_stateMachine.idleState);
    }
    private void Update()
    {
        m_stateMachine.Update(); // Update the current state.
    }
    private void FixedUpdate()
    {
        if (m_isDashing)
        {
            DashCharacter();
            if (IsPlayerIdle()) { m_isDashing = false; }
        }
    }
    private void OnDestroy()
    {
        SwipeDetectorManager.SwipeDetected -= OnSwipeDetected;
    }
    #endregion


    #region Private Methods
    private void OnSwipeDetected(SwipeDirections swipeDirection, Vector2 direction)
    {
        if (swipeDirection == m_swipeDirection) { return; } // avoid same swipe direction

        m_castDirection = direction;
        m_swipeDirection = swipeDirection;

        // Player rotation
        m_rotationAngle = m_swipeAngles[(int)swipeDirection];
        RotateCharacter();

        // Dash direction
        m_dashDirection = m_dashDirections[(int)swipeDirection];
        m_isDashing = true;
    }

    private void DashCharacter()
    {
        m_rigidbody2D.AddForce(m_dashDirection * m_thrust, ForceMode2D.Force);
    }
    private void RotateCharacter()
    {
        m_rigidbody2D.SetRotation(m_rotationAngle);
    }

    private bool IsPlayerIdle()
    {
        return Physics2D.BoxCast(
            origin: m_boxCollider2D.bounds.center,
            size: m_boxCollider2D.bounds.size,
            angle: 0f,
            direction: m_castDirection,
            distance: m_boxCollider2D.bounds.extents.x,
            layerMask: m_groundMask);
    }
    #endregion
}