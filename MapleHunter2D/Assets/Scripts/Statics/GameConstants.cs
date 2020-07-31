
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
    public const float IS_AIRBORNE_CHECK_BOX_X_OFFSET = -0.05f; // Width offset for checking if character is airborne
    public const float IS_AIRBORNE_CHECK_BOX_Y_OFFSET = 0.5f; // Height offset for checking if character is airborne
    public const float DIRECTIONAL_BOX_OFFSET = 0.05f; // Offset for diretion collision checks

    // Input Settings
    public const float AIM_ATTACK_JOYSTICK_MIN_MAGNITUDE = 0.7f; // Calibrate sensitivity of Aim Attack between 0-1 where 0 is most sensitive
}
