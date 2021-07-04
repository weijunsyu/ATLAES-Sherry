using UnityEngine;

public class PlayerSlidingJumpState : IState
{
    private PlayerStateController playerController = null;
    private StateMachine stateMachine = null;
    private MovementController movementController = null;
    private AnimationController animationController = null;

    private PlayerAnimations animations = null;

    private double timeInSeconds = 0d;
    private bool isFacingRight = false;

    public PlayerSlidingJumpState(PlayerStateController playerController, StateMachine stateMachine)
    {
        this.playerController = playerController;
        this.stateMachine = stateMachine;

        movementController = playerController.movementController;
        animationController = playerController.animationController;
        animations = (PlayerAnimations)animationController.animationsList;
    }

    public void Enter()
    {
        animationController.SetSprite(animations.slideJump[0]);

        timeInSeconds = 0;
        isFacingRight = movementController.IsFacingRight();
        HandleHorizontalVelocity(PlayerTimings.PLAYER_AIR_MOVE_SPEED);
        BasicMovement.Jump(movementController, PlayerTimings.PLAYER_SIDING_JUMP_VELOCITY);
        movementController.SetAirborne(true);
    }
    public void ExecuteLogic()
    {
        timeInSeconds += Time.deltaTime;
    }
    public void ExecutePhysics()
    {
        // If falling or finished jump
        if (movementController.GetVelocity().y <= 0 || timeInSeconds >PlayerTimings.PLAYER_SLIDE_JUMP_DURATION)
        {
            HandleTurnOnExit();
            stateMachine.ChangeState(playerController.fallingState);
            return;
        }
        movementController.UpdateAirborne();
        if (!movementController.IsAirborne())
        {
            movementController.UpdateIsOnSlope();
            stateMachine.ChangeState(playerController.standingState);
        }
    }
    public void Exit()
    {

    }
    private void HandleTurnOnExit()
    {
        if (playerController.playerInputData.pressedInputs[1] == true) // right
        {
            movementController.FaceRight();
        }
        else if (playerController.playerInputData.pressedInputs[2] == true) // left
        {
            movementController.FaceLeft();
        }
    }
    private void HandleHorizontalVelocity(float speed)
    {
        if (isFacingRight)
        {
            //jump left
            BasicMovement.Strafe(movementController, -speed);
        }
        else
        {
            //jump right
            BasicMovement.Strafe(movementController, speed);
        }
    }
}
