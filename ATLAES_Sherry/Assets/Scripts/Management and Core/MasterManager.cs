using UnityEngine;
using UnityEngine.Audio;

public enum GameMode
{
    Singleplayer,
    LocalMultiplayer,
    OnlineMultiplayer
}


public class MasterManager : MonoBehaviour
{
    // Config Parameters

    // Cached References
    [SerializeField] public AudioMixer mixer = null;
    
    [SerializeField] private Canvas utilityOverlay = null;

    // State Parameters and Objects:
    // Persistent Data
    [HideInInspector] public static UserData userData = new UserData();
    [HideInInspector] public static WorldData worldData = new WorldData();
    [HideInInspector] public static PlayerData playerData = new PlayerData();
    [HideInInspector] public static InventoryData inventoryData = new InventoryData();
    [HideInInspector] public static NpcData npcData = new NpcData();
    // Non-Persistent Data
    public static int playerHP = 0;
    public static int playerRecoverableHP = 0;
    public static int otherHP = 0;
    public static int otherRecoverableHP = 0;

    // General Game Parameters
    public static double timeInSeconds = 0d;
    public static double playTimeInSeconds = 0d;
    public static bool startTimingGameplay = false;
    public static double fps = 0d;
    public static GameMode gameMode = GameMode.Singleplayer;
    public static double ping = 0d; // ping in ms


    // Unity Events:
    private void Awake() // Called on every new scene which has its own Master Manager
    {
        KeepPersistentStatus();
        // Clamp the min window size on Windows platform.
        MinimumWindowSize.Set(GameConstants.MIN_WINDOW_WIDTH, GameConstants.MIN_WINDOW_HEIGHT);
    }
    private void Start()
    {
        LoadSettings();
        
        /* START DEBUGGING */
        ResetGame();
        playerData.SetPrimaryWeapon(WeaponType.NONE, true, true);
        playerData.SetSecondaryWeapon(WeaponType.UNARMED, true, true);
        /* END DEBUGGING */
    }

    private void OnEnable()
    {
        // Enable player controller
        PlayerInputController.OnInputEvent += HandleInput;
    }

    public void Update()
    {
        timeInSeconds += Time.deltaTime;
        fps = 1 / Time.deltaTime;
        
        if (startTimingGameplay)
        {
            playTimeInSeconds += Time.deltaTime;
        }

        if (gameMode == GameMode.Singleplayer)
        {
            if (userData.GetGameTimer())
            {
                HUDLogic.SetHudTimerText(playTimeInSeconds, false);
            }
        }
        

        /* START DEBUGGING */
        
        /* END DEBUGGING */
    }

    private void OnDisable()
    {
        // Disable player controller
        PlayerInputController.OnInputEvent -= HandleInput;
    }

    private void OnApplicationQuit()
    {
        if (!userData.GetIsFullscreen())
        {
            userData.SetWindowWidth(Screen.width);
            userData.SetWindowHeight(Screen.height);
        }
        SaveSettings();

        MinimumWindowSize.Reset();
    }
    // Class Functions:

    public void ToggleUtilityOverlay(bool value)
    {
        userData.SetUtilityOverlayOn(value);
        utilityOverlay.enabled = value;
    }

    // Saving and Loading of User data
    // which remembers default users settings to be enabled during startup
    public static void SaveSettings()
    {
        SaveSystem.SaveSettingsData();
    }
    public bool LoadSettings()
    {
        SettingsData settings = SaveSystem.LoadSettingsData();

        if (settings != null)
        {
            // User Data
            userData.SetIsFullscreen(settings.isFullScreen);
            userData.SetWindowWidth(settings.windowWidth);
            userData.SetWindowHeight(settings.windowHeight);
            userData.SetUtilityOverlayOn(settings.utilityOverlayOn);
            userData.SetVSync(settings.vSync);
            userData.SetTargetFPS(settings.targetFPS);
            userData.SetMenuAlphaMask(settings.menuAlphaMask);
            userData.SetIsMinimalist(settings.isMinimalist);
            userData.SetMenuProgression(settings.menuProgression);
            userData.SetMasterVolume(settings.masterVolume);
            userData.SetMusicVolume(settings.musicVolume);
            userData.SetEffectsVolume(settings.effectsVolume);
            userData.SetGameTimer(settings.gameTimer);
            userData.SetSkipCutscenes(settings.skipCutscenes);
            userData.SetEqualLoadTimes(settings.equalLoadTimes);

            //Run the loaded settings immediate
            userData.RunAllUserData();
            ToggleUtilityOverlay(userData.GetUtilityOverlayOn());

            return true;
        }
        else
        {
            SaveSettings();
            return false;
        }
    }

    // Saving and Loading Wrapper Fuctionality
    public static void SaveGame(int saveNumber)
    {
        SaveSystem.SavePlayerData(saveNumber);
    }
    // Return true if load successful, false otherwise
    public bool LoadGame(int saveNumber)
    {
        SaveData data = SaveSystem.LoadPlayerData(saveNumber);

        if (data != null) //savefile exists
        {
            // World Data
            worldData.SetWarpLocations(data.warpLocations);
            worldData.SetBossesDefeated(data.bossesDefeated);
            worldData.SetPlayTime(data.playTime);
            // Player Data
            playerData.SetCurrentHP(data.currentHP);
            playerData.SetWeapons(data.weapons);
            playerData.SetPrimaryWeapon(data.primaryWeapon);
            playerData.SetSecondaryWeapon(data.secondaryWeapon);
            playerData.SetLocationSceneIndex(data.locationSceneIndex);
            // Inventory Data
            inventoryData.SetGold(data.gold);
            inventoryData.SetUniqueItems(data.uniqueItems);
            inventoryData.SetInventory(data.inventory);
            // NPC Data
            npcData.SetBank(data.bank);
            npcData.SetGoldInBank(data.goldInBank);
            npcData.SetNpcConvo(data.npcConvo);

            // Load non-persistent from data
            playerHP = playerData.GetCurrentHP();
            playerRecoverableHP = playerHP;

            return true;
        }
        else //savefile does not exist
        {
            return false;
        }
    }
    public void ResetGame()
    {
        worldData.ResetAllWorldData();
        playerData.ResetAllPlayerCharacterPersistentData();
        inventoryData.ResetAllInventoryData();
        npcData.ResetAllNpcData();
    }
    public void ResetUser()
    {
        userData.ResetAllUserData();
        utilityOverlay.enabled = userData.GetUtilityOverlayOn();
    }
    public void ResetAll()
    {
        ResetGame();
        ResetUser();
    }

    private void KeepPersistentStatus()
    {
        int gameStatusCount = FindObjectsOfType<MasterManager>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void HandleInput(object sender, InputEventArgs inputEvent)
    {
        switch (inputEvent.input)
        {
            case PlayerInputController.RawInput.PAUSE:
                Debug.Log("pause pressed, detected in Master Manager");

                //DEBUGGING:
                userData.SetIsFullscreen(!userData.GetIsFullscreen());
                userData.RunIsFullscreen();
                
                break;
        }
    }
}
