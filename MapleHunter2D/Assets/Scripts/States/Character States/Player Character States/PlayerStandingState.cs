using UnityEngine;

public class PlayerStandingState : IState
{
    private PlayerStateController playerController = null;
    private StateMachine stateMachine = null;
    private MovementController movementController = null;
    private AnimationController animationController = null;

    public PlayerStandingState(PlayerStateController playerController, StateMachine stateMachine)
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

        Debug.Log("StandingState");
        BasicMovement.StopHorizontal(movementController);
        AdvancedMovement.Stand(movementController);
    }
    public void ExecuteLogic()
    {

    }
    public void ExecutePhysics()
    {
        if (PlayerInputController.pressedInputs[1] == true)
        {
            BasicMovement.MoveWithTurn(movementController, 5f);
            return;
        }
        else if (PlayerInputController.pressedInputs[2] == true)
        {
            BasicMovement.MoveWithTurn(movementController, -5f);
            return;
        }

        else if (PlayerInputController.pressedInputs[1] == false)
        {
            BasicMovement.StopHorizontal(movementController);
            return;
        }
        else if (PlayerInputController.pressedInputs[2] == false)
        {
            BasicMovement.StopHorizontal(movementController);
            return;
        }
        //handle falling, getting hit, and dying
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
            case PlayerInputController.RawInput.GUARD_PRESS: // Guard
                //stateMachine.ChangeState(playerController.standingGuardState);
                break;
            case PlayerInputController.RawInput.JUMP_PRESS: // Jump
                stateMachine.ChangeState(playerController.jumpingState);
                break;
            case PlayerInputController.RawInput.CROUCH_PRESS: // Crouch
                stateMachine.ChangeState(playerController.crouchingState);
                break;
            case PlayerInputController.RawInput.DASH_PRESS: // Dash
                stateMachine.ChangeState(playerController.dashingState);
                break;
        }
    }
}
