using UnityEngine;

public static class PlayerTimings
{
    // Movement Timings
    public static readonly float[] IDLE_TIMES = { 0.8f, 0.8f };
    
    public const float             PLAYER_WALK_SPEED = 1.7f;
    public static readonly float[] WALK_TIMES = { 0.115f, 0.115f, 0.115f, 0.115f, 0.115f, 0.115f, 0.115f, 0.115f };
    
    public const float             PLAYER_RUN_SPEED = 6.0f;
    public static readonly float[] RUN_TIMES = { 0.08f, 0.08f, 0.08f, 0.08f, 0.08f, 0.08f, 0.08f, 0.08f };

    public const float             PLAYER_JUMP_VELOCITY = 9.5f;
    public const float             PLAYER_AIR_MOVE_SPEED = 5.0f;

    public static readonly float[] FALL_TIMES = { 0.1f, 0.1f };

    public const float             PLAYER_DASH_SPEED = 12f;
    public const double            PLAYER_DASH_EXECUTE = 0.2d;
    public const double            PLAYER_DASH_RECOVERY = 0.15d;
    public const double            PLAYER_DASH_TOTAL = PLAYER_DASH_EXECUTE + PLAYER_DASH_RECOVERY;
    public static readonly float[] DASH_TIMES = { 0.05f, 0.02f, 0.02f, 0.08f, 0.03f }; // sum to PLAYER_DASH_EXECUTE
    
    public static readonly float[] SLIDE_TIMES = { 0.25f, 0.25f };

    public const float             PLAYER_SIDING_JUMP_VELOCITY = 7.9225f; //7.93
    public const double            PLAYER_SLIDE_JUMP_DURATION = 0.1d;


    // Reaction Timings
    public static readonly float[] BURST_TIMINGS = { 1f, 1f };
    public const float             BURST_LINEAR_FORCE = 10f;

    public static readonly float[] AIR_ROLL_TIMINGS = { 1f, 1f, 1f, 1f };

    public const double            minKnockdownTime = 1d;
    public const double            maxKnockdownTime = 2d;

    public const double            minKnockdownRecoverTime = 1d;
    public const double            maxKnockdownRecoverTime = 2d;

    public static readonly float[] DEATH_TIMINGS = { 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f };


    // Unarmed (prefix: U)
    public static readonly float[] U_COMBAT_IDLE_TIMES = { 0.8f, 0.8f };

    public static readonly float[] U_GUARD_TIMES = { 0.8f, 0.8f };
    public const float             U_GUARD_DAMAGE_MODIFIER = 1f; // factor to reduce damage taken when successfully guarded (between 0 and 1, where 1 is 100% damage mitigated)

    public const float             U_STRAFE_SPEED = 0.55f;
    public static readonly float[] U_STRAFE_TIMES = { 0.4f, 0.4f };

    public static readonly float[] U_STAND_LIGHT_TIMES = { 0.06f, 0.10f };
    public static readonly float[] U_STAND_LIGHT_FRAMES = { 0.06f, 0.04f, 0.06f }; // { startup (s), execute (e), recovery (r) } (total to duration)
    public const double            U_STAND_LIGHT_DURATION = 0.16d; // Total duration of attack
    public const float             U_STAND_LIGHT_HIT_STUN = 0f; // Amount of stun imparted to enemy if hit
    public const float             U_STAND_LIGHT_BLOCK_STUN = 0f; // Amount of stun imparted to enemy if blocked
    public static readonly Vector2 U_STAND_LIGHT_BLOCK_FORCE = new Vector2(1f, 1f); // pushback on player if hit was successful (where pos. is towards hit location)
    public static readonly Vector2 U_STAND_LIGHT_HIT_FORCE = new Vector2(1f, 1f); // force applied to the enemy on successful hit (where pos. is away from hit location)

    public static readonly float[] U_STAND_MEDIUM_TIMES = { 0.06f, 0.12f, 0.04f };
    public static readonly float[] U_STAND_MEDIUM_FRAMES = { 0.06f, 0.12f, 0.04f }; // s e r
    public const float             U_STAND_MEDIUM_DURATION = 0.22f;
    public const float             U_STAND_MEDIUM_HIT_STUN = 0f;
    public const float             U_STAND_MEDIUM_BLOCK_STUN = 0f;
    public static readonly Vector2 U_STAND_MEDIUM_BLOCK_FORCE = new Vector2(1f, 1f);
    public static readonly Vector2 U_STAND_MEDIUM_HIT_FORCE = new Vector2(1f, 1f);

    public static readonly float[] U_STAND_HEAVY_TIMES = { 0.06f, 0.14f, 0.08f };
    public static readonly float[] U_STAND_HEAVY_FRAMES = { 0.06f, 0.14f, 0.08f }; // s e r
    public const float             U_STAND_HEAVY_DURATION = 0.28f;
    public const float             U_STAND_HEAVY_HIT_STUN = 0f;
    public const float             U_STAND_HEAVY_BLOCK_STUN = 0f;
    public static readonly Vector2 U_STAND_HEAVY_BLOCK_FORCE = new Vector2(1f, 1f);
    public static readonly Vector2 U_STAND_HEAVY_HIT_FORCE = new Vector2(1f, 1f);

    public static readonly float[] U_CROUCH_LIGHT_TIMES = { 0.06f, 0.10f };
    public static readonly float[] U_CROUCH_LIGHT_FRAMES = { 0.06f, 0.04f, 0.06f }; // s e r
    public const float             U_CROUCH_LIGHT_DURATION = 0.16f;
    public const float             U_CROUCH_LIGHT_HIT_STUN = 0f;
    public const float             U_CROUCH_LIGHT_BLOCK_STUN = 0f;
    public static readonly Vector2 U_CROUCH_LIGHT_BLOCK_FORCE = new Vector2(1f, 1f);
    public static readonly Vector2 U_CROUCH_LIGHT_HIT_FORCE = new Vector2(1f, 1f);

    public static readonly float[] U_CROUCH_MEDIUM_TIMES = { 0.06f, 0.14f, 0.08f };
    public static readonly float[] U_CROUCH_MEDIUM_FRAMES = { 0.06f, 0.14f, 0.08f }; // s e r
    public const float             U_CROUCH_MEDIUM_DURATION = 0.28f;
    public const float             U_CROUCH_MEDIUM_HIT_STUN = 0f;
    public const float             U_CROUCH_MEDIUM_BLOCK_STUN = 0f;
    public static readonly Vector2 U_CROUCH_MEDIUM_USE_FORCE = new Vector2(1f, 0f);
    public static readonly Vector2 U_CROUCH_MEDIUM_BLOCK_FORCE = new Vector2(1f, 1f);
    public static readonly Vector2 U_CROUCH_MEDIUM_HIT_FORCE = new Vector2(1f, 1f);

    public static readonly float[] U_CROUCH_HEAVY_TIMES = { 0.06f, 0.14f, 0.08f };
    public static readonly float[] U_CROUCH_HEAVY_FRAMES = { 0.06f, 0.14f, 0.08f }; // s e r
    public const float             U_CROUCH_HEAVY_DURATION = 0.28f;
    public const float             U_CROUCH_HEAVY_HIT_STUN = 0f;
    public const float             U_CROUCH_HEAVY_BLOCK_STUN = 0f;
    public static readonly Vector2 U_CROUCH_HEAVY_BLOCK_FORCE = new Vector2(1f, 1f);
    public static readonly Vector2 U_CROUCH_HEAVY_HIT_FORCE = new Vector2(1f, 1f);

    public static readonly float[] U_JUMP_LIGHT_TIMES = { 0.06f, 0.10f };
    public static readonly float[] U_JUMP_LIGHT_FRAMES = { 0.06f, 0.04f, 0.06f }; // s e r
    public const float             U_JUMP_LIGHT_DURATION = 0.16f;
    public const float             U_JUMP_LIGHT_HIT_STUN = 0f;
    public const float             U_JUMP_LIGHT_BLOCK_STUN = 0f;
    public static readonly Vector2 U_JUMP_LIGHT_BLOCK_FORCE = new Vector2(1f, 1f);
    public static readonly Vector2 U_JUMP_LIGHT_HIT_FORCE = new Vector2(1f, 1f);

    public static readonly float[] U_JUMP_MEDIUM_TIMES = { 0.06f, 0.14f, 0.08f };
    public static readonly float[] U_JUMP_MEDIUM_FRAMES = { 0.06f, 0.14f, 0.08f }; // s e r
    public const float             U_JUMP_MEDIUM_DURATION = 0.28f;
    public const float             U_JUMP_MEDIUM_HIT_STUN = 0f;
    public const float             U_JUMP_MEDIUM_BLOCK_STUN = 0f;
    public static readonly Vector2 U_JUMP_MEDIUM_BLOCK_FORCE = new Vector2(1f, 1f);
    public static readonly Vector2 U_JUMP_MEDIUM_HIT_FORCE = new Vector2(1f, 1f);

    public static readonly float[] U_JUMP_HEAVY_TIMES = { 0.08f };
    public static readonly float[] U_JUMP_HEAVY_FRAMES = { 1f, 1f, 0f }; // s e r
    public const float             U_JUMP_HEAVY_DURATION = 0.08f;
    public const float             U_JUMP_HEAVY_HIT_STUN = 0f;
    public const float             U_JUMP_HEAVY_BLOCK_STUN = 0f;
    public static readonly Vector2 U_JUMP_HEAVY_USE_FORCE = new Vector2(1f, -20f); // force applied to player on action use (where positive is up and forwards)
    public static readonly Vector2 U_JUMP_HEAVY_BLOCK_FORCE = new Vector2(1f, 1f); // pushback on player if hit was successful (where pos. is towards hit location)
    public static readonly Vector2 U_JUMP_HEAVY_HIT_FORCE = new Vector2(1f, 1f); // force applied to the enemy on successful hit (where pos. is away from hit location)

    public static readonly int[]   U_LOW_KICK_INPUT = { 9, 1, 5 }; // int corrisponds to ComboInput enum values with the array being the input stream needed to perform the combo
    public static readonly float[] U_LOW_KICK_TIMES = { 1f, 1f, 1f, 1f };
    public static readonly float[] U_LOW_KICK_FRAMES = { 2f, 1f, 1f }; // s e r
    public const double            U_LOW_KICK_DURATION = 4f; // both times and frames must sum to duration
    public const float             U_LOW_KICK_HIT_STUN = 0f;
    public const float             U_LOW_KICK_BLOCK_STUN = 0f;
    public static readonly Vector2 U_LOW_KICK_USE_FORCE = new Vector2(1f, 0f);
    public static readonly Vector2 U_LOW_KICK_BLOCK_FORCE = new Vector2(1f, 1f);
    public static readonly Vector2 U_LOW_KICK_HIT_FORCE = new Vector2(1f, 1f);

    public static readonly int[]   U_SNAP_KICK_INPUT = { 10, 1, 5 };
    public static readonly float[] U_SNAP_KICK_TIMES = { 1f, 1f, 1f, 1f };
    public static readonly float[] U_SNAP_KICK_FRAMES = { 2f, 1f, 1f }; // s e r
    public const double            U_SNAP_KICK_DURATION = 4f;
    public const float             U_SNAP_KICK_HIT_STUN = 0f;
    public const float             U_SNAP_KICK_BLOCK_STUN = 0f;
    public static readonly Vector2 U_SNAP_KICK_USE_FORCE = new Vector2(1f, 0f);
    public static readonly Vector2 U_SNAP_KICK_BLOCK_FORCE = new Vector2(1f, 1f);
    public static readonly Vector2 U_SNAP_KICK_HIT_FORCE = new Vector2(1f, 1f);

    public static readonly int[]   U_VERTICAL_KICK_INPUT = { 9, 4 };
    public static readonly float[] U_VERTICAL_KICK_TIMES = { 1f, 1f, 1f, 1f };
    public static readonly float[] U_VERTICAL_KICK_FRAMES = { 2f, 1f, 1f };
    public const double            U_VERTICAL_KICK_DURATION = 4f;
    public const float             U_VERTICAL_KICK_HIT_STUN = 0f;
    public const float             U_VERTICAL_KICK_BLOCK_STUN = 0f;
    public static readonly Vector2 U_VERTICAL_KICK_USE_FORCE = new Vector2(1f, 1f);
    public static readonly Vector2 U_VERTICAL_KICK_BLOCK_FORCE = new Vector2(1f, 1f);
    public static readonly Vector2 U_VERTICAL_KICK_HIT_FORCE = new Vector2(1f, 1f);

    public static readonly int[]   U_THRUST_KICK_INPUT = { 10, 7 };
    public static readonly float[] U_THRUST_KICK_TIMES = { 1f, 1f, 1f, 1f, 1f, 1f };
    public static readonly float[] U_THRUST_KICK_FRAMES = { 1f, 1f, 4f };
    public const double            U_THRUST_KICK_DURATION = 6f;
    public const float             U_THRUST_KICK_HIT_STUN = 0f;
    public const float             U_THRUST_KICK_BLOCK_STUN = 0f;
    public static readonly Vector2 U_THRUST_KICK_USE_FORCE = new Vector2(1f, 1f);
    public static readonly Vector2 U_THRUST_KICK_BLOCK_FORCE = new Vector2(1f, 1f);
    public static readonly Vector2 U_THRUST_KICK_HIT_FORCE = new Vector2(1f, 1f);

    public static readonly int[]   U_HOOK_KICK_INPUT = { 10, -1, -4, 1, -2, 4, 2 };
    public static readonly float[] U_HOOK_KICK_TIMES = { 1f, 1f, 1f, 1f, 1f };
    public static readonly float[] U_HOOK_KICK_FRAMES = { 1f, 3f, 1f };
    public const double            U_HOOK_KICK_DURATION = 5f;
    public const float             U_HOOK_KICK_HIT_STUN = 0f;
    public const float             U_HOOK_KICK_BLOCK_STUN = 0f;
    public static readonly Vector2 U_HOOK_KICK_USE_FORCE = new Vector2(1f, 1f);
    public static readonly Vector2 U_HOOK_KICK_BLOCK_FORCE = new Vector2(1f, 1f);
    public static readonly Vector2 U_HOOK_KICK_HIT_FORCE = new Vector2(1f, 1f);

    public static readonly int[]   U_AIR_DRAGON_PUNCH_INPUT = { 10, 1, 3, -4, 4 };
    public static readonly float[] U_AIR_DRAGON_PUNCH_TIMES = { 1f, 1f, 1f, 1f, 1f };
    public static readonly float[] U_AIR_DRAGON_PUNCH_FRAMES = { 1f, 3f, 1f };
    public const double            U_AIR_DRAGON_PUNCH_DURATION = 5f;
    public const float             U_AIR_DRAGON_PUNCH_HIT_STUN = 0f;
    public const float             U_AIR_DRAGON_PUNCH_BLOCK_STUN = 0f;
    public static readonly Vector2 U_AIR_DRAGON_PUNCH_USE_FORCE = new Vector2(1f, 1f);
    public static readonly Vector2 U_AIR_DRAGON_PUNCH_BLOCK_FORCE = new Vector2(1f, 1f);
    public static readonly Vector2 U_AIR_DRAGON_PUNCH_HIT_FORCE = new Vector2(1f, 1f);

    public static readonly int[]   U_GROUND_DRAGON_PUNCH_INPUT = { 10, 1, 3, -4, 4 };
    public const int U_GROUND_DRAGON_PUNCH_NUM_INPUTS = 5;
    public static readonly float[] U_GROUND_DRAGON_PUNCH_TIMES = { 1f, 1f, 1f, 1f, 1f };
    public static readonly float[] U_GROUND_DRAGON_PUNCH_FRAMES = { 1f, 3f, 1f };
    public const double            U_GROUND_DRAGON_PUNCH_DURATION = 5f;
    public const float             U_GROUND_DRAGON_PUNCH_HIT_STUN = 0f;
    public const float             U_GROUND_DRAGON_PUNCH_BLOCK_STUN = 0f;
    public static readonly Vector2 U_GROUND_DRAGON_PUNCH_USE_FORCE = new Vector2(1f, 1f);
    public static readonly Vector2 U_GROUND_DRAGON_PUNCH_BLOCK_FORCE = new Vector2(1f, 1f);
    public static readonly Vector2 U_GROUND_DRAGON_PUNCH_HIT_FORCE = new Vector2(1f, 1f);

    public static readonly int[]   U_FEINT_ROLL_INPUT = { 8, -1, -4, 1, -2, 4, 2 };
    public const int               U_FEINT_ROLL_NUM_INPUTS = 7;
    public static readonly float[] U_FEINT_ROLL_TIMES = { 1f, 1f, 1f, 1f, 1f };
    public static readonly float[] U_FEINT_ROLL_FRAMES = { 1f, 3f, 1f };
    public const double            U_FEINT_ROLL_DURATION = 5f;
    public const float             U_FEINT_ROLL_HIT_STUN = 0f;
    public const float             U_FEINT_ROLL_BLOCK_STUN = 0f;
    public static readonly Vector2 U_FEINT_ROLL_USE_FORCE = new Vector2(1f, 1f);
    public static readonly Vector2 U_FEINT_ROLL_BLOCK_FORCE = new Vector2(1f, 1f);
    public static readonly Vector2 U_FEINT_ROLL_HIT_FORCE = new Vector2(1f, 1f);

    public static readonly int[]   U_AIR_AXE_KICK_INPUT = { 9, -1, -4, 1, -2, 4, 2 };
    public static readonly float[] U_AIR_AXE_KICK_TIMES = { 1f, 1f, 1f, 1f, 1f };
    public static readonly float[] U_AIR_AXE_KICK_FRAMES = { 1f, 3f, 1f };
    public const double            U_AIR_AXE_KICK_DURATION = 5f;
    public const float             U_AIR_AXE_KICK_HIT_STUN = 0f;
    public const float             U_AIR_AXE_KICK_BLOCK_STUN = 0f;
    public static readonly Vector2 U_AIR_AXE_KICK_USE_FORCE = new Vector2(1f, 1f);
    public static readonly Vector2 U_AIR_AXE_KICK_BLOCK_FORCE = new Vector2(1f, 1f);
    public static readonly Vector2 U_AIR_AXE_KICK_HIT_FORCE = new Vector2(1f, 1f);

    public static readonly int[]   U_ROLLING_AXE_KICK_INPUT = { 10, -1, -4, 1, -2, 4, 2 }; 
    public static readonly float[] U_ROLLING_AXE_KICK_TIMES = { 0.04f, 0.04f, 0.04f, 0.06f, 0.1f, 0.1f, 0.1f, 0.1f };
    public static readonly float[] U_ROLLING_AXE_KICK_FRAMES = { 1f, 3f, 1f };
    public const double            U_ROLLING_AXE_KICK_DURATION = 0.58f;
    public const float             U_ROLLING_AXE_KICK_HIT_STUN = 0f;
    public const float             U_ROLLING_AXE_KICK_BLOCK_STUN = 0f;
    public static readonly Vector2 U_ROLLING_AXE_KICK_USE_FORCE = new Vector2(1f, 1f);
    public static readonly Vector2 U_ROLLING_AXE_KICK_BLOCK_FORCE = new Vector2(1f, 1f);
    public static readonly Vector2 U_ROLLING_AXE_KICK_HIT_FORCE = new Vector2(1f, 1f);
}
