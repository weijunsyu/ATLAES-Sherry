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
    [HideInInspector] public PlayerJumpingState jumpingState;
    [HideInInspector] public PlayerFallingState fallingState;
    [HideInInspector] public PlayerCrouchingState crouchingState;
    [HideInInspector] public PlayerDashingState dashingState;
    [HideInInspector] public PlayerStandingGuardState standingGuardState;
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
    //private bool canJump = true;

    // Unity Events:
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
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
        jumpingState = new PlayerJumpingState(this, stateMachine);
        fallingState = new PlayerFallingState(this, stateMachine);
        crouchingState = new PlayerCrouchingState(this, stateMachine);
        dashingState = new PlayerDashingState(this, stateMachine);
        //standingGuardState = new PlayerStandingGuardState(this, stateMachine);
        //crouchingGuardState = new PlayerCrouchingGuardState(this, stateMachine);

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
}
