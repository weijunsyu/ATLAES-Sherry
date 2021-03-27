using UnityEngine;

public class PlayerDashingState : IState
{
    private PlayerStateController playerController = null;
    private StateMachine stateMachine = null;
    private MovementController movementController = null;
    private AnimationController animationController = null;

    private double timerInSeconds = 0d;

    public PlayerDashingState(PlayerStateController playerController, StateMachine stateMachine)
    {
        this.playerController = playerController;
        this.stateMachine = stateMachine;

        movementController = playerController.movementController;
        animationController = playerController.animationController;
    }

    public void Enter()
    {
        timerInSeconds = 0;
        // Enable player controller
        PlayerInputController.OnInputEvent += HandleInput;

        Debug.Log("DashingState");
        BasicMovement.StopHorizontal(movementController);
        SpecialMovement.DashMove(movementController, 10f);
    }
    public void ExecuteLogic()
    {

        timerInSeconds += Time.deltaTime;
    }
    public void ExecutePhysics()
    {
        //handle falling, getting hit, and dying
        BasicMovement.StopVertical(movementController);

        if (timerInSeconds >= 0.2d) // If dash is over
        {
            movementController.UpdateAirborne(); // update airborne
            if (movementController.IsAirborne()) // if in the air
            {
                stateMachine.ChangeState(playerController.fallingState); // fall
            }
            else // else if on the ground
            {
                stateMachine.ChangeState(playerController.standingState); // stand
            }
        }
    }
    public void Exit()
    {
        // Disable player controller
        PlayerInputController.OnInputEvent -= HandleInput;

        BasicMovement.StopHorizontal(movementController);
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
        }
    }
}
