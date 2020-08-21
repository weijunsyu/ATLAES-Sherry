
using System.Collections.Generic;

[System.Serializable] public class SaveData
{
    // User Data:

    // World Data:
    public bool[] warpLocations;
    public bool[] bossesDefeated;
    public float playTime;
    // Player Character Persistent Data:
    public int level;
    public int currentStatPoints, totalStatPoints;
    public int currentHP, maxHP;
    public int currentSTR, maxSTR;
    public int currentFIN, maxFIN;
    public int currentINT, maxINT;
    public int currentCHA, maxCHA;
    public int currentSkillPoints, totalSkillPoints;
    public bool[] passives;
    public bool[] actives;
    public int[] weapons;
    public WeaponType primaryWeapon, secondaryWeapon;
    public UtilityType utility1, utility2;
    public int locationSceneIndex;
    // Inventory Data
    public int gold;
    public bool[] uniqueItems;
    public int[] inventory;
    // NPC Data
    public int[] bank;
    public int goldInBank;
    public int[] npcConvo;


    //constructor
    public SaveData()
    {
        // World Data
        this.warpLocations = MasterManager.worldData.GetWarpLocations();
        this.bossesDefeated = MasterManager.worldData.GetBossesDefeated();
        this.playTime = MasterManager.worldData.GetPlayTime();
        // Player Character Persistent Data
        this.level = MasterManager.playerCharacterPersistentData.GetLevel();
        this.currentStatPoints = MasterManager.playerCharacterPersistentData.GetCurrentStatPoints();
        this.totalStatPoints = MasterManager.playerCharacterPersistentData.GetTotalStatPoints();
        this.currentHP = MasterManager.playerCharacterPersistentData.GetCurrentHP();
        this.maxHP = MasterManager.playerCharacterPersistentData.GetMaxHP();
        this.currentSTR = MasterManager.playerCharacterPersistentData.GetCurrentSTR();
        this.maxSTR = MasterManager.playerCharacterPersistentData.GetMaxSTR();
        this.currentFIN = MasterManager.playerCharacterPersistentData.GetCurrentFIN();
        this.maxFIN = MasterManager.playerCharacterPersistentData.GetMaxFIN();
        this.currentINT = MasterManager.playerCharacterPersistentData.GetCurrentINT();
        this.maxINT = MasterManager.playerCharacterPersistentData.GetMaxINT();
        this.currentCHA = MasterManager.playerCharacterPersistentData.GetCurrentCHA();
        this.maxCHA = MasterManager.playerCharacterPersistentData.GetMaxCHA();
        this.currentSkillPoints = MasterManager.playerCharacterPersistentData.GetCurrentSkillPoints();
        this.totalSkillPoints = MasterManager.playerCharacterPersistentData.GetTotalSkillPoints();
        this.passives = MasterManager.playerCharacterPersistentData.GetPassives();
        this.actives = MasterManager.playerCharacterPersistentData.GetActives();
        this.weapons = MasterManager.playerCharacterPersistentData.GetWeapons();
        this.primaryWeapon = MasterManager.playerCharacterPersistentData.GetPrimaryWeapon();
        this.secondaryWeapon = MasterManager.playerCharacterPersistentData.GetSecondaryWeapon();
        this.utility1 = MasterManager.playerCharacterPersistentData.GetUtility1();
        this.utility2 = MasterManager.playerCharacterPersistentData.GetUtility2();
        this.locationSceneIndex = MasterManager.playerCharacterPersistentData.GetLocationSceneIndex();
        // Inventory Data
        this.gold = MasterManager.inventoryData.GetGold();
        this.uniqueItems = MasterManager.inventoryData.GetUniqueItems();
        this.inventory = MasterManager.inventoryData.GetInventory();
        // NPC Data
        this.bank = MasterManager.npcData.GetBank();
        this.goldInBank = MasterManager.npcData.GetGoldInBank();
        this.npcConvo = MasterManager.npcData.GetNpcConvo();
    }
}
