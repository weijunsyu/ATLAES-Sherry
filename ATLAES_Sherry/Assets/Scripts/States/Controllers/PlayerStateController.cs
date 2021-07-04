using UnityEngine;

[RequireComponent(typeof(PlayerWeapons))]
[RequireComponent(typeof(PlayerInputData))]
[RequireComponent(typeof(PlayerActionController))]
public class PlayerStateController : AbstractStateController
{
    //Config Parameters:

    // Cached References:
    [HideInInspector] public PlayerWeapons weapons;
    [HideInInspector] public PlayerActionController actionController;
    [HideInInspector] public PlayerInputData playerInputData;

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
    [HideInInspector] public PlayerSprintingState sprintingState;
    [HideInInspector] public PlayerSprintRecoveryState sprintRecoveryState;
    [HideInInspector] public PlayerSlidingState slidingState;
    [HideInInspector] public PlayerSlidingJumpState slidingJumpState;
    [HideInInspector] public PlayerStandingGuardState standingGuardState;
    [HideInInspector] public PlayerWalkingState walkingState;
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

    [HideInInspector] public bool canSwitchWeapon = true;
    [HideInInspector] public double switchWeaponTimer = 0d;

    [HideInInspector] public bool isChargedCrouching = false; // used to determine if the player has held a crouching charge
    [HideInInspector] public double crouchingChargeTimer = 0d;
    
    [HideInInspector] public bool isChargedStanding = false;
    [HideInInspector] public double standingChargeTimer = 0d;


    // Unity Events:
    protected override void Awake()
    {
        // Anything needed to be passed into the States need to be done BEFORE base.Awake()
        actionController = GetComponent<PlayerActionController>(); 
        playerInputData = GetComponent<PlayerInputData>();
        weapons = GetComponent<PlayerWeapons>();
        
        base.Awake();
        
        // Anything that is NOT used by States can be done after
        
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

        canSwitchWeapon = true;
        switchWeaponTimer = 0d;

        weapons.SetPrimaryWeaponSprite(MasterManager.playerData.GetPrimaryWeapon());
        weapons.SetSecondaryWeaponSprite(MasterManager.playerData.GetSecondaryWeapon());
        playerInputData.ResetInputBuffer();
    }
    private void OnEnable()
    {
        playerInputData.ResetInputBuffer();
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

        switchWeaponTimer += Time.deltaTime;
        if (switchWeaponTimer > GameConstants.WEAPON_SWITCH_COOLDOWN_TIME)
        {
            canSwitchWeapon = true;
        }

    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        PollSwitchWeapon();
    }

    private void OnDisable()
    {
        playerInputData.ResetInputBuffer();
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
        sprintingState = new PlayerSprintingState(this, stateMachine);
        sprintRecoveryState = new PlayerSprintRecoveryState(this, stateMachine);
        slidingState = new PlayerSlidingState(this, stateMachine);
        slidingJumpState = new PlayerSlidingJumpState(this, stateMachine);
        standingGuardState = new PlayerStandingGuardState(this, stateMachine);
        walkingState = new PlayerWalkingState(this, stateMachine);
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
    public void HandleAirborneMoveInput(float speed)
    {
        // Since we clean SOCD in input controller only 1 input (right/left) can be pressed at once
        if (playerInputData.pressedInputs[1] == true) // right
        {
            BasicMovement.MoveWithTurn(movementController, speed, 0, false);
        }
        else if (playerInputData.pressedInputs[2] == true) // left
        {
            BasicMovement.MoveWithTurn(movementController, -speed, 0, false);
        }
        else // right and left both unpressed
        {
            BasicMovement.StopHorizontal(movementController);
        }
    }
    // return true if sliding and false otherwise
    public bool HandleSlideCheck()
    {
        if (AdvancedMovement.CheckSlide(movementController)) // if wall in front of player
        {
            if (movementController.GetVelocity().y > 0)
            {
                if (AdvancedMovement.CheckDown(movementController))
                {
                    return false;
                }
                else
                {
                    return SlideCheckRoutine();
                }
            }
            else
            {
                return SlideCheckRoutine();
            }
        }
        else //Nothing in front
        {
            return false;
        }
    }

    // Assuming there is a wall in front of player and sliding is valid,
    // return true if the player is holding the correct input to initiate a slide
    // otherwise, return false.
    private bool SlideCheckRoutine()
    {
        // If facing right and NOT pressing right button
        if (movementController.IsFacingRight() && !playerInputData.pressedInputs[1])
        {
            return false;
        }
        // Else if facing left and NOT pressing left button
        else if (!movementController.IsFacingRight() && !playerInputData.pressedInputs[2])
        {
            return false;
        }
        return true;
    }

    private void PollSwitchWeapon()
    {
        if (playerInputData.pressedInputs[11] && canSwitchWeapon)
        {
            MasterManager.playerData.SwapWeapons();
            weapons.UpdateWeaponSprite();
            canSwitchWeapon = false;
            switchWeaponTimer = 0d;
        }
    }
}
