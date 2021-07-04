using UnityEngine;

public class PlayerSprintingState : IState
{
    private PlayerStateController playerController = null;
    private StateMachine stateMachine = null;
    private MovementController movementController = null;
    private AnimationController animationController = null;

    private PlayerAnimations animations = null;
    private Coroutine animate = null;

    private double timeInSeconds = 0d;


    public PlayerSprintingState(PlayerStateController playerController, StateMachine stateMachine)
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
        timeInSeconds = 0;

        animationController.RunAnimation(animations.sprint, PlayerTimings.SPRINT_TIMES, ref animate, true);
        movementController.SetAirborne(false);
        playerController.canAirDash = true;
    }
    public void ExecuteLogic()
    {
        timeInSeconds += Time.deltaTime;
    }
    public void ExecutePhysics()
    {
        //handle falling, getting hit, and dying
        movementController.UpdateAirborne(); // Check if still grounded
        if (movementController.IsAirborne() == true) // if airborne
        {
            stateMachine.ChangeState(playerController.fallingState); // Go to falling state
            return;
        }
        HandleMovement(PlayerTimings.PLAYER_SPRINT_SPEED);
        if (!movementController.IsOnSlope() && AdvancedMovement.CheckFront(movementController))
        {
            stateMachine.ChangeState(playerController.standingState);
            return;
        }

        HandleInputOnce(playerController.playerInputData);
    }
    public void Exit()
    {
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

    private void HandleMovement(float speed)
    {
        if (!playerController.playerInputData.pressedInputs[7]) // If player let go of dash button
        {
            stateMachine.ChangeState(playerController.sprintRecoveryState);
        }
        else
        {
            BasicMovement.MoveInDirection(movementController, speed);
        }
    }
}
