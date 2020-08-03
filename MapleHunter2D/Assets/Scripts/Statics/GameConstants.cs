// Definitions:
/*
 * List of movement inputs in order of importance from least to most important
 * such that more imortant inputs override less important inputs
 */
public enum OrderedInput
{
    STOP = 0, // Stop in horizontal plane only (gravity is a thing)
    MOVE_RIGHT = 1,
    MOVE_LEFT = 2,
    DASH = 3,
    JUMP = 4,
    DEFEND = 5 // Cancels out any momentum on character and all animations (combo, recovery, etc); however, cannot itself be cancelled
}
/*
 * List of action inputs of which ALL ACTIONS CAN EXIST INDEPENDENT OF EACH OTHER
 * No precedence of any kind
 */
public enum UnorderedInput
{
    CROUCH = 6,
    UP = 7, // Used for combos and entering portals / interactions
    PRIMARY = 8,
    SECONDARY = 9,
    UTILITY_1 = 10,
    UTILITY_2 = 11
}
public static class GameConstants
{
    // Save settings
    public const string SAVEPATH = null; //specify the save path (currently NOT in use instead using: Application.persistentDataPath within SaveSystem.cs)
    public const string SAVEFILE = "savedata.save";

    // Camera settings
    public const float TARGET_SCREEN_WIDTH_BY_RATIO = 16f; // The 16 part of 16:9 aspect ratio
    public const float TARGET_SCREEN_HEIGHT_BY_RATIO = 9f; // The 9 part of 16:9 aspect ratio
    public const float DEFAULT_CAMERA_SIZE = 4.5f;
    public const float CAMERA_Y_OFFSET = 1.5f; // Specify the Y offset of the camera when player character present in scene

    // Scene Parameters
    public const int NUMBER_OF_SCENES = 1;
    public const int NUMBER_OF_LEVELS = 0;
    public const int NUMBER_OF_MENUS = 1;

    // Game Mechanics
    public const float COMBO_INPUT_LIFESPAN_IN_SECONDS = 5f; // Number of seconds allowed for player to input a combo sequence
    public const float COLLISION_CHECK_SHRINK_OFFSET = -0.05f; // Offset to shrink collision checks to prevent false positives
    public const float COLLISION_CHECK_DISTANCE_OFFSET = 0.01f; // Distance offset for extending overlap projection to act as buffer
    public const float FLOATING_BODY_GRAVITY_MODIFIER = 6f; // Factor to modify gravity by while floating
    public const float FLOATING_MAX_DROP_SPEED = -8f; // The max velocity a rigidbody can move at in the y plane while floating
    public const float WALL_SLIDE_MAX_DROP_SPEED = -5.5f;
    public const float SIZE_FACTOR_WALL_SLIDE_DASH_INVERT = 0.6f; // The factor for scaling overlapBox size that checks for if wall sliding

    // Input Settings
    public const float AIM_ATTACK_JOYSTICK_MIN_MAGNITUDE = 0.7f; // Calibrate sensitivity of Aim Attack between 0-1 where 0 is most sensitive

    // Player Constants
    public const float COYOTE_JUMP_DELAY = 0.125f;
    public const float JUMP_BUFFER = 0.125f;
    public const float JUMP_RESET_DELAY = 0.05f; // Must be set such that the length of time is less than coyote time but enough to clear airborne check height

    public const float PLAYER_BASE_GROUND_JUMP = 10f;
    public const float PLAYER_BASE_AIR_JUMP = 8f;
}
