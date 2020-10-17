using UnityEngine;

public class PlayerStateController : AbstractStateController
{
    public enum PlayerMoveState
    {
        IDLE,           // GROUNDED
        WALK,
        JUMP,
        CROUCH,
        HIT_GROUND,     // GROUNDED
        GAINING,        // AIRBOURNE
        FALLING,
        SLIDING,
        AIR_JUMP,
        AIR_DUCK,
        HIT_AIR,        // AIRBOURNE
        DASH,           // ANY
        DEFEND,
        COMBO,
        DEATH           // ANY
    }
    public enum PlayerActionState
    {
        MELEE_ATK_PRIMARY, // Futher clarification on particular attack done elsewhere
        MELEE_ATK_SECONDARY, // ""
        MELEE_ATK_DUAL, // ""
        RANGE_ATK_PRIMARY, // Futher clarification on particular attack done elsewhere
        RANGE_ATK_SECONDARY, // ""
        RANGE_ATK_DUAL, // ""
        UTILITY_1, // Futher clarification on particular utility skill done elsewhere
        UTILITY_2, // ""
        UTILITY_BOTH, // ""
    }

    //Config Parameters:

    // Cached References:

    // State Parameters and Objects:
    private Idle idle;
    private Walk walk;

    private bool playerHasCharacterControl = true;


    // Unity Events:
    protected override void Awake()
    {
        base.Awake();
        InitializeStates();

        moveState = idle;
    }

    // Class Functions:
    public bool GetPlayerHasCharacterControl()
    {
        return playerHasCharacterControl;
    }
    public void SetPlayerHasCharacterControl(bool value)
    {
        playerHasCharacterControl = value;
    }
    private void InitializeStates()
    {
        idle = new Idle((int)PlayerMoveState.IDLE, animationController, movementController);
        walk = new Walk((int)PlayerMoveState.WALK, animationController, movementController);
    }
}
