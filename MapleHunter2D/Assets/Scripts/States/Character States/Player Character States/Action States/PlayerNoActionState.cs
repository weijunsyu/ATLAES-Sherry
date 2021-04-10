
public class PlayerNoActionState : IState
{
    private PlayerStateController playerController = null;
    private StateMachine stateMachine = null;
    private MovementController movementController = null;
    private AnimationController animationController = null;

    public PlayerNoActionState(PlayerStateController playerController, StateMachine stateMachine)
    {
        this.playerController = playerController;
        this.stateMachine = stateMachine;

        movementController = playerController.movementController;
        animationController = playerController.animationController;
    }

    public void Enter()
    {

    }
    public void ExecuteLogic()
    {

    }
    public void ExecutePhysics()
    {

    }
    public void Exit()
    {

    }
}
