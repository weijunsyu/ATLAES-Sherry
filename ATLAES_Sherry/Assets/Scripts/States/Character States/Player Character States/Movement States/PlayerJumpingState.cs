using UnityEngine;

public class PlayerJumpingState : IState
{
    private PlayerStateController playerController = null;
    private StateMachine stateMachine = null;
    private MovementController movementController = null;
    private AnimationController animationController = null;

    private PlayerAnimations animations = null;

    public PlayerJumpingState(PlayerStateController playerController, StateMachine stateMachine)
    {
        this.playerController = playerController;
        this.stateMachine = stateMachine;

        movementController = playerController.movementController;
        animationController = playerController.animationController;
        animations = (PlayerAnimations)animationController.animationsList;

    }

    public void Enter()
    {
        animationController.SetSprite(animations.jump[0]);
        
        if (playerController.isFlashing && stateMachine.prevState == playerController.crouchingState)
        {
            // If was crouching and flashing, then do flash vertical jump
            BasicMovement.Jump(movementController, PlayerTimings.PLAYER_FLASH_VERTICAL_JUMP_VELOCITY);
        }
        else
        {
            BasicMovement.Jump(movementController, PlayerTimings.PLAYER_JUMP_VELOCITY);
            //Debug.Log("jumping");
        }
        
        movementController.SetAirborne(true);

        // Enable player controller
        PlayerInputController.OnInputEvent += HandleInput;
    }
    public void ExecuteLogic()
    {
        if (movementController.GetVelocity().y <= 4.5f) // If half speed of init jump
        {
            animationController.SetSprite(animations.jump[1]);
            movementController.SetCollider(movementController.jumpApexColliderSize, movementController.jumpApexColliderOffset);
        }
    }
    public void ExecutePhysics()
    {
        //handle falling, getting hit, and dying
        if (movementController.GetVelocity().y <= 0) // If falling
        {
            stateMachine.ChangeState(playerController.fallingState);
            return;
        }

        playerController.HandleAirborneMoveInput(PlayerTimings.PLAYER_AIR_MOVE_SPEED);

        if (playerController.HandleSlideCheck())
        {
            stateMachine.ChangeState(playerController.slidingState);
            return;
        }
    }
    public void Exit()
    {
        // Disable player controller
        PlayerInputController.OnInputEvent -= HandleInput;

        movementController.SetCollider(movementController.standColliderSize, movementController.standColliderOffset);
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
            case PlayerInputController.RawInput.DASH_PRESS: // Dash
                if (playerController.canAirDash)
                {
                    playerController.canAirDash = false;
                    stateMachine.ChangeState(playerController.dashingState);
                }
                break;
            case PlayerInputController.RawInput.JUMP_PRESS: // Air jump
                if (AdvancedMovement.CheckFront(movementController))
                {
                    // If near wall perform a wall jump (slide jump)
                    stateMachine.ChangeState(playerController.slidingJumpState);
                }
                break;
        }
    }
}
