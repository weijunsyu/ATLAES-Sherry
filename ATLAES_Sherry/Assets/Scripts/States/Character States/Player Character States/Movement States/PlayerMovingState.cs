using UnityEngine;

public class PlayerMovingState : IState
{
    private PlayerStateController playerController = null;
    private StateMachine stateMachine = null;
    private MovementController movementController = null;
    private AnimationController animationController = null;

    private PlayerAnimations animations = null;
    private Coroutine animate = null;

    private AnimationController.Animation runStarup;
    private AnimationController.Animation runLoop;

    private double timeInSeconds = 0d;

    public PlayerMovingState(PlayerStateController playerController, StateMachine stateMachine)
    {
        this.playerController = playerController;
        this.stateMachine = stateMachine;

        movementController = playerController.movementController;
        animationController = playerController.animationController;
        animations = (PlayerAnimations)animationController.animationsList;
        animate = animationController.animate;

        runStarup.sprites = new Sprite[] { animations.walkForwards[1], animations.walkForwards[2], animations.run[3],
                                           animations.run[4], animations.run[5], animations.run[6], animations.run[7] };
        runStarup.timings = new float[] { 0.1f, 0.08f, 0.08f, 0.08f, 0.08f, 0.08f, 0.08f} ;
        runStarup.runNum = 1;

        runLoop.sprites = animations.run;
        runLoop.timings = PlayerTimings.RUN_TIMES;
        runLoop.runNum = 0;
    }

    public void Enter()
    {
        animationController.RunCompoundAnimation(ref animate, new AnimationController.Animation[] { runStarup, runLoop });

        movementController.SetAirborne(false);
        playerController.canAirDash = true;

        if (!playerController.isFlashCharging)
        {
            // If was not flash charging prior, reset timer
            timeInSeconds = 0d;
        }
        WeaponType weapon = MasterManager.playerData.GetPrimaryWeapon();
        if (weapon == WeaponType.NONE)
        {
            playerController.isFlashCharging = true; // Set flash charging to true
        }
        
        // Enable player controller
        PlayerInputController.OnInputEvent += HandleInput;
    }
    public void ExecuteLogic()
    {
        timeInSeconds += Time.deltaTime;
        playerController.flashChargeGraceTimer = 0d;
    }
    public void ExecutePhysics()
    {
        movementController.UpdateAirborne(); // Check if still grounded
        if (movementController.IsAirborne() == true) // if airborne
        {
            stateMachine.ChangeState(playerController.fallingState); // Go to falling state
            return;
        }

        if (timeInSeconds < GameConstants.FLASH_RUN_DELAY)
        {
            HandleMoveInput(PlayerTimings.PLAYER_RUN_SPEED);
        }
        else
        {
            playerController.isFlashing = true;
            playerController.flashCooldownTimer = 0d;
            HandleMoveInput(PlayerTimings.PLAYER_FLASH_SPEED);
        }

        if (AdvancedMovement.CheckFront(movementController))
        {
            playerController.isFlashCharging = false;
            stateMachine.ChangeState(playerController.standingState);
            return;
        }

        if (movementController.IsOnSlope())
        {
            timeInSeconds = 0d;
        }
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
                if (MasterManager.playerData.GetPrimaryWeapon() != WeaponType.NONE)
                {
                    stateMachine.ChangeState(playerController.inActionState);
                }
                break;
            case PlayerInputController.RawInput.MEDIUM_PRESS: // Medium
                if (MasterManager.playerData.GetPrimaryWeapon() != WeaponType.NONE)
                {
                    stateMachine.ChangeState(playerController.inActionState);
                }
                break;
            case PlayerInputController.RawInput.HEAVY_PRESS: // Heavy
                if (MasterManager.playerData.GetPrimaryWeapon() != WeaponType.NONE)
                {
                    stateMachine.ChangeState(playerController.inActionState);
                }
                break;
            case PlayerInputController.RawInput.GUARD_PRESS: // Guard
                stateMachine.ChangeState(playerController.standingGuardState);
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
