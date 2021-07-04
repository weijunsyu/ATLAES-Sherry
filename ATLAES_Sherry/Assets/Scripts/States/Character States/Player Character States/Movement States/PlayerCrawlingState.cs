using UnityEngine;

public class PlayerCrawlingState : IState
{
    private PlayerStateController playerController = null;
    private StateMachine stateMachine = null;
    private MovementController movementController = null;
    private AnimationController animationController = null;

    private PlayerAnimations animations = null;
    private Coroutine animate = null;
    private float moveSpeed = 0;

    private double timeInSeconds = 0d;

    public PlayerCrawlingState(PlayerStateController playerController, StateMachine stateMachine)
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

    }
    public void ExecuteLogic()
    {

    }
    public void ExecutePhysics()
    {
        
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
        else if (inputData.inputTokens[3]) // Crouch
        {
            inputData.EatInputToken(3);
            stateMachine.ChangeState(playerController.crouchingGuardState);
        }
    }
    private void HandleMoveInput(float speed)
    {
        if (movementController.IsFacingRight()) // facing right
        {
            if (playerController.playerInputData.pressedInputs[2] == true) // left
            {
                BasicMovement.Strafe(movementController, -speed);
            }
            else
            {
                stateMachine.ChangeState(playerController.standingGuardState);
            }
        }
        else // facing left
        {
            if (playerController.playerInputData.pressedInputs[1] == true) // right
            {
                BasicMovement.Strafe(movementController, speed);
            }
            else
            {
                stateMachine.ChangeState(playerController.standingGuardState);
            }
        }
    }
}
