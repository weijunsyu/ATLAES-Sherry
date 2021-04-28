using UnityEngine;

public class PlayerFallingState : IState
{
    private PlayerStateController playerController = null;
    private StateMachine stateMachine = null;
    private MovementController movementController = null;
    private AnimationController animationController = null;

    private PlayerAnimations animations = null;
    private Coroutine animate = null;

    private double timeInSeconds = 0d;

    public PlayerFallingState(PlayerStateController playerController, StateMachine stateMachine)
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
        animationController.RunAnimation(animations.fall, PlayerTimings.FALL_TIMES, ref animate, true);

        timeInSeconds = 0d;
        movementController.SetAirborne(true);

        // Enable player controller
        PlayerInputController.OnInputEvent += HandleInput;
    }
    public void ExecuteLogic()
    {
        timeInSeconds += Time.deltaTime;
    }
    public void ExecutePhysics()
    {
        //handle falling, getting hit, and dying
        movementController.UpdateAirborne(); // Check if still airborne
        if (movementController.IsAirborne() == false) // if grounded
        {
            stateMachine.ChangeState(playerController.standingState); // Go to standing state
            return;
        }
        playerController.HandleMoveInput(PlayerTimings.PLAYER_AIR_MOVE_SPEED);
        if (playerController.HandleSlideCheck())
        {
            stateMachine.ChangeState(playerController.slidingState);
            return;
        }
    }
    public void Exit()
    {
        // Disable player controller
        PlayerInputController.OnInputEvent -= HandleInput;

        if (animate != null)
        {
            animationController.StopAnimation(ref animate);
        }
    }
    private void HandleInput(object sender, InputEventArgs inputEvent)
    {
        switch (inputEvent.input)
        {
            case PlayerInputController.RawInput.LIGHT_PRESS: // Light
                if (MasterManager.playerCharacterPersistentData.GetPrimaryWeapon() != WeaponType.NONE)
                {
                    stateMachine.ChangeState(playerController.inActionState);
                }
                break;
            case PlayerInputController.RawInput.MEDIUM_PRESS: // Medium
                if (MasterManager.playerCharacterPersistentData.GetPrimaryWeapon() != WeaponType.NONE)
                {
                    stateMachine.ChangeState(playerController.inActionState);
                }
                break;
            case PlayerInputController.RawInput.HEAVY_PRESS: // Heavy
                if (MasterManager.playerCharacterPersistentData.GetPrimaryWeapon() != WeaponType.NONE)
                {
                    stateMachine.ChangeState(playerController.inActionState);
                }
                break;
            case PlayerInputController.RawInput.DASH_PRESS: // Dash
                if (playerController.canAirDash)
                {
                    playerController.canAirDash = false;
                    stateMachine.ChangeState(playerController.dashingState);
                }
                break;
            case PlayerInputController.RawInput.JUMP_PRESS: // Air jump
                if (stateMachine.prevState == playerController.movingState)
                {
                    if (timeInSeconds < GameConstants.COYOTE_JUMP_DELAY)
                    {
                        stateMachine.ChangeState(playerController.jumpingState);
                    }
                }
                else // Previous state was NOT moving state
                {
                    playerController.jumpBufferTimer = 0d; // Reset the timer
                    playerController.jumpInputBuffer = true; // Buffer the jump command
                }
                break;
        }
    }
}
