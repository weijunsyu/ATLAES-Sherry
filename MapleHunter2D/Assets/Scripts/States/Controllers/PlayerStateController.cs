using UnityEngine;

[RequireComponent(typeof(PlayerWeapons))]
[RequireComponent(typeof(PlayerActionController))]
public class PlayerStateController : AbstractStateController
{
    //Config Parameters:

    // Cached References:
    [HideInInspector] public PlayerWeapons weapons;
    [HideInInspector] public PlayerActionController actionController;

    // State Parameters and Objects:

    // Player States
    // Movement
    [HideInInspector] public PlayerStandingState standingState;
    [HideInInspector] public PlayerCombatIdleState combatIdleState;
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
    [HideInInspector] public PlayerInActionState inActionState;
    // Reaction
    [HideInInspector] public PlayerBurstState burstState;
    [HideInInspector] public PlayerHitHighState hitHighState;
    [HideInInspector] public PlayerHitMedState hitMedState;
    [HideInInspector] public PlayerHitLowState hitLowState;
    [HideInInspector] public PlayerHitAirState hitAirState;
    [HideInInspector] public PlayerRecoveryState recoveryState;
    [HideInInspector] public PlayerKnockbackState knockbackState;
    [HideInInspector] public PlayerKnockdownState knockdownState;
    [HideInInspector] public PlayerDeathState deathState;

    // Player Flags:
    [HideInInspector] public bool canAirDash = true; // enables air dashing
    [HideInInspector] public double jumpBufferTimer = 0d;
    [HideInInspector] public bool jumpInputBuffer = false; // jump input buffer was initiated
    [HideInInspector] public bool isInCombat = false;
    [HideInInspector] public double combatTimer = 0d;
    
    [HideInInspector] public bool isChargedCrouching = false; // used to determine if the player has held a crouching charge
    [HideInInspector] public double crouchingChargeTimer = 0d;
    
    [HideInInspector] public bool isChargedStanding = false;
    [HideInInspector] public double standingChargeTimer = 0d;

    [HideInInspector] public bool isChargedStrafingBack = false;
    [HideInInspector] public double strafingBackChargeTimer = 0d;

    [HideInInspector] public bool isChargedStrafingFront = false;
    [HideInInspector] public double strafingFrontChargeTimer = 0d;


    // Unity Events:
    protected override void Awake()
    {
        // Anything needed to be passed into the States need to be done BEFORE base.Awake()
        actionController = GetComponent<PlayerActionController>(); 
        
        base.Awake();
        
        // Anything that is NOT used by States can be done after
        weapons = GetComponent<PlayerWeapons>();
    }
    protected override void Start()
    {
        base.Start();
        jumpBufferTimer = 0d;
        jumpInputBuffer = false;
        combatTimer = 0d;
        isInCombat = false;
        isChargedCrouching = false;
        crouchingChargeTimer = 0d;
        isChargedStanding = false;
        standingChargeTimer = 0d;
        isChargedStrafingBack = false;
        strafingBackChargeTimer = 0d;
        isChargedStrafingFront = false;
        strafingFrontChargeTimer = 0d;
        weapons.SetPrimaryWeaponSprite(MasterManager.playerCharacterPersistentData.GetPrimaryWeapon());
        weapons.SetSecondaryWeaponSprite(MasterManager.playerCharacterPersistentData.GetSecondaryWeapon());
        actionController.ResetInputBuffer();
    }
    private void OnEnable()
    {
        actionController.ResetInputBuffer();
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

        combatTimer += Time.deltaTime;
        if (combatTimer > GameConstants.COMBAT_COOLDOWN)
        {
            isInCombat = false;
        }

        crouchingChargeTimer += Time.deltaTime;
        if (crouchingChargeTimer > GameConstants.PURE_CHARGE_DOWN_TIME)
        {
            isChargedCrouching = false;
        }

        standingChargeTimer += Time.deltaTime;
        if (standingChargeTimer > GameConstants.PURE_CHARGE_DOWN_TIME)
        {
            isChargedStanding = false;
        }

        strafingBackChargeTimer += Time.deltaTime;
        if (strafingBackChargeTimer > GameConstants.PURE_CHARGE_DOWN_TIME)
        {
            isChargedStrafingBack = false;
        }

        strafingFrontChargeTimer += Time.deltaTime;
        if (strafingFrontChargeTimer > GameConstants.PURE_CHARGE_DOWN_TIME)
        {
            isChargedStrafingFront = false;
        }
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    private void OnDisable()
    {
        actionController.ResetInputBuffer();
        // Disable player controller
        PlayerInputController.OnInputEvent -= HandleInput;
    }

    // Class Functions:
    protected override void InitializeStates()
    {
        // Create States
        // Movement States
        standingState = new PlayerStandingState(this, stateMachine);
        combatIdleState = new PlayerCombatIdleState(this, stateMachine);
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
        // Action States
        inActionState = new PlayerInActionState(this, stateMachine);
        // Reaction States
        //hitHighState = new PlayerHitHighState(this, stateMachine);
        //hitMedState = new PlayerHitMedState(this, stateMachine);
        //hitLowState = new PlayerHitLowState(this, stateMachine);
        //hitAirState = new PlayerHitAirState(this, stateMachine);
        //deathState = new PlayerDeathState(this, stateMachine);
        //deathCrouchingState = new PlayerDeathCrouchingState(this, stateMachine);
        //deathAirState = new PlayerDeathAirState(this, stateMachine);

        // Initialize the starting states
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
