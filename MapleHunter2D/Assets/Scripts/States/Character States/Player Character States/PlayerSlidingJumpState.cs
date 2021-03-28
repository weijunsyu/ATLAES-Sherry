using UnityEngine;

public class PlayerSlidingJumpState : IState
{
    private PlayerStateController playerController = null;
    private StateMachine stateMachine = null;
    private MovementController movementController = null;
    private AnimationController animationController = null;

    private double timerInSeconds = 0d;

    public PlayerSlidingJumpState(PlayerStateController playerController, StateMachine stateMachine)
    {
        this.playerController = playerController;
        this.stateMachine = stateMachine;

        movementController = playerController.movementController;
        animationController = playerController.animationController;
    }

    public void Enter()
    {
        timerInSeconds = 0;
        BasicMovement.StopHorizontal(movementController); if (movementController.IsFacingRight())
        {
            //jump left
            BasicMovement.MoveWithTurn(movementController, -5f);
        }
        else
        {
            //jump right
            BasicMovement.MoveWithTurn(movementController, 5f);
        }
        BasicMovement.Jump(movementController, 9f);
        movementController.SetAirborne(true);
    }
    public void ExecuteLogic()
    {
        timerInSeconds += Time.deltaTime;
    }
    public void ExecutePhysics()
    {
        // If falling or finished jump
        if (movementController.GetVelocity().y <= 0 || timerInSeconds > 0.1d)
        {
            stateMachine.ChangeState(playerController.fallingState);
        }
    }
    public void Exit()
    {

    }
}
