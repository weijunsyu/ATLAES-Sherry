using System;
using UnityEngine;

public class PlayerStateController : AbstractStateController
{
    //Config Parameters:

    // Cached References:

    // State Parameters and Objects:

    // Player States
    // Movement
    [HideInInspector] public PlayerStandingState standingState;
    [HideInInspector] public PlayerMovingState movingState;
    [HideInInspector] public PlayerJumpingState jumpingState;
    [HideInInspector] public PlayerFallingState fallingState;
    [HideInInspector] public PlayerCrouchingState crouchingState;
    [HideInInspector] public PlayerDashingState dashingState;
    [HideInInspector] public PlayerSlidingState slidingState;
    [HideInInspector] public PlayerSlidingJumpState slidingJumpState;
    [HideInInspector] public PlayerStandingGuardState standingGuardState;
    [HideInInspector] public PlayerStrafingForwardsState strafingForwardsState;
    [HideInInspector] public PlayerStrafingBackwardsState strafingBackwardsState;
    [HideInInspector] public PlayerCrouchingGuardState crouchingGuardState;
    // Action
    [HideInInspector] public PlayerLightState lightState;
    [HideInInspector] public PlayerMediumState mediumState;
    [HideInInspector] public PlayerHeavyState heavyState;
    // Hit
    [HideInInspector] public PlayerHitHighState hitHighState;
    [HideInInspector] public PlayerHitMedState hitMedState;
    [HideInInspector] public PlayerHitLowState hitLowState;
    [HideInInspector] public PlayerHitAirState hitAirState;
    // Death
    [HideInInspector] public PlayerDeathStandingState deathStandingState;
    [HideInInspector] public PlayerDeathCrouchingState deathCrouchingState;
    [HideInInspector] public PlayerDeathAirState deathAirState;

    // Player Flags:
    //[HideInInspector] public bool canAirJump = true; // enables double jumping
    [HideInInspector] public bool canAirDash = true; // enables air dashing
    [HideInInspector] public double jumpBufferTimer = 0d;
    [HideInInspector] public bool jumpInputBuffer = false; // jump input buffer was initiated

    // Unity Events:
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();
        jumpBufferTimer = 0d;
        jumpInputBuffer = false;

        //MasterManager.playerCharacterPersistentData.SetPrimaryWeapon(WeaponType.UNARMED, true);
    }
    protected override void Update()
    {
        //Debug.Log(animationController.GetSprite());
        //Debug.Log(movementController.transform.position.y - movementController.boxCollider.bounds.center.y);
        
        base.Update();
        jumpBufferTimer += Time.deltaTime; // increment timer
        if (jumpBufferTimer > GameConstants.JUMP_BUFFER)
        {
            jumpInputBuffer = false; // if buffer timer passed, disable jump
        }
        //Debug.Log(stateMachine.state);
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    // Class Functions:
    protected override void InitializeStates()
    {
        // Create States
        standingState = new PlayerStandingState(this, stateMachine);
        movingState = new PlayerMovingState(this, stateMachine);
        jumpingState = new PlayerJumpingState(this, stateMachine);
        fallingState = new PlayerFallingState(this, stateMachine);
        crouchingState = new PlayerCrouchingState(this, stateMachine);
        dashingState = new PlayerDashingState(this, stateMachine);
        slidingState = new PlayerSlidingState(this, stateMachine);
        slidingJumpState = new PlayerSlidingJumpState(this, stateMachine);
        standingGuardState = new PlayerStandingGuardState(this, stateMachine);
        strafingForwardsState = new PlayerStrafingForwardsState(this, stateMachine);
        strafingBackwardsState = new PlayerStrafingBackwardsState(this, stateMachine);
        crouchingGuardState = new PlayerCrouchingGuardState(this, stateMachine);

        //lightState = new PlayerLightState(this, stateMachine);
        //mediumState = new PlayerMediumState(this, stateMachine);
        //heavyState = new PlayerHeavyState(this, stateMachine);

        //hitHighState = new PlayerHitHighState(this, stateMachine);
        //hitMedState = new PlayerHitMedState(this, stateMachine);
        //hitLowState = new PlayerHitLowState(this, stateMachine);
        //hitAirState = new PlayerHitAirState(this, stateMachine);

        //deathStandingState = new PlayerDeathStandingState(this, stateMachine);
        //deathCrouchingState = new PlayerDeathCrouchingState(this, stateMachine);
        //deathAirState = new PlayerDeathAirState(this, stateMachine);

        // Initialize the starting state
        startState = standingState;
    }

    public void HandleMoveInput(float speed)
    {
        // Since we clean SOCD in input controller only 1 input (right/left) can be pressed at once
        if (PlayerInputController.pressedInputs[1] == true) // right
        {
            BasicMovement.MoveWithTurn(movementController, speed);
        }
        else if (PlayerInputController.pressedInputs[2] == true) // left
        {
            BasicMovement.MoveWithTurn(movementController, -speed);
        }
        else // right and left both unpressed
        {
            BasicMovement.StopHorizontal(movementController);
        }
    }
    // return true if sliding and false otherwise
    public bool HandleSlideCheck()
    {
        bool hitTop = false;
        bool hitBottom = false;
        AdvancedMovement.checkFront(movementController, out hitTop, out hitBottom);
        if (hitBottom) // if wall in front of player
        {
            // If facing right and NOT pressing right button
            if (movementController.IsFacingRight() && !PlayerInputController.pressedInputs[1])
            {
                return false;
            }
            // Else if facing left and NOT pressing left button
            else if (!movementController.IsFacingRight() && !PlayerInputController.pressedInputs[2])
            {
                return false;
            }
            return true;
        }
        else //Nothing in front
        {
            return false;
        }
    }
}
