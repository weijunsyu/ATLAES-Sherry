using UnityEngine;

public class PlayerInActionState : IState
{
    private PlayerStateController playerController = null;
    private StateMachine stateMachine = null;
    private MovementController movementController = null;
    private AnimationController animationController = null;

    private PlayerAnimations animations = null;
    private Coroutine animate = null;

    private double timeInSeconds = 0d;

    private double duration = 0d;

    public PlayerInActionState(PlayerStateController playerController, StateMachine stateMachine)
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
        duration = 0d;
        SetStateParams();

        timeInSeconds = 0;

        BasicMovement.StopHorizontal(movementController);
    }
    public void ExecuteLogic()
    {
        timeInSeconds += Time.deltaTime;
    }
    public void ExecutePhysics()
    {
        if (timeInSeconds > duration)
        {
            movementController.UpdateAirborne();
            if (AdvancedMovement.CanStand(movementController))
            {
                if (movementController.IsAirborne())
                {
                    stateMachine.ChangeState(playerController.fallingState); // fall
                }
                else
                {
                    IState prevState = stateMachine.prevState;
                    if (prevState == playerController.dashingState)
                    {
                        stateMachine.ChangeState(playerController.standingState); // stand
                    }
                    else
                    {
                        stateMachine.ChangeState(stateMachine.prevState); // return to prev state
                    }
                }
            }
            else // if there is no room above the player's head
            {
                stateMachine.ChangeState(playerController.crouchingState); // crouch
            }
            return;
        }
        //getting hit, and dying
    }
    public void Exit()
    {
        if (animate != null)
        {
            animationController.StopAnimation(ref animate);
        }
    }
    private void SetStateParams()
    {
        WeaponType weapon = MasterManager.playerCharacterPersistentData.GetPrimaryWeapon();
        switch (weapon)
        {
            case WeaponType.NONE:
                Debug.LogError("Weapon None check reached in PlayerLightState Script @ SetStateParams() of which should never be reached");
                break;
            case WeaponType.UNARMED:
                duration = PlayerTimings.U_STAND_LIGHT_DURATION;
                animationController.RunAnimation(animations.uStandLight, PlayerTimings.U_STAND_LIGHT_TIMES, ref animate);
                break;
            default:
                break;
        }
    }
}
