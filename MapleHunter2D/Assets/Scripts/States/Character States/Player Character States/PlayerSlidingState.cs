using UnityEngine;

public class PlayerSlidingState : IState
{
    private PlayerStateController playerController = null;
    private StateMachine stateMachine = null;
    private MovementController movementController = null;
    private AnimationController animationController = null;

    public PlayerSlidingState(PlayerStateController playerController, StateMachine stateMachine)
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
        movementController.SetAirborne(false);
        playerController.canAirJump = true;
        playerController.canAirDash = true;
    }
    public void ExecuteLogic()
    {

    }
    public void ExecutePhysics()
    {
        AdvancedMovement.Slide(movementController, GameConstants.WALL_SLIDE_MAX_DROP_SPEED);
        PlayerStateController.HandleMoveInput(movementController);
        if (!PlayerStateController.HandleSlideCheck(movementController))
        {
            stateMachine.ChangeState(playerController.fallingState);
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
            case PlayerInputController.RawInput.JUMP_PRESS: // Sliding jump
                stateMachine.ChangeState(playerController.slidingJumpState);
                break;
        }
    }
}
