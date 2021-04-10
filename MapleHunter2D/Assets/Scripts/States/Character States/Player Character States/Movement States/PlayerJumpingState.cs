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
        
        BasicMovement.Jump(movementController, PlayerTimings.PLAYER_JUMP_VELOCITY);
        //BasicMovement.StopHorizontal(movementController);
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
        playerController.HandleMoveInput(PlayerTimings.PLAYER_AIR_MOVE_SPEED);
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
            case PlayerInputController.RawInput.DASH_PRESS: // Dash
                if (playerController.canAirDash)
                {
                    playerController.canAirDash = false;
                    stateMachine.ChangeState(playerController.dashingState);
                }
                break;
        }
    }
}
