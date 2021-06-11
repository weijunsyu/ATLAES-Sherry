using UnityEngine;

public class PlayerStandingGuardState : IState
{
    private PlayerStateController playerController = null;
    private StateMachine stateMachine = null;
    private MovementController movementController = null;
    private AnimationController animationController = null;

    private PlayerAnimations animations = null;
    private Coroutine animate = null;

    private double timeInSeconds = 0d;

    public PlayerStandingGuardState(PlayerStateController playerController, StateMachine stateMachine)
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
        RunAnimation();
        if (movementController.IsOnSlope())
        {
            movementController.boxCollider.sharedMaterial = movementController.slopeMaterial;
        }
        BasicMovement.StopHorizontal(movementController, true);
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
            playerController.isChargedStanding = true;
            playerController.standingChargeTimer = 0d;
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
        if (PlayerInputController.pressedInputs[1]) // right
        {
            if (movementController.IsFacingRight())
            {
                if (!AdvancedMovement.CheckFront(movementController))
                {
                    stateMachine.ChangeState(playerController.strafingForwardsState);
                    return;
                } 
            }
            else
            {
                if (!AdvancedMovement.CheckBack(movementController))
                {
                    stateMachine.ChangeState(playerController.strafingBackwardsState);
                    return;
                }
            }
            
        }
        if (PlayerInputController.pressedInputs[2]) // left
        {
            if (movementController.IsFacingRight())
            {
                if (!AdvancedMovement.CheckBack(movementController))
                {
                    stateMachine.ChangeState(playerController.strafingBackwardsState);
                    return;
                }
            }
            else
            {
                if (!AdvancedMovement.CheckFront(movementController))
                {
                    stateMachine.ChangeState(playerController.strafingForwardsState);
                    return;
                }
            }
        }
        if (PlayerInputController.pressedInputs[5] == false) // guard release
        {
            stateMachine.ChangeState(playerController.standingState);
            return;
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
        movementController.boxCollider.sharedMaterial = movementController.standardMaterial;
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
            case PlayerInputController.RawInput.CROUCH_PRESS: // Crouch
                stateMachine.ChangeState(playerController.crouchingGuardState);
                break;
        }
    }
    private void RunAnimation()
    {
        WeaponType weapon = MasterManager.playerData.GetPrimaryWeapon();
        switch (weapon)
        {
            case WeaponType.NONE:
                animationController.RunAnimation(animations.idle, PlayerTimings.IDLE_TIMES, ref animate, true);
                break;
            case WeaponType.UNARMED:
                animationController.RunAnimation(animations.uStandGuard, PlayerTimings.U_GUARD_TIMES, ref animate, true);
                break;
            default:
                animationController.RunAnimation(animations.idle, PlayerTimings.IDLE_TIMES, ref animate, true);
                break;
        }
    }
}
