

// Definitions:
/*
 * List of weapons available in game
 */
public enum WeaponType
{
    NONE,
    UNARMED,
    MAGIC,
    GUN,
    KATANA,
    SWORD,
    GREATSWORD,
    DAGGER,
    SPEAR,
    NAGINATA,
    CUBE //Takes up both the primary and secondary slots
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
    public const float DEFAULT_CAMERA_SIZE = 3.5f;
    public const float CAMERA_Y_OFFSET = 1.5f; // Specify the Y offset of the camera when player character present in scene

    // Scene Parameters
    public const int NUMBER_OF_SCENES = 1;
    public const int NUMBER_OF_LEVELS = 0;
    public const int NUMBER_OF_MENUS = 1;
    public const int TUTORIAL_LEVEL_INDEX = 6; // First level of game

    // Game Mechanics
    public const double INPUT_BUFFER_LIFESPAN = 2d; // Number of seconds allowed before input buffer resets
    public const float COLLISION_CHECK_SHRINK_OFFSET = -0.05f; // Offset to shrink collision checks to prevent false positives
    public const float COLLISION_CHECK_DISTANCE_OFFSET = 0.02f; // Distance offset for extending overlap projection to act as buffer
    public const float SLIDING_CHECK_DISTANCE_CAST = 0.02f;
    public const float FLOATING_BODY_GRAVITY_MODIFIER = 6f; // Factor to modify gravity by while floating
    public const float FLOATING_MAX_DROP_SPEED = -8f; // The max velocity a rigidbody can move at in the y plane while floating
    public const float WALL_SLIDE_MAX_DROP_SPEED = -4f;
    
    // Input Settings
    public const float JOYSTICK_BOOL_DEADZONE = 0.7f; // Calibrate sensitivity of joysticks between 0-1 where 0 is most sensitive for boolean use

    // Player Constants
    public const double COYOTE_JUMP_DELAY = 0.0625d; // Amount of time after player leaves valid state for jump where player may still jump
    public const double JUMP_BUFFER = 0.0625d; // If player jumps during invalid state, hold jump command for time JUMP_BUFFER and induce jump if valid state while buffer > 0
    public const double COMBAT_COOLDOWN = 5d; // Time in seconds after doing an attack before character "ends" combat.
    public const int NUMBER_NORMALS = 9; // Number of normal attacks (3 standing buttons, 3 airborne, 3 crouching)
    public const int PLAYER_MAX_HP = 100;
    public const int PLAYER_INVENTORY_SIZE = 10; // Size of the player inventory
    public const int PLAYER_BANK_SIZE = 100; // Size of the player bank
    public const int PLAYER_ITEM_INVENTORY_MAX_STACKS = 10;
    public const int PLAYER_ITEM_BANK_MAX_STACKS = 9999;
    public const int TOTAL_NUMBER_UNIQUE_ITEMS = 0;
    public const int TOTAL_NUMBER_BOSSES = 0;
    public const int TOTAL_NUMBER_WARP_LOCATIONS = 0;

    // Animation Constants
    public const float PLAYER_WEAPON_FLOAT_RANGE = 0.1f; // Range of the floating animation for player weapons
    public const float PLAYER_SECONDARY_FLOAT_OFFSET = 0.3f; // Time offset from primary weapon floating animation
}
