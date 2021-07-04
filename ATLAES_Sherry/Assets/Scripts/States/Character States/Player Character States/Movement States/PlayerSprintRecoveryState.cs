using UnityEngine;

public class PlayerSprintRecoveryState : IState
{
    private PlayerStateController playerController = null;
    private StateMachine stateMachine = null;
    private MovementController movementController = null;
    private AnimationController animationController = null;

    private PlayerAnimations animations = null;
    private Coroutine animate = null;

    private double timeInSeconds = 0d;


    public PlayerSprintRecoveryState(PlayerStateController playerController, StateMachine stateMachine)
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
        timeInSeconds = 0;

        animationController.SetSprite(animations.dash[5]);
        movementController.SetAirborne(false);
        playerController.canAirDash = true;

        BasicMovement.StopAll(movementController);
    }
    public void ExecuteLogic()
    {
        timeInSeconds += Time.deltaTime;

        if (timeInSeconds >= PlayerTimings.PLAYER_DASH_RECOVERY)
        {
            stateMachine.ChangeState(playerController.standingState);
        }
    }
    public void ExecutePhysics()
    {
        //handle falling, getting hit, and dying
        movementController.UpdateAirborne(); // Check if still grounded
        if (movementController.IsAirborne() == true) // if airborne
        {
            stateMachine.ChangeState(playerController.fallingState); // Go to falling state
            return;
        }
        HandleInputOnce(playerController.playerInputData);
    }
    public void Exit()
    {
        if (animate != null)
        {
            animationController.StopAnimation(ref animate);
        }
    }
    private void HandleInputOnce(PlayerInputData inputData)
    {
        if (inputData.inputTokens[6]) // Jump
        {
            inputData.EatInputToken(6);
            if (AdvancedMovement.CanStand(movementController)) // If can stand
            {
                if (!movementController.IsAirborne())
                {
                    stateMachine.ChangeState(playerController.jumpingState);
                }
            }
        }
        else if (inputData.inputTokens[3]) // Crouch
        {
            inputData.EatInputToken(3);
            if (!movementController.IsAirborne())
            {
                stateMachine.ChangeState(playerController.crouchingState);
            }
            else
            {
                stateMachine.ChangeState(playerController.fallingState);
            }
        }
    }
}
