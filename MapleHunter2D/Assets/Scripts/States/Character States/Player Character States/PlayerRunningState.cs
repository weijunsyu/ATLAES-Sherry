using UnityEngine;

public class PlayerRunningState : IState
{
    private PlayerStateController playerController = null;
    private StateMachine stateMachine = null;
    private MovementController movementController = null;
    private AnimationController animationController = null;

    private PlayerBasicAnimations animations = null;
    private Coroutine animate = null;

    AnimationController.Animation runStarup;
    AnimationController.Animation runLoop;

    public PlayerRunningState(PlayerStateController playerController, StateMachine stateMachine)
    {
        this.playerController = playerController;
        this.stateMachine = stateMachine;

        movementController = playerController.movementController;
        animationController = playerController.animationController;
        animations = (PlayerBasicAnimations)animationController.animationsList;
        animate = animationController.animate;

        runStarup.sprites = new Sprite[] { animations.walk[1], animations.walk[2], animations.run[3],
                                           animations.run[4], animations.run[5], animations.run[6], animations.run[7] };
        runStarup.timings = new float[] { 0.1f, 0.08f, 0.08f, 0.08f, 0.08f, 0.08f, 0.08f} ;
        runStarup.runNum = 1;

        runLoop.sprites = animations.run;
        runLoop.timings = PlayerBasicTimings.runTimes;
        runLoop.runNum = 0;
    }

    public void Enter()
    {
        animationController.RunCompoundAnimation(ref animate, new AnimationController.Animation[] { runStarup, runLoop });

        //BasicMovement.StopHorizontal(movementController);
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
        movementController.UpdateAirborne(); // Check if still grounded
        if (movementController.IsAirborne() == true) // if airborne
        {
            stateMachine.ChangeState(playerController.fallingState); // Go to falling state
            return;
        }
        HandleMoveInput(PlayerBasicTimings.PLAYER_RUN_SPEED);
        //getting hit, and dying
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
    private void HandleMoveInput(float speed)
    {
        // Since we clean SOCD in input controller only 1 input (right/left) can be pressed at once
        if (PlayerInputController.pressedInputs[1] == true) // right
        {
            BasicMovement.MoveWithTurn(movementController, speed);
        }
        else if (PlayerInputController.pressedInputs[2] == true) // left
        {
            BasicMovement.MoveWithTurn(movementController, -speed);
        }
        else // right and left both unpressed
        {
            stateMachine.ChangeState(playerController.standingState);
        }
    }
}
