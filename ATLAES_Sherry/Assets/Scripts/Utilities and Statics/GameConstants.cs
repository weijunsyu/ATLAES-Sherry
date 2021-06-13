using UnityEngine;

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
    // Math and Meta Constants
    public const float EPSILON = 0.005f;

    // Save Settings
    public const string SAVEPATH = null; //specify the save path (currently NOT in use instead using: Application.persistentDataPath within SaveSystem.cs)
    public const string SAVEFILE = "savedata.save";
    public const string SETTINGSFILE = "settingsdata.save";

    // Game Window Settings
    public const int MIN_WINDOW_WIDTH = 1280; // Min GAME resolution width 796 (Window > Game)
    public const int MIN_WINDOW_HEIGHT = 720; // Min GAME resolution height 448 (Window > Game)
    public const bool DEFAULT_WINDOW_IS_FULLSCREEN = false; // By default the game runs in windowed mode

    // Video Settings
    public const int MIN_FPS = 60;
    public const int MAX_FPS = 1000;
    public const int NUM_DISCRETE_FPS_VALUES = 6; // 60, 120, 144, 240, 360, unlimited
    public const int FPS_0 = 60;
    public const int FPS_1 = 120;
    public const int FPS_2 = 144;
    public const int FPS_3 = 240;
    public const int FPS_4 = 360;
    public const int FPS_5 = -1; // Unlimited FPS

    // Camera Settings
    public const int TARGET_ASPECT_RATIO_X = 16;
    public const int TARGET_ASPECT_RATIO_Y = 9;

    // Scene Parameters
    public const int NUMBER_OF_SCENES = 1;
    public const int NUMBER_OF_LEVELS = 0;
    public const int NUMBER_OF_MENUS = 1;
    public const int TUTORIAL_LEVEL_INDEX = 6; // First level of game

    // Audio Constants
    public const float MUTE_IN_DB = -80.0f;
    public const float MAX_VOLUME_IN_DB = 20.0f;
    public const string MASTER_VOLUME_GROUP_NAME = "MasterVolume";
    public const string MUSIC_VOLUME_GROUP_NAME = "MusicVolume";
    public const string EFFECTS_VOLUME_GROUP_NAME = "EffectsVolume";
    public const float DEFAULT_MASTER_VOLUME = 1.0f;
    public const float DEFAULT_MUSIC_VOLUME = 0.6f;
    public const float DEFAULT_EFFECTS_VOLUME = 0.8f;
    public const int NUM_DISCRETE_VOLUME_VALUES = 21; // 0%, 5%, 10%, ... , 95%, 100% volume

    // User Interface Constants
    public const double EQUALIZED_LOAD_TIME_IN_SECONDS = 5d;
    public const int MAX_WHOLE_DIGITS_IN_TIMER = 7;
    public const int MAX_E_VALUE_LENGTH_IN_TIMER = 8;
    public const byte MENU_ALPHA_DARKEN_VALUE = 150;
    public static readonly Color32 DARK_GREY = new Color32(100, 100, 100, 255);
    public static readonly Color32 BLACK = new Color32(20, 20, 20, 255);
    public static readonly Color32 WHITE = new Color32(252, 252, 252, 255);
    public static readonly Color32 RED = new Color32(208, 0, 0, 255);
    public static readonly Color32 CYAN = new Color32(0, 209, 209, 255);
    public static readonly Color32 OFF_WHITE = new Color32(197, 197, 197, 255);
    public static readonly Color32 OFF_RED = new Color32(153, 0, 0, 255);
    public static readonly Color32 OFF_CYAN = new Color32(0, 154, 154, 255);
    public static readonly Color32 TRUE_WHITE = new Color32(255, 255, 255, 255);
    public static readonly Color32 TRANSPARENT = new Color32(0, 0, 0, 0);

    // Game Mechanics
    public const double INPUT_BUFFER_LIFESPAN = 0.15d; // Number of seconds allowed before input buffer resets
    public const int INPUT_BUFFER_MAX_LENGTH = 20; // Number of inputs to check at maximum in buffer
    public const float COLLISION_CHECK_SHRINK_OFFSET = -0.05f; // Offset to shrink collision checks to prevent false positives
    public const float COLLISION_CHECK_DISTANCE_OFFSET = 0.02f; // Distance offset for extending overlap projection to act as buffer
    public const float FRONT_CHECK_DISTANCE_CAST = 0.02f;
    public const float BACK_CHECK_DISTANCE_CAST = 0.02f;
    public const float FRONT_CHECK_FAR_DISTANCE_CAST = 0.05f;
    public const float SLOPE_CHECK_RAY_LENGTH_OFFSET = 0.06f;
    public const float FLOATING_BODY_GRAVITY_MODIFIER = 6f; // Factor to modify gravity by while floating
    public const float FLOATING_MAX_DROP_SPEED = -8f; // The max velocity a rigidbody can move at in the y plane while floating
    public const float WALL_SLIDE_MAX_DROP_SPEED = -4f;
    public const double PURE_CHARGE_UP_TIME = 2d; // Number of seconds for an action to start holding a charge
    public const double PURE_CHARGE_DOWN_TIME = 2d; // Number of seconds before a charge is lost
    public const double INPUT_CHARGE_UP_TIME = 1d; // Number of seconds for an input to start holding a charge
    public const double INPUT_CHARGE_DOWN_TIME = 0.25d; // Number of seconds before an input charge is lost

    // Input Settings
    public const float JOYSTICK_BOOL_DEADZONE = 0.7f; // Calibrate sensitivity of joysticks between 0-1 where 0 is most sensitive for boolean use

    // General Game Constants
    public const int MAX_HP = 100;

    // Player Constants
    public const double COYOTE_JUMP_DELAY = 0.05d; // Amount of time after player leaves valid state for jump where player may still jump
    public const double JUMP_BUFFER = 0.0625d; // If player jumps during invalid state, hold jump command for time JUMP_BUFFER and induce jump if valid state while buffer > 0
    public const double SLIDE_JUMP_BUFFER = 0.05d; // If player jumps in the air and was sliding immediately prior this is the allowed time where they will still perform the sliding jump
    public const double FLASH_RUN_DELAY = 3d; // Number of seconds before you start flash running.
    public const double FLASH_RUN_GRACE = 0.08d; // Number of seconds where you can stop moving yet still charge the flash
    public const double FLASH_CHARGE_HOLD_TIME = 0.5d; // Number of seconds after performing a flash where the flash charge can be held without holding crouch
    public const double COMBAT_COOLDOWN = 5d; // Time in seconds after doing an attack before character "ends" combat.
    public const int NUMBER_NORMALS = 9; // Number of normal attacks (3 standing buttons, 3 airborne, 3 crouching)
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
