

public interface IState
{
    void Enter(); // On entry to State
    void ExecuteLogic(); // Update function of Unity
    void ExecutePhysics(); // FixedUpdate function of Unity
    void Exit(); // On exit of State
}



