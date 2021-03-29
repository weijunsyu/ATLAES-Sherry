public static class PlayerBasicTimings
{
    // Animation Timings
    public static readonly float[] idleTimes = { 0.8f, 0.8f };
    public static readonly float[] walkTimes = { 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f };
    public static readonly float[] runTimes = { 0.08f, 0.08f, 0.08f, 0.08f, 0.08f, 0.08f, 0.08f, 0.08f };
    public static readonly float[] crouchTimes = { 0.05f };
    public static readonly float[] dashTimes = { 0.03f, 0.02f, 0.02f, 0.02f, 0.08f, 0.03f }; //values add to PLAYER_AIR_DASH_DURATION
    public static readonly float[] slideTimes = { 0.5f, 0.5f };

    // Player Unarmed Constants:
    public const float PLAYER_JUMP_VELOCITY = 10f;
    public const float PLAYER_SIDING_JUMP_VELOCITY = 8.5f;
    public const float PLAYER_WALK_SPEED = 3.0f;
    public const float PLAYER_RUN_SPEED = 6.0f;
    public const float PLAYER_AIR_MOVE_SPEED = 5.0f;
    public const float PLAYER_DASH_SPEED = 12f;
    public const double PLAYER_SLIDE_JUMP_DURATION = 0.1d;
    public const double PLAYER_DASH_EXECUTE = 0.2d;
    public const double PLAYER_DASH_RECOVERY = 0.15d;
    public const double PLAYER_DASH_TOTAL = PLAYER_DASH_EXECUTE + PLAYER_DASH_RECOVERY;
}
