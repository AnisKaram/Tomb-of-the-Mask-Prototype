using UnityEngine.Events;

public class StateMachine
{
    #region Fields
    private IState m_currentState;

    private IdleState m_idleState;
    private DashingState m_dashingState;
    #endregion


    #region Properties
    public IState currentState => m_currentState;
    public IdleState idleState => m_idleState;
    public DashingState dashingState => m_dashingState;
    #endregion


    #region Events
    public event UnityAction<IState> StateChanged;
    #endregion


    #region Constructor
    public StateMachine(PlayerController playerController)
    {
        this.m_idleState = new IdleState(playerController);
        this.m_dashingState = new DashingState(playerController);
    }
    #endregion


    #region Public Methods
    /// <summary>
    /// Initialize the state
    /// </summary>
    /// <param name="state">State to enter</param>
    public void Initialize(IState state)
    {
        m_currentState = state;
        m_currentState.Enter();

        // Notify other objects state has changed
        StateChanged?.Invoke(m_currentState);
    }

    /// <summary>
    /// Transition to another state
    /// </summary>
    /// <param name="nextState">State to transition to</param>
    public void TransitionTo(IState nextState)
    {
        m_currentState.Exit();

        m_currentState = nextState;
        m_currentState.Enter();

        // Notify other objects state has changed
        StateChanged.Invoke(m_currentState);
    }

    /// <summary>
    /// Allow the state machine to update the current state
    /// </summary>
    public void Update()
    {
        if (m_currentState != null)
        {
            m_currentState.Update();
        }
    }
    #endregion
}