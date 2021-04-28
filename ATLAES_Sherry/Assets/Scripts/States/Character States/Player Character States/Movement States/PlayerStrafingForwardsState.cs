using UnityEngine;

public class PlayerStrafingForwardsState : IState
{
    private PlayerStateController playerController = null;
    private StateMachine stateMachine = null;
    private MovementController movementController = null;
    private AnimationController animationController = null;

    private PlayerAnimations animations = null;
    private Coroutine animate = null;
    private float moveSpeed = 0;

    private double timeInSeconds = 0d;

    public PlayerStrafingForwardsState(PlayerStateController playerController, StateMachine stateMachine)
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
        SetStateParams();

        AdvancedMovement.Stand(movementController);
        movementController.SetAirborne(false);
        playerController.canAirDash = true;
        timeInSeconds = 0;

        // Enable player controller
        PlayerInputController.OnInputEvent += HandleInput;
    }
    public void ExecuteLogic()
    {
        timeInSeconds += Time.deltaTime;
        if (timeInSeconds >= GameConstants.PURE_CHARGE_UP_TIME)
        {
            playerController.isChargedStrafingFront = true;
            playerController.strafingFrontChargeTimer = 0d;
        }
    }
    public void ExecutePhysics()
    {
        movementController.UpdateAirborne(); // Check if still grounded
        if (movementController.IsAirborne() == true) // if airborne
        {
            stateMachine.ChangeState(playerController.fallingState); // Go to falling state
            return;
        }
        if (PlayerInputController.pressedInputs[5] == false) // guard release
        {
            stateMachine.ChangeState(playerController.standingState);
            return;
        }
        HandleMoveInput(moveSpeed);
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
                if (MasterManager.playerCharacterPersistentData.GetPrimaryWeapon() != WeaponType.NONE)
                {
                    stateMachine.ChangeState(playerController.inActionState);
                }
                break;
            case PlayerInputController.RawInput.MEDIUM_PRESS: // Medium
                if (MasterManager.playerCharacterPersistentData.GetPrimaryWeapon() != WeaponType.NONE)
                {
                    stateMachine.ChangeState(playerController.inActionState);
                }
                break;
            case PlayerInputController.RawInput.HEAVY_PRESS: // Heavy
                if (MasterManager.playerCharacterPersistentData.GetPrimaryWeapon() != WeaponType.NONE)
                {
                    stateMachine.ChangeState(playerController.inActionState);
                }
                break;
            case PlayerInputController.RawInput.CROUCH_PRESS: // Crouch
                stateMachine.ChangeState(playerController.crouchingGuardState);
                break;
        }
    }
    private void HandleMoveInput(float speed)
    {
        if (movementController.IsFacingRight()) // facing right
        {
            if (PlayerInputController.pressedInputs[1] == true) // right
            {
                BasicMovement.Strafe(movementController, speed);
            }
            else
            {
                stateMachine.ChangeState(playerController.standingGuardState);
            }
        }
        else // facing left
        {
            if (PlayerInputController.pressedInputs[2] == true) // left
            {
                BasicMovement.Strafe(movementController, -speed);
            }
            else
            {
                stateMachine.ChangeState(playerController.standingGuardState);
            }
        }
    }

    private void SetStateParams()
    {
        WeaponType weapon = MasterManager.playerCharacterPersistentData.GetPrimaryWeapon();
        switch (weapon)
        {
            case WeaponType.NONE:
                moveSpeed = PlayerTimings.PLAYER_WALK_SPEED;
                animationController.RunAnimation(animations.walkForwards, PlayerTimings.WALK_TIMES, ref animate, true);
                break;
            case WeaponType.UNARMED:
                moveSpeed = PlayerTimings.U_STRAFE_SPEED;
                animationController.RunAnimation(animations.uStrafe, PlayerTimings.U_STRAFE_TIMES, ref animate, true);
                break;
            default:
                moveSpeed = PlayerTimings.PLAYER_WALK_SPEED;
                animationController.RunAnimation(animations.walkForwards, PlayerTimings.WALK_TIMES, ref animate, true);
                break;
        }
    }
}
