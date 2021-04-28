using System.Collections.Generic;

public class StateMachine
{
    // Config Parameters:

    // Cached References:

    // State Parameters and Objects:
    //public Stack<IState> stateStack = new Stack<IState>();
    public IState state;
    public IState prevState;


    // Class Functions:
    public void Initialize(IState startState)
    {
        //stateStack.Push(startState);
        state = startState;
        prevState = startState;
        startState.Enter();
    }
    public void ChangeState(IState newState)
    {
        //stateStack.Peek().Exit();
        //stateStack.Push(newState);
        //newState.Enter();
        state.Exit();
        prevState = state;
        state = newState;
        state.Enter();
    }
}
