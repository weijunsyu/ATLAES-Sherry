using UnityEngine;

public class PlayerCrouchingState : IState
{

    private PlayerStateController playerController = null;
    private StateMachine stateMachine = null;
    private MovementController movementController = null;
    private AnimationController animationController = null;

    private PlayerAnimations animations = null;
    private Coroutine animate = null;

    private double timeInSeconds = 0d;

    public PlayerCrouchingState(PlayerStateController playerController, StateMachine stateMachine)
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
        animationController.SetSprite(animations.crouch[0]);
        if (movementController.IsOnSlope())
        {
            movementController.boxCollider.sharedMaterial = movementController.slopeMaterial;
        }
        BasicMovement.StopHorizontal(movementController, true);
        AdvancedMovement.Crouch(movementController);
        timeInSeconds = 0d;

        // Enable player controller
        PlayerInputController.OnInputEvent += HandleInput;
    }
    public void ExecuteLogic()
    {
        timeInSeconds += Time.deltaTime;
        if (stateMachine.prevState == playerController.crouchingGuardState || timeInSeconds >= GameConstants.PURE_CHARGE_UP_TIME)
        {
            playerController.isChargedCrouching = true;
            playerController.crouchingChargeTimer = 0d;
        }

        playerController.flashCooldownTimer = 0d;
    }
    public void ExecutePhysics()
    {
        movementController.UpdateAirborne(); // Check if still grounded
        if (PlayerInputController.pressedInputs[1] == true) // Turn right
        {
            movementController.FaceRight();
        }
        if (PlayerInputController.pressedInputs[2] == true) // Turn left
        {
            movementController.FaceLeft();
        }
        if (PlayerInputController.pressedInputs[3] == false) // crouch release
        {
            if (AdvancedMovement.CanStand(movementController))
            {
                stateMachine.ChangeState(playerController.standingState);
                return;
            }
        }
        if (movementController.IsAirborne() == true) // if airborne
        {
            if (AdvancedMovement.CanStand(movementController))
            {
                stateMachine.ChangeState(playerController.fallingState); // Go to falling state
                return;
            }
        }
        else
        {
            playerController.canAirDash = true;
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
                stateMachine.ChangeState(playerController.crouchingGuardState);
                break;
            case PlayerInputController.RawInput.DASH_PRESS: // Dash
                stateMachine.ChangeState(playerController.dashingState);
                break;
            case PlayerInputController.RawInput.JUMP_PRESS: // Jump
                if (playerController.isFlashing) // Only allow jumping in flashing state
                {
                    stateMachine.ChangeState(playerController.jumpingState);
                }
                break;
        }
    }
}
