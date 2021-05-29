using UnityEngine;
using UnityEngine.Audio;

public class MasterManager : MonoBehaviour
{
    // Config Parameters

    // Cached References
    [SerializeField] private AudioMixer mixer = null;

    // State Parameters and Objects:
    [HideInInspector] public static UserData userData = new UserData();
    [HideInInspector] public static WorldData worldData = new WorldData();
    [HideInInspector] public static PlayerCharacterPersistentData playerCharacterPersistentData = new PlayerCharacterPersistentData();
    [HideInInspector] public static InventoryData inventoryData = new InventoryData();
    [HideInInspector] public static NpcData npcData = new NpcData();

    public static double timeInSeconds = 0d;
    public static double fps = 0d;


    // Unity Events:
    private void Awake()
    {
        KeepPersistentStatus();
        
        // Clamp the min window size on Windows platform.
        MinimumWindowSize.Set(GameConstants.MIN_WINDOW_WIDTH, GameConstants.MIN_WINDOW_HEIGHT);
    }
    private void Start()
    {
        // Set the framerate to match the default framerate of target platform (monitor refresh rate)
        QualitySettings.vSyncCount = 1;
        // Set the max framerate to be unlimited
        Application.targetFrameRate = -1;

        /* START DEBUGGING */
        ResetAll();
        playerCharacterPersistentData.SetPrimaryWeapon(WeaponType.NONE, true, true);
        playerCharacterPersistentData.SetSecondaryWeapon(WeaponType.UNARMED, true, true);
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
    }

    private void OnDisable()
    {
        // Disable player controller
        PlayerInputController.OnInputEvent -= HandleInput;
    }

    private void OnApplicationQuit()
    {
        MinimumWindowSize.Reset();
    }


        // Class Functions:

        // Saving and Loading Wrapper Fuctionality
        public void SaveGame(int saveNumber)
    {
        SaveSystem.SavePlayerData(saveNumber);
    }
    // Return true if load successful, false otherwise
    public bool LoadGame(int saveNumber)
    {
        SaveData data = SaveSystem.LoadPlayerData(saveNumber);

        if (data != null) //savefile exists
        {
            // User Data
            userData.SetIsFullscreen(data.isFullscreen);
            // World Data
            worldData.SetWarpLocations(data.warpLocations);
            worldData.SetBossesDefeated(data.bossesDefeated);
            worldData.SetPlayTime(data.playTime);
            // Player Character Persistent Data
            playerCharacterPersistentData.SetCurrentHP(data.currentHP);
            playerCharacterPersistentData.SetWeapons(data.weapons);
            playerCharacterPersistentData.SetPrimaryWeapon(data.primaryWeapon);
            playerCharacterPersistentData.SetSecondaryWeapon(data.secondaryWeapon);
            playerCharacterPersistentData.SetLocationSceneIndex(data.locationSceneIndex);
            // Inventory Data
            inventoryData.SetGold(data.gold);
            inventoryData.SetUniqueItems(data.uniqueItems);
            inventoryData.SetInventory(data.inventory);
            // NPC Data
            npcData.SetBank(data.bank);
            npcData.SetGoldInBank(data.goldInBank);
            npcData.SetNpcConvo(data.npcConvo);

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
        playerCharacterPersistentData.ResetAllPlayerCharacterPersistentData();
        inventoryData.ResetAllInventoryData();
        npcData.ResetAllNpcData();
    }
    public void ResetUser()
    {
        userData.ResetAllUserData();
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
                userData.SetAndRunIsFullscreen(!userData.GetIsFullscreen());
                
                break;
        }
    }
}
