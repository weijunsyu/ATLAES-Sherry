using UnityEngine;

public class PlayerDashingState : IState
{
    private PlayerStateController playerController = null;
    private StateMachine stateMachine = null;
    private MovementController movementController = null;
    private AnimationController animationController = null;

    private PlayerBasicAnimations animations = null;
    private Coroutine animate = null;

    private double timeInSeconds = 0d;
    private Sprite[] crouchDash;
    private float[] crouchTime;

    public PlayerDashingState(PlayerStateController playerController, StateMachine stateMachine)
    {
        this.playerController = playerController;
        this.stateMachine = stateMachine;

        movementController = playerController.movementController;
        animationController = playerController.animationController;
        animations = (PlayerBasicAnimations)animationController.animationsList;
        animate = animationController.animate;

        crouchDash = new Sprite[] { animations.dash[1], animations.dash[2], animations.dash[3], 
                                    animations.dash[4], animations.dash[5], animations.dash[6] };
        crouchTime = new float[] { PlayerBasicTimings.dashTimes[1], PlayerBasicTimings.dashTimes[2] , 
                                   PlayerBasicTimings.dashTimes[3], PlayerBasicTimings.dashTimes[4], 
                                   PlayerBasicTimings.dashTimes[5] };
    }

    public void Enter()
    {
        if (stateMachine.prevState == playerController.crouchingState) //omit first sprite when dashing from crouched position
        {
            animationController.RunAnimation(crouchDash, crouchTime, ref animate, false);
        }
        else
        {
            animationController.RunAnimation(animations.dash, PlayerBasicTimings.dashTimes, ref animate, false);
        }

        timeInSeconds = 0;
        movementController.UpdateAirborne(); // update airborne
        AdvancedMovement.Crouch(movementController);
        SpecialMovement.DashMove(movementController, PlayerBasicTimings.PLAYER_DASH_SPEED);
        
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
        BasicMovement.StopVertical(movementController);

        if (timeInSeconds >= PlayerBasicTimings.PLAYER_DASH_EXECUTE) // If dash is over
        {
            if (movementController.IsAirborne()) // if in the air
            {
                stateMachine.ChangeState(playerController.fallingState); // fall
            }
            else if (AdvancedMovement.CanStand(movementController))// else if on the ground and can stand
            {
                BasicMovement.StopHorizontal(movementController);
                if (timeInSeconds >= PlayerBasicTimings.PLAYER_DASH_TOTAL) // if recovery is over
                {
                    stateMachine.ChangeState(playerController.standingState); // stand
                }
            }
            else
            {
                stateMachine.ChangeState(playerController.crouchingState); // crouch
            }
            return;
        }
    }
    public void Exit()
    {
        // Disable player controller
        PlayerInputController.OnInputEvent -= HandleInput;

        BasicMovement.StopHorizontal(movementController);
        AdvancedMovement.Stand(movementController);

        if (animate != null)
        {
            animationController.StopAnimation(ref animate);
        }
    }
    private void HandleInput(object sender, InputEventArgs inputEvent)
    {
        switch (inputEvent.input)
        {
            case PlayerInputController.RawInput.JUMP_PRESS: // Jump
                if (AdvancedMovement.CanStand(movementController))
                {
                    stateMachine.ChangeState(playerController.jumpingState);
                }
                else
                {
                    stateMachine.ChangeState(playerController.crouchingState);
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
