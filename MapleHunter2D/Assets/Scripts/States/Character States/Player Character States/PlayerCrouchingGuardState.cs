using UnityEngine;

public class PlayerCrouchingGuardState : IState
{
    private PlayerStateController playerController = null;
    private StateMachine stateMachine = null;
    private MovementController movementController = null;
    private AnimationController animationController = null;

    private PlayerAnimations animations = null;
    private Coroutine animate = null;

    public PlayerCrouchingGuardState(PlayerStateController playerController, StateMachine stateMachine)
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
        RunAnimation();

        BasicMovement.StopHorizontal(movementController);
        AdvancedMovement.Crouch(movementController);
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
            stateMachine.ChangeState(playerController.crouchingState);
            return;
        }
        if (PlayerInputController.pressedInputs[3] == false) // crouch release
        {
            if (AdvancedMovement.CanStand(movementController))
            {
                stateMachine.ChangeState(playerController.standingGuardState);
                return;
            }
        }
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
        }
    }
    private void RunAnimation()
    {
        if (MasterManager.playerCharacterPersistentData.GetPrimaryWeapon() == WeaponType.NONE)
        {
            animationController.RunAnimation(animations.crouch, PlayerTimings.CROUCH_TIMES, ref animate);
        }
        if (MasterManager.playerCharacterPersistentData.GetPrimaryWeapon() == WeaponType.UNARMED)
        {
            animationController.SetSprite(animations.u_crouchGuard[0]);
        }
    }
}
