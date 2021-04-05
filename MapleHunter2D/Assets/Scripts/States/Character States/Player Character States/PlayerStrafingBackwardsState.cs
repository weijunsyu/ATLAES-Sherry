using UnityEngine;

public class PlayerStrafingBackwardsState : IState
{
    private PlayerStateController playerController = null;
    private StateMachine stateMachine = null;
    private MovementController movementController = null;
    private AnimationController animationController = null;

    private PlayerAnimations animations = null;
    private Coroutine animate = null;
    private float moveSpeed = 0;

    public PlayerStrafingBackwardsState(PlayerStateController playerController, StateMachine stateMachine)
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
        SetStateParams();

        AdvancedMovement.Stand(movementController);
        movementController.SetAirborne(false);
        playerController.canAirDash = true;

        // Enable player controller
        PlayerInputController.OnInputEvent += HandleInput;
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
        if (PlayerInputController.pressedInputs[5] == false) // guard release
        {
            stateMachine.ChangeState(playerController.standingState);
            return;
        }
        HandleMoveInput(moveSpeed);
        //getting hit, and dying
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
                //stateMachine.ChangeState(playerController.lightState);
                break;
            case PlayerInputController.RawInput.MEDIUM_PRESS: // Medium
                //stateMachine.ChangeState(playerController.mediumState);
                break;
            case PlayerInputController.RawInput.HEAVY_PRESS: // Heavy
                //stateMachine.ChangeState(playerController.heavyState);
                break;
            case PlayerInputController.RawInput.CROUCH_PRESS: // Crouch
                stateMachine.ChangeState(playerController.crouchingGuardState);
                break;
        }
    }
    private void HandleMoveInput(float speed)
    {
        if (movementController.IsFacingRight()) // facing right
        {
            if (PlayerInputController.pressedInputs[2] == true) // left
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
            if (PlayerInputController.pressedInputs[1] == true) // right
            {
                BasicMovement.Strafe(movementController, speed);
            }
            else
            {
                stateMachine.ChangeState(playerController.standingGuardState);
            }
        }
    }

    private void SetStateParams()
    {
        if (MasterManager.playerCharacterPersistentData.GetPrimaryWeapon() == WeaponType.NONE)
        {
            moveSpeed = PlayerTimings.PLAYER_WALK_SPEED;
            animationController.RunAnimation(animations.walkForwards, PlayerTimings.WALK_TIMES, ref animate, true);
        }
        if (MasterManager.playerCharacterPersistentData.GetPrimaryWeapon() == WeaponType.UNARMED)
        {
            moveSpeed = PlayerTimings.U_STRAFE_SPEED;
            animationController.RunAnimation(animations.u_strafe, PlayerTimings.U_STRAFE_TIMES, ref animate, true);
        }
    }
}
