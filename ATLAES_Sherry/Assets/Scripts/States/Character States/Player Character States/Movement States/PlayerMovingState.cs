using UnityEngine;

public class PlayerMovingState : IState
{
    private PlayerStateController playerController = null;
    private StateMachine stateMachine = null;
    private MovementController movementController = null;
    private AnimationController animationController = null;

    private PlayerAnimations animations = null;
    private Coroutine animate = null;

    private AnimationController.Animation runStarup;
    private AnimationController.Animation runLoop;


    public PlayerMovingState(PlayerStateController playerController, StateMachine stateMachine)
    {
        this.playerController = playerController;
        this.stateMachine = stateMachine;

        movementController = playerController.movementController;
        animationController = playerController.animationController;
        animations = (PlayerAnimations)animationController.animationsList;
        animate = animationController.animate;

        runStarup.sprites = new Sprite[] { animations.walkForwards[1], animations.walkForwards[2], animations.run[3],
                                           animations.run[4], animations.run[5], animations.run[6], animations.run[7] };
        runStarup.timings = new float[] { 0.1f, 0.08f, 0.08f, 0.08f, 0.08f, 0.08f, 0.08f} ;
        runStarup.runNum = 1;

        runLoop.sprites = animations.run;
        runLoop.timings = PlayerTimings.RUN_TIMES;
        runLoop.runNum = 0;
    }

    public void Enter()
    {
        animationController.RunCompoundAnimation(ref animate, new AnimationController.Animation[] { runStarup, runLoop });

        movementController.SetAirborne(false);
        playerController.canAirDash = true;

    }
    public void ExecuteLogic()
    {

    }
    public void ExecutePhysics()
    {
        movementController.UpdateAirborne(); // Check if still grounded
        if (movementController.IsAirborne() == true) // if airborne
        {
            stateMachine.ChangeState(playerController.fallingState); // Go to falling state
            return;
        }

        HandleMoveInput(PlayerTimings.PLAYER_RUN_SPEED);

        if (!movementController.IsOnSlope() && AdvancedMovement.CheckFront(movementController))
        {
            stateMachine.ChangeState(playerController.standingState);
            return;
        }
        HandleInputOnce(playerController.playerInputData);
        //getting hit, and dying
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
    private void HandleMoveInput(float speed)
    {
        // Since we clean SOCD in input controller only 1 input (right/left) can be pressed at once
        if (playerController.playerInputData.pressedInputs[1] == true) // right
        {
            BasicMovement.MoveWithTurn(movementController, speed);
        }
        else if (playerController.playerInputData.pressedInputs[2] == true) // left
        {
            BasicMovement.MoveWithTurn(movementController, -speed);
        }
        else // right and left both unpressed
        {
            stateMachine.ChangeState(playerController.standingState);
        }
    }
}
