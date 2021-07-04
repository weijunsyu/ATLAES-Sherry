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
        movementController.SetPhysicsMaterialSlope(movementController.IsOnSlope());
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
        HandleInputOnce(playerController.playerInputData);
        TurnAndMove();
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
            stateMachine.ChangeState(playerController.standingGuardState);
        }
        else if (inputData.inputTokens[6]) // Jump
        {
            inputData.EatInputToken(6);
            stateMachine.ChangeState(playerController.jumpingState);
        }
        else if (inputData.inputTokens[3]) // Crouch
        {
            inputData.EatInputToken(3);
            stateMachine.ChangeState(playerController.crouchingState);
        }
        else if (inputData.inputTokens[7]) // Dash
        {
            inputData.EatInputToken(7);
            stateMachine.ChangeState(playerController.dashingState);
        }
    }
    private void TurnAndMove()
    {
        bool onSlope = movementController.UpdateIsOnSlope();
        if (playerController.playerInputData.pressedInputs[1]) // right
        {
            movementController.FaceRight();
            if (onSlope || !AdvancedMovement.CheckFront(movementController))
            {
                stateMachine.ChangeState(playerController.movingState);
                return;
            }
        }
        else if (playerController.playerInputData.pressedInputs[2]) // left
        {
            movementController.FaceLeft();
            if (onSlope || !AdvancedMovement.CheckFront(movementController))
            {
                stateMachine.ChangeState(playerController.movingState);
                return;
            }
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
