
public abstract class AbstractState
{
    protected int animationID;
    protected AnimationController animationController = null;
    protected MovementController movementController = null;

    public abstract void Enter(); // On entry to State
    public abstract void Execute(); // During State lifetime (Looped like Update function in Unity)
    public abstract void Exit(); // On exit of State
}
