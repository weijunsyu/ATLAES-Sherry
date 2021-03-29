using UnityEngine;

public class PlayerSlidingJumpState : IState
{
    private PlayerStateController playerController = null;
    private StateMachine stateMachine = null;
    private MovementController movementController = null;
    private AnimationController animationController = null;

    private PlayerBasicAnimations animations = null;

    private double timeInSeconds = 0d;

    public PlayerSlidingJumpState(PlayerStateController playerController, StateMachine stateMachine)
    {
        this.playerController = playerController;
        this.stateMachine = stateMachine;

        movementController = playerController.movementController;
        animationController = playerController.animationController;
        animations = (PlayerBasicAnimations)animationController.animationsList;
    }

    public void Enter()
    {
        animationController.SetSprite(animations.slideJump[0]);

        timeInSeconds = 0;
        HandleHorizontalVelocity(PlayerBasicTimings.PLAYER_AIR_MOVE_SPEED);
        BasicMovement.Jump(movementController, PlayerBasicTimings.PLAYER_SIDING_JUMP_VELOCITY);
        movementController.SetAirborne(true);
    }
    public void ExecuteLogic()
    {
        timeInSeconds += Time.deltaTime;
    }
    public void ExecutePhysics()
    {
        // If falling or finished jump
        if (movementController.GetVelocity().y <= 0 || timeInSeconds >PlayerBasicTimings.PLAYER_SLIDE_JUMP_DURATION)
        {
            stateMachine.ChangeState(playerController.fallingState);
            return;
        }
        movementController.UpdateAirborne();
        if (!movementController.IsAirborne())
        {
            stateMachine.ChangeState(playerController.standingState);
        }
    }
    public void Exit()
    {

    }

    private void HandleHorizontalVelocity(float speed)
    {
        if (movementController.IsFacingRight())
        {
            //jump left
            BasicMovement.MoveWithTurn(movementController, -speed);
        }
        else
        {
            //jump right
            BasicMovement.MoveWithTurn(movementController, speed);
        }
    }
}
