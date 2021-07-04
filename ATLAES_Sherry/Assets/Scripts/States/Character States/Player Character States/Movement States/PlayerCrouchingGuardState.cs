using UnityEngine;

public class PlayerCrouchingGuardState : IState
{
    private PlayerStateController playerController = null;
    private StateMachine stateMachine = null;
    private MovementController movementController = null;
    private AnimationController animationController = null;

    private PlayerAnimations animations = null;
    private Coroutine animate = null;

    private double timeInSeconds = 0d;

    public PlayerCrouchingGuardState(PlayerStateController playerController, StateMachine stateMachine)
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
        movementController.SetPhysicsMaterialSlope(movementController.IsOnSlope());
        BasicMovement.StopHorizontal(movementController, true);
        AdvancedMovement.Crouch(movementController);
        playerController.canAirDash = true;
        timeInSeconds = 0d;
    }
    public void ExecuteLogic()
    {
        timeInSeconds += Time.deltaTime;
        if (stateMachine.prevState == playerController.crouchingState || timeInSeconds >= GameConstants.PURE_CHARGE_UP_TIME)
        {
            playerController.isChargedCrouching = true;
            playerController.crouchingChargeTimer = 0d;
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
        if (playerController.playerInputData.pressedInputs[5] == false) // guard release
        {
            stateMachine.ChangeState(playerController.crouchingState);
            return;
        }
        if (playerController.playerInputData.pressedInputs[3] == false) // crouch release
        {
            if (AdvancedMovement.CanStand(movementController))
            {
                stateMachine.ChangeState(playerController.standingGuardState);
                return;
            }
        }
        HandleMoveInput(playerController.playerInputData);
        HandleInputOnce(playerController.playerInputData);
        //getting hit, and dying
    }
    public void Exit()
    {
        if (animate != null)
        {
            animationController.StopAnimation(ref animate);
        }
        movementController.SetPhysicsMaterialSlope(false);
    }
    private void HandleMoveInput(PlayerInputData inputData)
    {
        if (inputData.pressedInputs[1]) // right
        {
            movementController.FaceRight();
        }
        else if (inputData.pressedInputs[2]) // left
        {
            movementController.FaceLeft();
        }
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
    }
    private void RunAnimation()
    {
        if (MasterManager.playerData.GetPrimaryWeapon() == WeaponType.NONE)
        {
            animationController.SetSprite(animations.crouch[0]);
        }
        if (MasterManager.playerData.GetPrimaryWeapon() == WeaponType.UNARMED)
        {
            animationController.SetSprite(animations.uCrouchGuard[0]);
        }
        else
        {
            animationController.SetSprite(animations.crouch[0]);
        }
    }
}
