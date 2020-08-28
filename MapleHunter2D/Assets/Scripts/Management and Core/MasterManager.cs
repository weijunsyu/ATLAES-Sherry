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

    public static PlayerCharacterNonPersistData playerCharacterNonPersistData = new PlayerCharacterNonPersistData();


    // Unity Events:
    private void Awake()
    {
        KeepPersistentStatus();
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
            playerCharacterPersistentData.SetLevel(data.level);
            playerCharacterPersistentData.SetCurrentStatPoints(data.currentStatPoints);
            playerCharacterPersistentData.SetTotalStatPoints(data.totalStatPoints);
            playerCharacterPersistentData.SetCurrentHP(data.currentHP);
            playerCharacterPersistentData.SetMaxHP(data.maxHP);
            playerCharacterPersistentData.SetCurrentSTR(data.currentSTR);
            playerCharacterPersistentData.SetMaxSTR(data.maxSTR);
            playerCharacterPersistentData.SetCurrentFIN(data.currentFIN);
            playerCharacterPersistentData.SetMaxFIN(data.maxFIN);
            playerCharacterPersistentData.SetCurrentINT(data.currentINT);
            playerCharacterPersistentData.SetMaxINT(data.maxINT);
            playerCharacterPersistentData.SetCurrentCHA(data.currentCHA);
            playerCharacterPersistentData.SetMaxCHA(data.maxCHA);
            playerCharacterPersistentData.SetCurrentSkillPoints(data.currentSkillPoints);
            playerCharacterPersistentData.SetTotalSkillPoints(data.totalSkillPoints);
            playerCharacterPersistentData.SetPassives(data.passives);
            playerCharacterPersistentData.SetActives(data.actives);
            playerCharacterPersistentData.SetWeapons(data.weapons);
            playerCharacterPersistentData.SetPrimaryWeapon(data.primaryWeapon);
            playerCharacterPersistentData.SetSecondaryWeapon(data.secondaryWeapon);
            playerCharacterPersistentData.SetUtility1(data.utility1);
            playerCharacterPersistentData.SetUtility2(data.utility2);
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
        playerCharacterNonPersistData.ResetAllPlayerCharacterNonPersistData();
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
