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

    //List of combo inputs


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
        movementController.UpdateAirborne();
        duration = 0d;
        SetStateParams();

        timeInSeconds = 0;

        BasicMovement.StopAll(movementController);
        movementController.NegateGravity();
        movementController.ImpartForce(new Vector2(400f, 200f));
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
                    stateMachine.ChangeState(playerController.standingState); // stand
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

        playerController.isInCombat = true;
        playerController.combatTimer = 0;
    }
    private void SetStateParams()
    {
        WeaponType weapon = MasterManager.playerCharacterPersistentData.GetPrimaryWeapon();
        IState prevState = stateMachine.prevState; // used for evaluating charged attacks and crouched attacks
        (PlayerActionController.ComboInput inputType, double time) = PlayerActionController.inputBuffer.Pop();

        if (movementController.IsAirborne()) // if action was started in the air
        {
            switch (inputType)
            {
                case PlayerActionController.ComboInput.LIGHT_PRESS:


                    //determine action:
                    foreach (PlayerActionController.PlayerAction action in PlayerActionController.uLightAirSpecials)
                    {
                        for (int i = 0; i < action.inputSequence.Length; i++)
                        {
                            if (action.inputSequence[i] != (int)inputType)
                            {

                            }
                        }
                    }

                    break;
                case PlayerActionController.ComboInput.MEDIUM_PRESS:
                    
                    break;
                case PlayerActionController.ComboInput.HEAVY_PRESS:

                    break;
            }
        }
        else // if action was started on the ground
        {
            switch (inputType)
            {
                case PlayerActionController.ComboInput.LIGHT_PRESS:
                    
                    break;
                case PlayerActionController.ComboInput.MEDIUM_PRESS:

                    break;
                case PlayerActionController.ComboInput.HEAVY_PRESS:

                    break;
            }
        }

        
        
        
        switch (weapon)
        {
            case WeaponType.NONE:
                Debug.LogError("Weapon None check reached in PlayerLightState Script @ SetStateParams() of which should never be reached");
                break;
            case WeaponType.UNARMED:
                duration = PlayerTimings.U_ROLLING_AXE_KICK_DURATION;
                animationController.RunAnimation(animations.uSpRollingAxeKick, PlayerTimings.U_ROLLING_AXE_KICK_TIMES, ref animate);
                break;
            default:
                break;
        }
    }

    private void DetermineAction(WeaponType weapon)
    {

    }
}
