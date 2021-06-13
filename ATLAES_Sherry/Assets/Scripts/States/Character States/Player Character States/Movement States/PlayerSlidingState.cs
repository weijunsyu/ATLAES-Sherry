using UnityEngine;

public class PlayerSlidingState : IState
{
    private PlayerStateController playerController = null;
    private StateMachine stateMachine = null;
    private MovementController movementController = null;
    private AnimationController animationController = null;

    private PlayerAnimations animations = null;
    private Coroutine animate = null;
    //private bool animationIsPlaying = false;

    public PlayerSlidingState(PlayerStateController playerController, StateMachine stateMachine)
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
        animationController.RunAnimation(animations.slide, PlayerTimings.SLIDE_TIMES, ref animate, true);
        playerController.weapons.isSliding = true;

        BasicMovement.StopHorizontal(movementController);
        playerController.canAirDash = true;

        // Enable player controller
        PlayerInputController.OnInputEvent += HandleInput;
    }
    public void ExecuteLogic()
    {

    }
    public void ExecutePhysics()
    {
        AdvancedMovement.Slide(movementController, GameConstants.WALL_SLIDE_MAX_DROP_SPEED);
        playerController.HandleAirborneMoveInput(PlayerTimings.PLAYER_AIR_MOVE_SPEED);
        if (playerController.HandleSlideCheck()) // is sliding
        {
            movementController.UpdateAirborne();
            if (!movementController.IsAirborne())
            {
                movementController.UpdateIsOnSlope();
                stateMachine.ChangeState(playerController.standingState);
            }
        }
        else // is not sliding
        {
            stateMachine.ChangeState(playerController.fallingState);
            return;
        }
    }
    public void Exit()
    {
        // Disable player controller
        PlayerInputController.OnInputEvent -= HandleInput;

        if (animate != null)
        {
            animationController.StopAnimation(ref animate);
        }

        playerController.weapons.isSliding = false;
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
