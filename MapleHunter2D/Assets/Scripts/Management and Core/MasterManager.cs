using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/MasterManager")]
public class MasterManager : SingletonScriptableObject<MasterManager>
{
    //Definitions:

    // Config Parameters:

    // Cached References:
    [SerializeField] private UserData _userData;
    [SerializeField] private WorldData _worldData;
    [SerializeField] private PlayerCharacterPersistentData _playerCharacterPersistentData;
    [SerializeField] private PlayerCharacterStateData _playerCharacterStateData;
    [SerializeField] private InventoryData _inventoryData;
    [SerializeField] private NpcData _npcData;
    [SerializeField] private PlayerCharacterNonPersistData _playerCharacterNonPersistData;

    // State Parameters and Objects
    public static UserData UserData { get { return Instance._userData; } }
    public static WorldData WorldData { get { return Instance._worldData; } }
    public static PlayerCharacterPersistentData PlayerCharacterPersistentData { get { return Instance._playerCharacterPersistentData; } }
    public static PlayerCharacterStateData PlayerCharacterStateData { get { return Instance._playerCharacterStateData; } }
    public static InventoryData InventoryData { get { return Instance._inventoryData; } }
    public static NpcData NpcData { get { return Instance._npcData; } }
    public static PlayerCharacterNonPersistData PlayerCharacterNonPersistData { get { return Instance._playerCharacterNonPersistData; } }









    // Saving and Loading Wrapper Fuctionality
    public void SaveGame(int saveNumber)
    {
        SaveSystem.SavePlayerData(this, saveNumber);
    }
    public void ResetGame()
    {
        WorldData.ResetAllWorldData();
        PlayerCharacterPersistentData.ResetAllPlayerCharacterPersistentData();
        InventoryData.ResetAllInventoryData();
        NpcData.ResetAllNpcData();
        PlayerCharacterNonPersistData.ResetAllPlayerCharacterNonPersistData();
        PlayerCharacterStateData.ResetAllPlayerCharacterStateData();
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
}
