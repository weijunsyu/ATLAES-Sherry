public static class PlayerTimings
{
    // Basic Timings
    public static readonly float[] IDLE_TIMES = { 0.8f, 0.8f };
    
    public const float             PLAYER_WALK_SPEED = 1.7f;
    public static readonly float[] WALK_TIMES = { 0.115f, 0.115f, 0.115f, 0.115f, 0.115f, 0.115f, 0.115f, 0.115f };
    
    public const float             PLAYER_RUN_SPEED = 6.0f;
    public static readonly float[] RUN_TIMES = { 0.08f, 0.08f, 0.08f, 0.08f, 0.08f, 0.08f, 0.08f, 0.08f };

    public const float             PLAYER_JUMP_VELOCITY = 9f;
    public const float             PLAYER_AIR_MOVE_SPEED = 5.0f;

    public static readonly float[] FALL_TIMES = { 0.1f, 0.1f };

    public const float             PLAYER_DASH_SPEED = 12f;
    public const double            PLAYER_DASH_EXECUTE = 0.2d;
    public const double            PLAYER_DASH_RECOVERY = 0.15d;
    public const double            PLAYER_DASH_TOTAL = PLAYER_DASH_EXECUTE + PLAYER_DASH_RECOVERY;
    public static readonly float[] DASH_TIMES = { 0.05f, 0.02f, 0.02f, 0.08f, 0.03f }; // sum to PLAYER_DASH_EXECUTE
    
    public static readonly float[] SLIDE_TIMES = { 0.25f, 0.25f };

    public const float             PLAYER_SIDING_JUMP_VELOCITY = 8.5f;
    public const double            PLAYER_SLIDE_JUMP_DURATION = 0.1d;


    // Unarmed Timings (prefix: U)
    public static readonly float[] U_GUARD_TIMES = { 0.8f, 0.8f };
    public const float             U_GUARD_HIT_MODIFIER = 1f;

    public const float             U_STRAFE_SPEED = 0.55f;
    public static readonly float[] U_STRAFE_TIMES = { 0.4f, 0.4f };

    public static readonly float[] U_STAND_LIGHT_TIMES = { 0.04f, 0.06f }; // { startup (s), execute (e), recovery (r) }
    public const double            U_STAND_LIGHT_DURATION = 0.1d; // Total duration of attack (s + e + r)
    public const float             U_STAND_LIGHT_HIT = 0f; // Amount of stun imparted to enemy if hit
    public const float             U_STAND_LIGHT_BLOCK = 0f; // Amount of stun imparted to enemy if blocked

    public const float             U_STAND_MEDIUM_EXECUTE = 0.8f;
    public const float             U_STAND_MEDIUM_HIT = 0f;
    public const float             U_STAND_MEDIUM_BLOCK = 0f;

    public static readonly float[] U_STAND_HEAVY_TIMES = { 1f, 1f, 1f }; // { startup (s), execute (e), recovery (r) }
    public const float             U_STAND_HEAVY_HIT = 0f;
    public const float             U_STAND_HEAVY_BLOCK = 0f;

    public const float             U_CROUCH_LIGHT_EXECUTE = 0.8f;
    public const float             U_CROUCH_LIGHT_HIT = 0f;
    public const float             U_CROUCH_LIGHT_BLOCK = 0f;

    public const float             U_CROUCH_MEDIUM_EXECUTE = 0.8f;
    public const float             U_CROUCH_MEDIUM_HIT = 0f;
    public const float             U_CROUCH_MEDIUM_BLOCK = 0f;

    public const float             U_JUMP_LIGHT_EXECUTE = 0.8f;
    public const float             U_JUMP_LIGHT_HIT = 0f;
    public const float             U_JUMP_LIGHT_BLOCK = 0f;

    public const float             U_JUMP_MEDIUM_EXECUTE = 0.8f;
    public const float             U_JUMP_MEDIUM_HIT = 0f;
    public const float             U_JUMP_MEDIUM_BLOCK = 0f;

    public static readonly float[] U_JUMP_HEAVY_TIMES = { 1f, 1f }; // s, e
    public const float             U_JUMP_HEAVY_HIT = 0f;
    public const float             U_JUMP_HEAVY_BLOCK = 0f;

    //public static readonly int[] U_LOW_KICK_INPUT = { 5, 1 }; // int corrisponds to RawInput enum value for press
    public static readonly float[] U_LOW_KICK_TIMES = { 1f, 1f }; // s, e
    public const float             U_LOW_KICK_HIT = 0f;
    public const float             U_LOW_KICK_BLOCK = 0f;

    public static readonly float[] U_SNAP_KICK_TIMES = { 1f, 1f }; // s, e
    public const float             U_SNAP_KICK_HIT = 0f;
    public const float             U_SNAP_KICK_BLOCK = 0f;

    public static readonly float[] U_THRUST_KICK_TIMES = { 1f, 1f, 1f, 1f, 1f }; // s, e, r
    public const float             U_THRUST_KICK_HIT = 0f;
    public const float             U_THRUST_KICK_BLOCK = 0f;

    public static readonly float[] U_SPIN_HOOK_KICK_TIMES = { 1f, 1f, 1f, 1f, 1f }; // s, e, r
    public const float             U_SPIN_HOOK_KICK_HIT = 0f;
    public const float             U_SPIN_HOOK_KICK_BLOCK = 0f;
}
