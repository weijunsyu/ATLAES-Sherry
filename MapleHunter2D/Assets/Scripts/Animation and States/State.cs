

public interface State
{
    public void Enter(); // On entry to State
    public void Execute(); // During State lifetime
    public void Exit(); // On exit of State
}
