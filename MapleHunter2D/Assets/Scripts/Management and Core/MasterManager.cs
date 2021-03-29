using UnityEngine;
using UnityEngine.Audio;

public class MasterManager : MonoBehaviour
{
    // Config Parameters


    // Cached References
    [SerializeField] private AudioMixer mixer = null;

    // State Parameters and Objects:
    public static UserData userData = new UserData();
    public static WorldData worldData = new WorldData();
    public static PlayerCharacterPersistentData playerCharacterPersistentData = new PlayerCharacterPersistentData();
    public static InventoryData inventoryData = new InventoryData();
    public static NpcData npcData = new NpcData();

    public static double timeInSeconds = 0d;
    public static double fps = 0d;

    // Unity Events:
    private void Awake()
    {
        KeepPersistentStatus();
    }

    public void Update()
    {
        timeInSeconds += Time.deltaTime;
        fps = 1 / Time.deltaTime;
        //Debug.Log(fps);
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
            // World Data
            worldData.SetWarpLocations(data.warpLocations);
            worldData.SetBossesDefeated(data.bossesDefeated);
            worldData.SetPlayTime(data.playTime);
            // Player Character Persistent Data
            playerCharacterPersistentData.SetCurrentHP(data.currentHP);
            playerCharacterPersistentData.SetMaxHP(data.maxHP);
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
}
