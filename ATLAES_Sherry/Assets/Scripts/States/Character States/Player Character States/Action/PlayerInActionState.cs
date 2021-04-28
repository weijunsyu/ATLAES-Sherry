using UnityEngine;

public class PlayerInActionState : IState
{
    private PlayerStateController playerController = null;
    private StateMachine stateMachine = null;
    private MovementController movementController = null;
    private PlayerActionController actionController = null;
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
        actionController = playerController.actionController;
        animationController = playerController.animationController;
        animations = (PlayerAnimations)animationController.animationsList;
        animate = animationController.animate;
    }

    public void Enter()
    {
        actionController.LockBuffer();
        movementController.UpdateAirborne();
        duration = 0d;
        
        SetStateParams();
        timeInSeconds = 0d;

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
            stateMachine.ChangeState(DetermineStateEnding());
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
        actionController.ResetInputBuffer();
        actionController.UnlockBuffer();
    }
    private void SetStateParams()
    {
        WeaponType weapon = MasterManager.playerCharacterPersistentData.GetPrimaryWeapon();
        IState prevState = stateMachine.prevState; // used for evaluating charged attacks and crouched attacks

        PlayerInputController.RawInput inputType = actionController.inputBuffer.Pop().input;

        switch (weapon) // determine what sets of actions to use
        {
            case WeaponType.NONE:
                Debug.LogError("Weapon None check reached in PlayerLightState Script @ SetStateParams() of which should never be reached");
                break;
            case WeaponType.UNARMED:
                if (movementController.IsAirborne()) // action is airbourne
                {
                    switch (inputType)
                    {
                        case PlayerInputController.RawInput.LIGHT_PRESS:
                            duration = PlayerTimings.U_JUMP_LIGHT_DURATION;
                            animationController.RunAnimation(animations.uJumpLight, PlayerTimings.U_JUMP_LIGHT_TIMES, ref animate);
                            
                            break;
                        case PlayerInputController.RawInput.MEDIUM_PRESS:
                            duration = PlayerTimings.U_JUMP_MEDIUM_DURATION;
                            animationController.RunAnimation(animations.uJumpMedium, PlayerTimings.U_JUMP_MEDIUM_TIMES, ref animate);
                            
                            break;
                        case PlayerInputController.RawInput.HEAVY_PRESS:
                            duration = PlayerTimings.U_JUMP_HEAVY_DURATION;
                            animationController.RunAnimation(animations.uJumpHeavy, PlayerTimings.U_JUMP_HEAVY_TIMES, ref animate);
                            
                            break;
                        default:
                            Debug.LogError("Something other than an action was pressed to trigger actions");
                            break;
                    }
                }
                // action is crouched
                else if (prevState == playerController.crouchingState || prevState == playerController.crouchingGuardState)
                {
                    switch (inputType)
                    {
                        case PlayerInputController.RawInput.LIGHT_PRESS:
                            duration = PlayerTimings.U_CROUCH_LIGHT_DURATION;
                            animationController.RunAnimation(animations.uCrouchLight, PlayerTimings.U_CROUCH_LIGHT_TIMES, ref animate);
                            BasicMovement.StopAll(movementController);
                            break;
                        case PlayerInputController.RawInput.MEDIUM_PRESS:
                            duration = PlayerTimings.U_CROUCH_MEDIUM_DURATION;
                            animationController.RunAnimation(animations.uCrouchMedium, PlayerTimings.U_CROUCH_MEDIUM_TIMES, ref animate);
                            BasicMovement.StopAll(movementController);
                            break;
                        case PlayerInputController.RawInput.HEAVY_PRESS:
                            duration = PlayerTimings.U_CROUCH_HEAVY_DURATION;
                            animationController.RunAnimation(animations.uCrouchHeavy, PlayerTimings.U_CROUCH_HEAVY_TIMES, ref animate);
                            BasicMovement.StopAll(movementController);
                            break;
                        default:
                            Debug.LogError("Something other than an action was pressed to trigger actions");
                            break;
                    }
                }
                else // action is standing
                {
                    switch (inputType)
                    {
                        case PlayerInputController.RawInput.LIGHT_PRESS:
                            duration = PlayerTimings.U_STAND_LIGHT_DURATION;
                            animationController.RunAnimation(animations.uStandLight, PlayerTimings.U_STAND_LIGHT_TIMES, ref animate);
                            BasicMovement.StopAll(movementController);
                            break;
                        case PlayerInputController.RawInput.MEDIUM_PRESS:
                            duration = PlayerTimings.U_STAND_MEDIUM_DURATION;
                            animationController.RunAnimation(animations.uStandMedium, PlayerTimings.U_STAND_MEDIUM_TIMES, ref animate);
                            BasicMovement.StopAll(movementController);
                            break;
                        case PlayerInputController.RawInput.HEAVY_PRESS:
                            duration = PlayerTimings.U_STAND_HEAVY_DURATION;
                            animationController.RunAnimation(animations.uStandHeavy, PlayerTimings.U_STAND_HEAVY_TIMES, ref animate);
                            BasicMovement.StopAll(movementController);
                            break;
                        default:
                            Debug.LogError("Something other than an action was pressed to trigger actions");
                            break;
                    }
                }
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
                Debug.LogError("Unreachable Default case reached in PlayerLightState Script @ SetStateParams()");
                break;
        }
    }
    /*
    //iterate through the inputBuffer to check combo sequence
    int index = 1; // start at 1 because we guarantee the first input
                            while (actionController.inputBuffer.Count > 0 && index<GameConstants.INPUT_BUFFER_MAX_LENGTH)
                            {
                                PlayerInputController.RawInput input = actionController.inputBuffer.Pop().input;

                                // U_GROUND_DRAGON_PUNCH START
                                if (PlayerTimings.U_GROUND_DRAGON_PUNCH_INPUT[index] == (int) input)
                                {
                                    if (index + 1 == PlayerTimings.U_GROUND_DRAGON_PUNCH_NUM_INPUTS)
                                    {
                                        // combo is accepted
                                        duration = PlayerTimings.U_GROUND_DRAGON_PUNCH_DURATION;
                                        animationController.RunAnimation(animations.uSpGroundDragonPunch, PlayerTimings.U_GROUND_DRAGON_PUNCH_TIMES, ref animate);
                                        return;
                                    }
                                }
                                // U_GROUND_DRAGON_PUNCH END

                                index++;
                            }
    */
    /*
    private void DetermineBufferAlive()
    {
        if (actionController.inputBuffer.Count > 0)
        {
            // If the time delta is larger than the max allowed time delta for input buffer
            if ((currentTime - inputBuffer.Peek().time) > GameConstants.INPUT_BUFFER_LIFESPAN)
            {
                inputBuffer.Clear(); // Reset the stack
                timeCounter = 0; // Reset the time counter
            }
        }
    }
    */

    private IState DetermineStateEnding()
    {
        IState prevState = stateMachine.prevState;

        if (AdvancedMovement.CanStand(movementController))
        {
            if (prevState == playerController.crouchingState)
            {
                return prevState;
            }
            else if (prevState == playerController.crouchingGuardState)
            {
                return prevState;
            }
            else if (prevState == playerController.standingGuardState)
            {
                return prevState;
            }
            else if (prevState == playerController.strafingForwardsState)
            {
                return playerController.standingGuardState;
            }
            else if (prevState == playerController.strafingBackwardsState)
            {
                return playerController.standingGuardState;
            }
            else if (movementController.IsAirborne())
            {
                return playerController.fallingState;
            }
            else // default
            {
                return playerController.standingState;
            }
        }
        else // if there is no room above the player's head
        {
            return playerController.crouchingState; // crouch
        }
    }
}
