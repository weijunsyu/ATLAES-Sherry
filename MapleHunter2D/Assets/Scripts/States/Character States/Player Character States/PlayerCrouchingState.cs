using UnityEngine;

public class PlayerCrouchingState : IState
{

    private PlayerStateController playerController = null;
    private StateMachine stateMachine = null;
    private MovementController movementController = null;
    private AnimationController animationController = null;

    private PlayerBasicAnimations animations = null;
    private Coroutine animate = null;

    public PlayerCrouchingState(PlayerStateController playerController, StateMachine stateMachine)
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
        if (stateMachine.prevState == playerController.dashingState)
        {
            animationController.SetSprite(animations.crouch[1]);
        }
        else
        {
            animationController.RunAnimation(animations.crouch, PlayerBasicTimings.crouchTimes, ref animate);
        }

        BasicMovement.StopHorizontal(movementController);
        AdvancedMovement.Crouch(movementController);
        playerController.canAirDash = true;

        // Enable player controller
        PlayerInputController.OnInputEvent += HandleInput;
    }
    public void ExecuteLogic()
    {
        if (PlayerInputController.pressedInputs[1] == true) // Turn right
        {
            movementController.FaceRight();
        }
        if (PlayerInputController.pressedInputs[2] == true) // Turn left
        {
            movementController.FaceLeft();
        }
    }
    public void ExecutePhysics()
    {
        //handle falling, getting hit, and dying
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
                //stateMachine.ChangeState(playerController.crouchingGuardState);
                break;
            case PlayerInputController.RawInput.DASH_PRESS: // Dash
                stateMachine.ChangeState(playerController.dashingState);
                break;
            case PlayerInputController.RawInput.CROUCH_RELEASE: // Stop Crouching
                if (AdvancedMovement.CanStand(movementController))
                {
                    stateMachine.ChangeState(playerController.standingState);
                }
                break;
        }
    }
}
