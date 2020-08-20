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

    public static PlayerCharacterStateData playerCharacterStateData = new PlayerCharacterStateData();
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
        SaveSystem.SavePlayerData(this, saveNumber);
    }
    public void ResetGame()
    {
        worldData.ResetAllWorldData();
        playerCharacterPersistentData.ResetAllPlayerCharacterPersistentData();
        inventoryData.ResetAllInventoryData();
        npcData.ResetAllNpcData();
        playerCharacterNonPersistData.ResetAllPlayerCharacterNonPersistData();
        playerCharacterStateData.ResetAllPlayerCharacterStateData();
    }

    // Return true if load successful, false otherwise
    public bool LoadGame(int saveNumber)
    {
        SaveData data = SaveSystem.LoadPlayerData(saveNumber);

        if (data != null) //savefile exists
        {
            /*
            this.warpLocations = data.warpLocations;
            this.bossesDefeated = data.bossesDefeated;
            this.playTime = data.playTime;

            this.level = data.level;
            this.currentStatPoints = data.currentStatPoints; this.totalStatPoints = data.totalStatPoints;
            this.currentHP = data.currentHP; this.maxHP = data.maxHP;
            this.currentSTR = data.currentSTR; this.maxSTR = data.maxSTR;
            this.currentFIN = data.currentFIN; this.maxFIN = data.maxFIN;
            this.currentINT = data.currentINT; this.maxINT = data.maxINT;
            this.currentCHA = data.currentCHA; this.maxCHA = data.maxCHA;
            this.currentSkillPoints = data.currentSkillPoints; this.totalSkillPoints = data.totalSkillPoints;
            this.passives = data.passives;
            this.actives = data.actives;
            this.weapons = data.weapons;
            this.primaryWeapon = data.primaryWeapon;
            this.secondaryWeapon = data.secondaryWeapon;
            this.utility1 = data.utility1;
            this.utility2 = data.utility2;
            this.locationSceneIndex = data.locationSceneIndex;

            this.gold = data.gold;
            this.uniqueItems = data.uniqueItems;
            this.inventory = data.inventory;

            this.bank = data.bank;
            this.goldInBank = data.goldInBank;
            this.npcConvo = data.npcConvo;
            */

            return true;
        }
        else //savefile does not exist
        {
            return false;
        }
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
