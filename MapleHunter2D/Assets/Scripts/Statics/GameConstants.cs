

// Definitions:
/*
 * List of player states used to determine current animation state
 */
public enum PlayerAnimationState // Append new states here as they appear such as combos etc.
{
    IDLE,
    WALK,
    DASH,
    JUMP,
    FALL,
    CROUCH,
    WALL_SLIDE,
    DEFEND,
    MELEE_ATK_PRIMARY, // Futher clarification on particular attack done elsewhere
    MELEE_ATK_SECONDARY, // ""
    MELEE_ATK_DUAL, // ""
    RANGE_ATK_PRIMARY, // Futher clarification on particular attack done elsewhere
    RANGE_ATK_SECONDARY, // ""
    RANGE_ATK_DUAL, // ""
    UTILITY_1, // Futher clarification on particular utility skill done elsewhere
    UTILITY_2, // ""
    UTILITY_BOTH, // ""
    DEATH, // Futher clarification on particular circumstance of death done elsewhere
    FAST_FALL
}
/*
 * List of weapons available in game
 */
public enum WeaponType
{
    UNARMED,
    GUN,
    SABER,
    SWORD,
    GREATSWORD,
    STAFF,
    SPEAR,
    GLAIVE,
    WHIP,
    NONE = -1
}
public enum UtilityType
{
    NONE,
    TEST
}
public enum Passive // Name of skill, effects in game, previous skill needed, skill tree
{
    REGENERATE_HP_OVER_TIME // Blood regeneration, +10 HP/s, NONE, Vampire Tree
}
public enum ItemID
{
    BLOOD_POTION // restore blood (HP)
}
/*
 * List of named NPC that have conversations/etc with player character and need to be saved
 */
public enum NamedNPC
{
    TEST
}
/*
 * List of ordered inputs in order of importance from least to most important
 * such that more imortant inputs override less important inputs
 */
public enum OrderedInput
{
    STOP, // Stop in horizontal plane only (gravity is a thing)
    MOVE_RIGHT,
    MOVE_LEFT,
    DASH,
    JUMP,
    MELEE_ATK,
    DEFEND // Cancels out any momentum on character and all animations (combo, recovery, etc); however, cannot itself be cancelled
}
/*
 * List of unordered inputs of which ALL ACTIONS CAN EXIST INDEPENDENT OF EACH OTHER
 * No precedence of any kind
 */
public enum UnorderedInput
{
    CROUCH,
    UP, // Used for combos and entering portals / interactions
    PRIMARY,
    SECONDARY,
    UTILITY_1,
    UTILITY_2
}
public enum ComboInput
{
    END_OF_COMBO, // Used to mark the end of a combo string as well as pad out remaining actions
    MOVE_RIGHT,
    MOVE_LEFT,
    JUMP,
    CROUCH,
    UP,
    DASH,
    DEFEND,
    PRIMARY,
    SECONDARY
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
    public const float COMBO_INPUT_LIFESPAN_IN_SECONDS = 5f; // Number of seconds allowed for player to input a combo sequence
    public const float COLLISION_CHECK_SHRINK_OFFSET = -0.05f; // Offset to shrink collision checks to prevent false positives
    public const float COLLISION_CHECK_DISTANCE_OFFSET = 0.01f; // Distance offset for extending overlap projection to act as buffer
    public const float FLOATING_BODY_GRAVITY_MODIFIER = 6f; // Factor to modify gravity by while floating
    public const float FLOATING_MAX_DROP_SPEED = -8f; // The max velocity a rigidbody can move at in the y plane while floating
    public const float WALL_SLIDE_MAX_DROP_SPEED = -4f;
    
    // Input Settings
    public const float AIM_ATTACK_JOYSTICK_MIN_MAGNITUDE = 0.7f; // Calibrate sensitivity of Aim Attack between 0-1 where 0 is most sensitive

    // Player Constants
    public const float COYOTE_JUMP_DELAY = 0.125f;
    public const float JUMP_BUFFER = 0.125f;
    public const float JUMP_RESET_DELAY = 0.05f; // Must be set such that the length of time is less than coyote time but enough to clear airborne check height
    public const float PLAYER_BASE_GROUND_JUMP_VELOCITY = 10f;
    public const float PLAYER_BASE_AIR_JUMP_VELOCITY = 8f;
    public const float PLAYER_BASE_STAND_MOVE_SPEED = 3.0f;
    public const float PLAYER_BASE_DASH_SPEED = 15f;
    public const float PLAYER_BASE_DASH_DURATION = 0.15f;
    public const float PLAYER_BASE_CROUCH_MOVE_SPEED = 0f; // Currently player cannot crouch-move thus speed is 0 (allows for expansion in future for crouch-move/crawling)
    public const int PLAYER_BASE_AIR_JUMP_NUMBER = 1; // Number of air jumps the player can perform by default
    public const int PLAYER_INVENTORY_SIZE = 10; // Size of the player inventory
    public const int PLAYER_BANK_SIZE = 100; // Size of the player bank
    public const int PLAYER_ITEM_INVENTORY_MAX_STACKS = 10;
    public const int PLAYER_ITEM_BANK_MAX_STACKS = 9999;
    public const int TOTAL_NUMBER_UNIQUE_ITEMS = 0;
    public const int TOTAL_NUMBER_BOSSES = 0;
    public const int TOTAL_NUMBER_WARP_LOCATIONS = 0;
}
