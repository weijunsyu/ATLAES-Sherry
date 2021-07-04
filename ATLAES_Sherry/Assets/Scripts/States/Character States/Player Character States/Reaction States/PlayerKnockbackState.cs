using UnityEngine;

public class PlayerKnockbackState : IState
{
    private PlayerStateController playerController = null;
    private StateMachine stateMachine = null;
    private MovementController movementController = null;
    private AnimationController animationController = null;

    private PlayerAnimations animations = null;
    private Coroutine animate = null;

    public PlayerKnockbackState(PlayerStateController playerController, StateMachine stateMachine)
    {
        this.playerController = playerController;
        this.stateMachine = stateMachine;

        movementController = playerController.movementController;
        animationController = playerController.animationController;
        animations = (PlayerAnimations)animationController.animationsList;
        animate = animationController.animate;
    }

    public void Enter()
    {
        RunAnimation();

        BasicMovement.StopHorizontal(movementController);
        AdvancedMovement.Crouch(movementController);
        playerController.canAirDash = true;
    }
    public void ExecuteLogic()
    {

    }
    public void ExecutePhysics()
    {

    }
    public void Exit()
    {
        if (animate != null)
        {
            animationController.StopAnimation(ref animate);
        }
    }
    private void HandleInput(PlayerInputData inputData)
    {

    }
    private void RunAnimation()
    {

    }
}
