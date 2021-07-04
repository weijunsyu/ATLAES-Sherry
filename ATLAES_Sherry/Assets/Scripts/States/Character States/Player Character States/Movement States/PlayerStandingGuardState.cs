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
    private bool isArmed = false;

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
        isArmed = false;
        if (MasterManager.playerData.GetPrimaryWeapon() != WeaponType.NONE)
        {
            isArmed = true;
        }
        RunAnimation();
        movementController.SetPhysicsMaterialSlope(movementController.IsOnSlope());
        BasicMovement.StopHorizontal(movementController, true);
        AdvancedMovement.Stand(movementController);
        movementController.SetAirborne(false);
        playerController.canAirDash = true;
        timeInSeconds = 0;
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
        HandleInput(isArmed, playerController.playerInputData);
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
    private void HandleInput(bool isArmed, PlayerInputData inputData)
    {
        if (!inputData.pressedInputs[5]) // let go of guard
        {
            stateMachine.ChangeState(playerController.standingState);
        }

        if (isArmed)
        {
            if (playerController.playerInputData.pressedInputs[1]) // right
            {
                movementController.FaceRight();
            }
            else if (playerController.playerInputData.pressedInputs[2]) // left
            {
                movementController.FaceLeft();
            }
        }
        else // Not armed
        {
            bool onSlope = movementController.IsOnSlope();
            if (playerController.playerInputData.pressedInputs[1]) // right
            {
                movementController.FaceRight();
                if (onSlope || !AdvancedMovement.CheckFront(movementController))
                {
                    stateMachine.ChangeState(playerController.walkingState);
                    return;
                }
            }
            else if (playerController.playerInputData.pressedInputs[2]) // left
            {
                movementController.FaceLeft();
                if (onSlope || !AdvancedMovement.CheckFront(movementController))
                {
                    stateMachine.ChangeState(playerController.walkingState);
                    return;
                }
            }
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
        else if (inputData.inputTokens[3]) // Crouch
        {
            inputData.EatInputToken(3);
            stateMachine.ChangeState(playerController.crouchingGuardState);
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
            case WeaponType.MAGIC:

                break;
            case WeaponType.GUN:

                break;
            case WeaponType.KATANA:

                break;
            case WeaponType.SWORD:

                break;
            case WeaponType.GREATSWORD:

                break;
            case WeaponType.DAGGER:

                break;
            case WeaponType.SPEAR:

                break;
            case WeaponType.NAGINATA:

                break;
            case WeaponType.CUBE:

                break;
            default:
                animationController.RunAnimation(animations.idle, PlayerTimings.IDLE_TIMES, ref animate, true);
                break;
        }
    }
}
