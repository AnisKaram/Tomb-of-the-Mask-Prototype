public interface IState
{
    // Code that runs when we first enter the state
    void Enter();

    // Pre-frame logic, include condition to transition to a new state.
    void Update();

    // Code that runs when we exit the state
    void Exit();
}