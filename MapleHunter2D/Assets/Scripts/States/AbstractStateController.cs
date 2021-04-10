using UnityEngine;

[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(AnimationController))]
public abstract class AbstractStateController : MonoBehaviour
{
    //Config Parameters:

    // Cached References:
    [HideInInspector] public MovementController movementController;
    [HideInInspector] public AnimationController animationController;

    // State Parameters and Objects:
    [HideInInspector] public StateMachine stateMachine = null;
    [HideInInspector] public IState startState = null;
    [HideInInspector] public StateMachine actionStateMachine = null;
    [HideInInspector] public IState actionStartState = null;

    // Unity Events:
    protected virtual void Awake()
    {
        movementController = GetComponent<MovementController>();
        animationController = GetComponent<AnimationController>();
        stateMachine = new StateMachine();
        actionStateMachine = new StateMachine();
        InitializeStates();
    }
    protected virtual void Start()
    {
        InitializeStateMachine();
    }
    protected virtual void Update()
    {
        stateMachine.state.ExecuteLogic();
        actionStateMachine.state.ExecuteLogic();
    }
    protected virtual void FixedUpdate()
    {
        stateMachine.state.ExecutePhysics();
        actionStateMachine.state.ExecutePhysics();
    }

    // Class Functions:
    protected abstract void InitializeStates();

    protected virtual void InitializeStateMachine()
    {
        stateMachine.Initialize(startState);
        actionStateMachine.Initialize(actionStartState);
    }
}
