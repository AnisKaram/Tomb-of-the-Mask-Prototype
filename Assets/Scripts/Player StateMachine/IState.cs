public interface IState
{
    // Code that runs when we first enter the state
    void Enter();

    // Update runs each frame until a condition is detected that triggers a state change
    void Update();

    // Code that runs when we exit the state
    void Exit();
}