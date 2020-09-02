using UnityEngine;


public class PlayerAnimationController : AnimationController
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
    // Config Parameters:

    // Cached References:


    // Unity Events:
    protected override void Awake()
    {
        base.Awake();
    }
    private void Update()
    {
        RunAnimationState();
        Debug.Log("Current Animation State is: " + (PlayerAnimationState)animationState);
    }


    // Class Functions:
    public new PlayerAnimationState GetAnimationState()
    {
        return (PlayerAnimationState)animationState;
    }
    public void SetAnimationState(PlayerAnimationState state)
    {
        animationState = (int)state;
    }
}
