using UnityEngine;

[RequireComponent(typeof(PlayerWeapons))]
public class PlayerStateController : AbstractStateController
{
    //Config Parameters:

    // Cached References:
    [HideInInspector] public PlayerWeapons weapons;

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
    [HideInInspector] public PlayerInActionState inActionState;
    // Reaction
    [HideInInspector] public PlayerHitHighState hitHighState;
    [HideInInspector] public PlayerHitMedState hitMedState;
    [HideInInspector] public PlayerHitLowState hitLowState;
    [HideInInspector] public PlayerHitAirState hitAirState;
    [HideInInspector] public PlayerDeathStandingState deathStandingState;
    [HideInInspector] public PlayerDeathCrouchingState deathCrouchingState;
    [HideInInspector] public PlayerDeathAirState deathAirState;

    // Action
    [HideInInspector] public PlayerNoActionState noActionState;

    // Player Flags:
    [HideInInspector] public bool canAirDash = true; // enables air dashing
    [HideInInspector] public double jumpBufferTimer = 0d;
    [HideInInspector] public bool jumpInputBuffer = false; // jump input buffer was initiated

    // Unity Events:
    protected override void Awake()
    {
        base.Awake();
        weapons = GetComponent<PlayerWeapons>();
    }
    protected override void Start()
    {
        base.Start();
        jumpBufferTimer = 0d;
        jumpInputBuffer = false;
        weapons.SetPrimaryWeaponSprite(MasterManager.playerCharacterPersistentData.GetPrimaryWeapon());
        weapons.SetSecondaryWeaponSprite(MasterManager.playerCharacterPersistentData.GetSecondaryWeapon());
    }
    private void OnEnable()
    {
        // Enable player controller
        PlayerInputController.OnInputEvent += HandleInput;
    }
    protected override void Update()
    {
        base.Update();
        jumpBufferTimer += Time.deltaTime; // increment timer
        if (jumpBufferTimer > GameConstants.JUMP_BUFFER)
        {
            jumpInputBuffer = false; // if buffer timer passed, disable jump
        }
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    private void OnDisable()
    {
        // Disable player controller
        PlayerInputController.OnInputEvent -= HandleInput;
    }

    // Class Functions:
    protected override void InitializeStates()
    {
        // Create States
        // Movement States
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
        inActionState = new PlayerInActionState(this, stateMachine);
        // Reaction States
        //hitHighState = new PlayerHitHighState(this, stateMachine);
        //hitMedState = new PlayerHitMedState(this, stateMachine);
        //hitLowState = new PlayerHitLowState(this, stateMachine);
        //hitAirState = new PlayerHitAirState(this, stateMachine);
        //deathStandingState = new PlayerDeathStandingState(this, stateMachine);
        //deathCrouchingState = new PlayerDeathCrouchingState(this, stateMachine);
        //deathAirState = new PlayerDeathAirState(this, stateMachine);
        
        // Action States
        noActionState = new PlayerNoActionState(this, actionStateMachine);

        // Initialize the starting states
        startState = standingState;
        actionStartState = noActionState;
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
        if (AdvancedMovement.CheckFront(movementController)) // if wall in front of player
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
    private void HandleInput(object sender, InputEventArgs inputEvent)
    {
        switch (inputEvent.input)
        {
            case PlayerInputController.RawInput.SWITCH_WEAPON:
                MasterManager.playerCharacterPersistentData.SwapWeapons();
                weapons.UpdateWeaponSprite();
                break;
        }
    }
}
