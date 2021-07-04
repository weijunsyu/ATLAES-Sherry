using UnityEngine;

public class PlayerDashingState : IState
{
    private PlayerStateController playerController = null;
    private StateMachine stateMachine = null;
    private MovementController movementController = null;
    private AnimationController animationController = null;

    private PlayerAnimations animations = null;
    private Coroutine animate = null;

    private double timeInSeconds = 0d;
    private bool canSprint = true;

    public PlayerDashingState(PlayerStateController playerController, StateMachine stateMachine)
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
        canSprint = true;
        playerController.canAirDash = false;

        timeInSeconds = 0;
        AdvancedMovement.Crouch(movementController);
        
        animationController.RunAnimation(animations.dash, PlayerTimings.DASH_TIMES, ref animate, false);
        SpecialMovement.DashMove(movementController, PlayerTimings.PLAYER_DASH_SPEED);
    }
    public void ExecuteLogic()
    {
        UpdateSprintState();
        timeInSeconds += Time.deltaTime;
    }
    public void ExecutePhysics()
    {
        //handle falling, getting hit, and dying
        BasicMovement.StopVertical(movementController);
        movementController.UpdateAirborne(); // update airborne

        if (timeInSeconds >= PlayerTimings.PLAYER_DASH_EXECUTE) // If dash is over
        {
            HandleDashStop();
        }
        else
        {
            HandleInputOnce(playerController.playerInputData);
        }
    }
    public void Exit()
    {
        BasicMovement.StopHorizontal(movementController);
        AdvancedMovement.Stand(movementController);

        if (animate != null)
        {
            animationController.StopAnimation(ref animate);
        }
    }
    private void HandleInputOnce(PlayerInputData inputData)
    {
        if (inputData.inputTokens[8]) // Light
        {
            inputData.EatInputToken(8);
        }
        else if (inputData.inputTokens[9]) // Medium
        {
            inputData.EatInputToken(9);
        }
        else if (inputData.inputTokens[10]) // Heavy
        {
            inputData.EatInputToken(10);
            if (MasterManager.playerData.GetPrimaryWeapon() == WeaponType.UNARMED)
            {
                stateMachine.ChangeState(playerController.inActionState);
            }
        }
        else if (inputData.inputTokens[6]) // Jump
        {
            inputData.EatInputToken(6);
            if (AdvancedMovement.CanStand(movementController)) // If can stand
            {
                IState prevState = stateMachine.prevState;
                if (prevState == playerController.crouchingState)
                {
                    // If prev state was crouching, skip airborne check
                    stateMachine.ChangeState(playerController.jumpingState);
                }
                else if (!movementController.IsAirborne())
                {
                    stateMachine.ChangeState(playerController.jumpingState);
                }
            }
        }
        else if (inputData.inputTokens[3]) // Crouch
        {
            inputData.EatInputToken(3);
            if (!movementController.IsAirborne())
            {
                stateMachine.ChangeState(playerController.crouchingState);
            }
            else
            {
                stateMachine.ChangeState(playerController.fallingState);
            }
        }
    }

    private void HandleDashStop()
    {
        playerController.playerInputData.EatInputToken(7); // remove dash input token if present
        if (movementController.IsAirborne()) // if in the air
        {
            if (AdvancedMovement.CanStand(movementController))
            {
                stateMachine.ChangeState(playerController.fallingState); // fall
            }
            else
            {
                stateMachine.ChangeState(playerController.crouchingState); // crouch
            }
        }
        else if (AdvancedMovement.CanStand(movementController))// else if on the ground and can stand
        {
            BasicMovement.StopHorizontal(movementController);
            if (canSprint) // If player can sprint
            {
                stateMachine.ChangeState(playerController.sprintingState); // sprint
            }
            else if (timeInSeconds >= PlayerTimings.PLAYER_DASH_TOTAL) // if recovery is over
            {
                if (playerController.playerInputData.pressedInputs[3]) // if holding down (crouch)
                {
                    stateMachine.ChangeState(playerController.crouchingState); // crouch
                }
                else // if not holding down
                {
                    stateMachine.ChangeState(playerController.standingState); // stand
                }
            }
        }
        else
        {
            stateMachine.ChangeState(playerController.crouchingState); // crouch
        }
        return;
    }

    private void UpdateSprintState()
    {
        if (!playerController.playerInputData.pressedInputs[7])
        {
            canSprint = false;
        }
    }
}
