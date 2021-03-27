

// Definitions:
/*
 * List of weapons available in game
 */
public enum WeaponType
{
    NONE,
    UNARMED,
    SABER,
    GREATSWORD,
    GUN,
    SWORD,
    NANOBlADES = -1,
}
/*
 * List of named NPC that have conversations/etc with player character and need to be saved
 */
public enum NamedNPC
{
    TEST
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
    public const int TUTORIAL_LEVEL_INDEX = 6; // First level of game

    // Game Mechanics
    public const double INPUT_BUFFER_LIFESPAN = 2d; // Number of seconds allowed before input buffer resets
    public const float COLLISION_CHECK_SHRINK_OFFSET = -0.05f; // Offset to shrink collision checks to prevent false positives
    public const float COLLISION_CHECK_DISTANCE_OFFSET = 0.01f; // Distance offset for extending overlap projection to act as buffer
    public const float FLOATING_BODY_GRAVITY_MODIFIER = 6f; // Factor to modify gravity by while floating
    public const float FLOATING_MAX_DROP_SPEED = -8f; // The max velocity a rigidbody can move at in the y plane while floating
    public const float WALL_SLIDE_MAX_DROP_SPEED = -4f;
    
    // Input Settings
    public const float JOYSTICK_BOOL_DEADZONE = 0.7f; // Calibrate sensitivity of joysticks between 0-1 where 0 is most sensitive for boolean use

    // Player Constants
    public const float COYOTE_JUMP_DELAY = 0.125f;
    public const float JUMP_BUFFER = 0.125f;
    public const float JUMP_RESET_DELAY = 0.05f; // Must be set such that the length of time is less than coyote time but enough to clear airborne check height
    public const float PLAYER_BASE_GROUND_JUMP_VELOCITY = 10f;
    public const float PLAYER_BASE_AIR_JUMP_VELOCITY = 8f;
    public const float PLAYER_BASE_WALK_MOVE_SPEED = 3.0f;
    public const float PLAYER_BASE_DASH_SPEED = 15f;
    public const float PLAYER_BASE_DASH_DURATION = 0.15f;
    public const float PLAYER_CROUCH_MOVE_SPEED = 0f; // Currently player cannot crouch-move thus speed is 0 (allows for expansion in future for crouch-move/crawling)
    public const int PLAYER_NUMBER_AIR_JUMP = 1; // Number of air jumps the player can perform
    public const int PLAYER_INVENTORY_SIZE = 10; // Size of the player inventory
    public const int PLAYER_BANK_SIZE = 100; // Size of the player bank
    public const int PLAYER_ITEM_INVENTORY_MAX_STACKS = 10;
    public const int PLAYER_ITEM_BANK_MAX_STACKS = 9999;
    public const int TOTAL_NUMBER_UNIQUE_ITEMS = 0;
    public const int TOTAL_NUMBER_BOSSES = 0;
    public const int TOTAL_NUMBER_WARP_LOCATIONS = 0;
}
