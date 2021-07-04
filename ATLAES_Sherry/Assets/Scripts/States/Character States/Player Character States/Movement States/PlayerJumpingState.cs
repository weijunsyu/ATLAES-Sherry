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

        movementController.SetAirborne(true);
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
        HandleInputOnce(playerController.playerInputData);
    }
    public void Exit()
    {
        movementController.SetCollider(movementController.standColliderSize, movementController.standColliderOffset);
    }
    private void HandleInputOnce(PlayerInputData inputData)
    {
        if (inputData.inputTokens[8]) // Light
        {
            inputData.EatInputToken(8);
            if (MasterManager.playerData.GetPrimaryWeapon() != WeaponType.NONE)
            {
                stateMachine.ChangeState(playerController.inActionState);
            }
        }
        else if (inputData.inputTokens[9]) // Medium
        {
            inputData.EatInputToken(9);
            if (MasterManager.playerData.GetPrimaryWeapon() != WeaponType.NONE)
            {
                stateMachine.ChangeState(playerController.inActionState);
            }
        }
        else if (inputData.inputTokens[10]) // Heavy
        {
            inputData.EatInputToken(10);
            if (MasterManager.playerData.GetPrimaryWeapon() != WeaponType.NONE)
            {
                stateMachine.ChangeState(playerController.inActionState);
            }
        }
        else if (inputData.inputTokens[7]) // Dash
        {
            inputData.EatInputToken(7);
            if (playerController.canAirDash)
            {
                playerController.canAirDash = false;
                stateMachine.ChangeState(playerController.dashingState);
            }
        }
        else if (inputData.inputTokens[6]) // Jump
        {
            inputData.EatInputToken(6);
            if (AdvancedMovement.CheckFront(movementController))
            {
                // If near wall perform a wall jump (slide jump)
                stateMachine.ChangeState(playerController.slidingJumpState);
            }
        }
    }
}
