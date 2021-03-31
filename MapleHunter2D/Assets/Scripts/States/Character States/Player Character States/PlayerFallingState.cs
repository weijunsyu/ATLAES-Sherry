using UnityEngine;

public class PlayerFallingState : IState
{
    private PlayerStateController playerController = null;
    private StateMachine stateMachine = null;
    private MovementController movementController = null;
    private AnimationController animationController = null;

    private PlayerAnimations animations = null;

    private double timeInSeconds = 0d;

    public PlayerFallingState(PlayerStateController playerController, StateMachine stateMachine)
    {
        this.playerController = playerController;
        this.stateMachine = stateMachine;

        movementController = playerController.movementController;
        animationController = playerController.animationController;
        animations = (PlayerAnimations)animationController.animationsList;
    }

    public void Enter()
    {
        animationController.SetSprite(animations.fall[0]);

        timeInSeconds = 0d;
        movementController.SetAirborne(true);

        // Enable player controller
        PlayerInputController.OnInputEvent += HandleInput;
    }
    public void ExecuteLogic()
    {
        timeInSeconds += Time.deltaTime;
    }
    public void ExecutePhysics()
    {
        //handle falling, getting hit, and dying
        movementController.UpdateAirborne(); // Check if still airborne
        if (movementController.IsAirborne() == false) // if grounded
        {
            stateMachine.ChangeState(playerController.standingState); // Go to standing state
            return;
        }
        playerController.HandleMoveInput(PlayerTimings.PLAYER_AIR_MOVE_SPEED);
        if (playerController.HandleSlideCheck())
        {
            stateMachine.ChangeState(playerController.slidingState);
            return;
        }
    }
    public void Exit()
    {
        // Disable player controller
        PlayerInputController.OnInputEvent -= HandleInput;

    }
    private void HandleInput(object sender, InputEventArgs inputEvent)
    {
        switch (inputEvent.input)
        {
            case PlayerInputController.RawInput.LIGHT_PRESS: // Light
                //stateMachine.ChangeState(playerController.lightState);
                break;
            case PlayerInputController.RawInput.MEDIUM_PRESS: // Medium
                //stateMachine.ChangeState(playerController.mediumState);
                break;
            case PlayerInputController.RawInput.HEAVY_PRESS: // Heavy
                //stateMachine.ChangeState(playerController.heavyState);
                break;
            case PlayerInputController.RawInput.DASH_PRESS: // Dash
                if (playerController.canAirDash)
                {
                    playerController.canAirDash = false;
                    stateMachine.ChangeState(playerController.dashingState);
                }
                break;
            case PlayerInputController.RawInput.JUMP_PRESS: // Air jump
                if (stateMachine.prevState == playerController.standingState)
                {
                    if (timeInSeconds < GameConstants.COYOTE_JUMP_DELAY)
                    {
                        stateMachine.ChangeState(playerController.jumpingState);
                    }
                }
                else if (stateMachine.prevState == playerController.dashingState)
                {
                    stateMachine.ChangeState(playerController.jumpingState);
                }
                else // Previous state was NOT standing state
                {
                    playerController.jumpBufferTimer = 0d; // Reset the timer
                    playerController.jumpInputBuffer = true; // Buffer the jump command
                }
                break;
        }
    }
}
