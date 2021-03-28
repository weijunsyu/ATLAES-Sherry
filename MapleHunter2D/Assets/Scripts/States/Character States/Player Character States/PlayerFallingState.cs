using UnityEngine;

public class PlayerFallingState : IState
{
    private PlayerStateController playerController = null;
    private StateMachine stateMachine = null;
    private MovementController movementController = null;
    private AnimationController animationController = null;

    public PlayerFallingState(PlayerStateController playerController, StateMachine stateMachine)
    {
        this.playerController = playerController;
        this.stateMachine = stateMachine;

        movementController = playerController.movementController;
        animationController = playerController.animationController;
    }

    public void Enter()
    {
        // Enable player controller
        PlayerInputController.OnInputEvent += HandleInput;

        BasicMovement.StopHorizontal(movementController);
        movementController.SetAirborne(true);
    }
    public void ExecuteLogic()
    {
        
    }
    public void ExecutePhysics()
    {
        //handle falling, getting hit, and dying
        movementController.UpdateAirborne(); // Check if still airborne
        if (movementController.IsAirborne() == false) // if grounded
        {
            stateMachine.ChangeState(playerController.standingState); // Go to standing state
        }
        PlayerStateController.HandleMoveInput(movementController);
        if (PlayerStateController.HandleSlideCheck(movementController))
        {
            stateMachine.ChangeState(playerController.slidingState);
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
                    stateMachine.ChangeState(playerController.dashingState);
                    playerController.canAirDash = false;
                }
                break;
            case PlayerInputController.RawInput.JUMP_PRESS: // Air jump
                if (playerController.canAirJump)
                {
                    stateMachine.ChangeState(playerController.jumpingState);
                    playerController.canAirJump = false;
                }
                break;
        }
    }
}
