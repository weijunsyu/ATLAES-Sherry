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

        BasicMovement.StopAll(movementController);
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
            case PlayerInputController.RawInput.JUMP_PRESS: // Jump
                if (!movementController.IsAirborne())
                {
                    stateMachine.ChangeState(playerController.jumpingState);
                }
                else if (playerController.canAirJump)
                {
                    stateMachine.ChangeState(playerController.jumpingState);
                    playerController.canAirJump = false;
                }
                break;
            case PlayerInputController.RawInput.CROUCH_PRESS: // Crouch
                if (!movementController.IsAirborne())
                {
                    stateMachine.ChangeState(playerController.crouchingState);
                }
                else
                {
                    stateMachine.ChangeState(playerController.fallingState);
                }
                break;
        }
    }
}
