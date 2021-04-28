using UnityEngine;

public class PlayerDashingState : IState
{
    private PlayerStateController playerController = null;
    private StateMachine stateMachine = null;
    private MovementController movementController = null;
    private AnimationController animationController = null;

    private PlayerAnimations animations = null;
    private Coroutine animate = null;

    private double timeInSeconds = 0d;

    public PlayerDashingState(PlayerStateController playerController, StateMachine stateMachine)
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
        playerController.canAirDash = false;
        if (PlayerInputController.pressedInputs[1] == true) // Turn right
        {
            movementController.FaceRight();
        }
        if (PlayerInputController.pressedInputs[2] == true) // Turn left
        {
            movementController.FaceLeft();
        }

        animationController.RunAnimation(animations.dash, PlayerTimings.DASH_TIMES, ref animate, false);

        timeInSeconds = 0;
        AdvancedMovement.Crouch(movementController);
        SpecialMovement.DashMove(movementController, PlayerTimings.PLAYER_DASH_SPEED);
        
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
        movementController.UpdateAirborne(); // update airborne

        if (timeInSeconds >= PlayerTimings.PLAYER_DASH_EXECUTE) // If dash is over
        {
            if (movementController.IsAirborne()) // if in the air
            {
                if (AdvancedMovement.CanStand(movementController))
                {
                    stateMachine.ChangeState(playerController.fallingState); // fall
                }
                else
                {
                    stateMachine.ChangeState(playerController.crouchingState); // crouch
                }
            }
            else if (AdvancedMovement.CanStand(movementController))// else if on the ground and can stand
            {
                BasicMovement.StopHorizontal(movementController);
                if (timeInSeconds >= PlayerTimings.PLAYER_DASH_TOTAL) // if recovery is over
                {
                    if (PlayerInputController.pressedInputs[1]) // if holding right, face right
                    {
                        movementController.FaceRight();
                    }
                    if (PlayerInputController.pressedInputs[2]) // if holding left, face left
                    {
                        movementController.FaceLeft();
                    }
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
            case PlayerInputController.RawInput.LIGHT_PRESS: // Light
                break;
            case PlayerInputController.RawInput.MEDIUM_PRESS: // Medium
                break;
            case PlayerInputController.RawInput.HEAVY_PRESS: // Heavy
                if (MasterManager.playerCharacterPersistentData.GetPrimaryWeapon() == WeaponType.UNARMED)
                {
                    stateMachine.ChangeState(playerController.inActionState);
                }
                break;
            case PlayerInputController.RawInput.JUMP_PRESS: // Jump
                if (!movementController.IsAirborne() && AdvancedMovement.CanStand(movementController))
                {
                    stateMachine.ChangeState(playerController.jumpingState);
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
