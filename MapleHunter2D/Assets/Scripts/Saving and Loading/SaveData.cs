
using System.Collections.Generic;

[System.Serializable] public class SaveData
{
    //Player Game Data:
    public bool[] warpLocations;
    public bool[] bossesDefeated;
    public float playTime;
    // Player Character Data:
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
    // NPC and Environment Data
    public int[] bank;
    public int goldInBank;
    public int[] npcConvo;


    //constructor
    public SaveData(MasterManager saveData)
    {
        //get all paramaters from playerData
        /*
        this.warpLocations = saveData.GetWarpLocations();
        this.bossesDefeated = saveData.GetBossesDefeated();
        this.playTime = saveData.GetPlayTime();

        this.level = saveData.GetLevel();
        this.currentStatPoints = saveData.GetCurrentStatPoints(); this.totalStatPoints = saveData.GetTotalStatPoints();
        this.currentHP = saveData.GetCurrentHP(); this.maxHP = saveData.GetMaxHP();
        this.currentSTR = saveData.GetCurrentSTR(); this.maxSTR = saveData.GetMaxSTR();
        this.currentFIN = saveData.GetCurrentFIN(); this.maxFIN = saveData.GetMaxFIN();
        this.currentINT = saveData.GetCurrentINT(); this.maxINT = saveData.GetMaxINT();
        this.currentCHA = saveData.GetCurrentCHA(); this.maxCHA = saveData.GetMaxCHA();
        this.currentSkillPoints = saveData.GetCurrentSkillPoints(); this.totalSkillPoints = saveData.GetTotalSkillPoints();
        this.passives = saveData.GetPassives();
        this.actives = saveData.GetActives();
        this.weapons = saveData.GetWeapons();
        this.primaryWeapon = saveData.GetPrimaryWeapon();
        this.secondaryWeapon = saveData.GetSecondaryWeapon();
        this.utility1 = saveData.GetUtility1();
        this.utility2 = saveData.GetUtility2();
        this.locationSceneIndex = saveData.GetLocationSceneIndex();

        this.gold = saveData.GetGold();
        this.uniqueItems = saveData.GetUniqueItems();
        this.inventory = saveData.GetInventory();

        this.bank = saveData.GetBank();
        this.goldInBank = saveData.GetGoldInBank();
        this.npcConvo = saveData.GetNpcConvo();
        */
    }
}
