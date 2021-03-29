using UnityEngine;

public class PlayerSlidingState : IState
{
    private PlayerStateController playerController = null;
    private StateMachine stateMachine = null;
    private MovementController movementController = null;
    private AnimationController animationController = null;

    private PlayerBasicAnimations animations = null;
    private Coroutine animate = null;

    public PlayerSlidingState(PlayerStateController playerController, StateMachine stateMachine)
    {
        this.playerController = playerController;
        this.stateMachine = stateMachine;

        movementController = playerController.movementController;
        animationController = playerController.animationController;
        animations = (PlayerBasicAnimations)animationController.animationsList;
        animate = animationController.animate;
    }

    public void Enter()
    {
        animationController.RunAnimation(animations.slide, PlayerBasicTimings.slideTimes, ref animate, true);

        BasicMovement.StopHorizontal(movementController);
        movementController.SetAirborne(false);
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
        playerController.HandleMoveInput(PlayerBasicTimings.PLAYER_AIR_MOVE_SPEED);
        if (!playerController.HandleSlideCheck())
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
