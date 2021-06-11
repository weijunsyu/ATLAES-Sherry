using UnityEngine;

public class PlayerCombatIdleState : IState
{
    private PlayerStateController playerController = null;
    private StateMachine stateMachine = null;
    private MovementController movementController = null;
    private AnimationController animationController = null;

    private PlayerAnimations animations = null;
    private Coroutine animate = null;

    public PlayerCombatIdleState(PlayerStateController playerController, StateMachine stateMachine)
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

        if (playerController.jumpInputBuffer)
        {
            playerController.jumpInputBuffer = false;
            stateMachine.ChangeState(playerController.jumpingState);
            return;
        }

        // Enable player controller
        PlayerInputController.OnInputEvent += HandleInput;
    }
    public void ExecuteLogic()
    {
        if (!playerController.isInCombat)
        {
            stateMachine.ChangeState(playerController.standingState);
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
        if (PlayerInputController.pressedInputs[1] || PlayerInputController.pressedInputs[2]) // right or left
        {
            stateMachine.ChangeState(playerController.movingState);
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
    private void RunAnimation()
    {
        WeaponType weapon = MasterManager.playerData.GetPrimaryWeapon();
        switch (weapon)
        {
            case WeaponType.NONE:
                animationController.RunAnimation(animations.idle, PlayerTimings.IDLE_TIMES, ref animate, true);
                Debug.LogError("Combat Idle in NONE weapon type");
                break;
            case WeaponType.UNARMED:
                animationController.RunAnimation(animations.uCombatIdle, PlayerTimings.U_COMBAT_IDLE_TIMES, ref animate, true);
                break;
            default:
                break;
        }
    }
}
