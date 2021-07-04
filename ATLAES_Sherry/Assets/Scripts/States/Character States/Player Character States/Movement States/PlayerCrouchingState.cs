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
        movementController.SetPhysicsMaterialSlope(movementController.IsOnSlope());
        BasicMovement.StopHorizontal(movementController, true);
        AdvancedMovement.Crouch(movementController);
        timeInSeconds = 0d;
    }
    public void ExecuteLogic()
    {
        timeInSeconds += Time.deltaTime;
        if (stateMachine.prevState == playerController.crouchingGuardState || timeInSeconds >= GameConstants.PURE_CHARGE_UP_TIME)
        {
            playerController.isChargedCrouching = true;
            playerController.crouchingChargeTimer = 0d;
        }
    }
    public void ExecutePhysics()
    {
        movementController.UpdateAirborne(); // Check if still grounded
        if (playerController.playerInputData.pressedInputs[1] == true) // Turn right
        {
            movementController.FaceRight();
        }
        if (playerController.playerInputData.pressedInputs[2] == true) // Turn left
        {
            movementController.FaceLeft();
        }
        if (playerController.playerInputData.pressedInputs[3] == false) // crouch release
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
        HandleInputOnce(playerController.playerInputData);
    }
    public void Exit()
    { 
        if (animate != null)
        {
            animationController.StopAnimation(ref animate);
        }
        movementController.SetPhysicsMaterialSlope(false);
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
        else if (inputData.inputTokens[5]) // Guard
        {
            inputData.EatInputToken(5);
            stateMachine.ChangeState(playerController.crouchingGuardState);
        }
        else if (inputData.inputTokens[7]) // Dash
        {
            inputData.EatInputToken(7);
            if (!movementController.UpdateAirborne())
            {
                stateMachine.ChangeState(playerController.dashingState);
            }
        }
        else if (inputData.inputTokens[6]) // Jump
        {
            inputData.EatInputToken(6);
        }
    }
}
