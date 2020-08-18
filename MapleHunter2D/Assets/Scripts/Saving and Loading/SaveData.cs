
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
    public SaveData(PlayerData playerData)
    {
        //get all paramaters from playerData
        this.warpLocations = playerData.GetWarpLocations();
        this.bossesDefeated = playerData.GetBossesDefeated();
        this.playTime = playerData.GetPlayTime();

        this.level = playerData.GetLevel();
        this.currentStatPoints = playerData.GetCurrentStatPoints(); this.totalStatPoints = playerData.GetTotalStatPoints();
        this.currentHP = playerData.GetCurrentHP(); this.maxHP = playerData.GetMaxHP();
        this.currentSTR = playerData.GetCurrentSTR(); this.maxSTR = playerData.GetMaxSTR();
        this.currentFIN = playerData.GetCurrentFIN(); this.maxFIN = playerData.GetMaxFIN();
        this.currentINT = playerData.GetCurrentINT(); this.maxINT = playerData.GetMaxINT();
        this.currentCHA = playerData.GetCurrentCHA(); this.maxCHA = playerData.GetMaxCHA();
        this.currentSkillPoints = playerData.GetCurrentSkillPoints(); this.totalSkillPoints = playerData.GetTotalSkillPoints();
        this.passives = playerData.GetPassives();
        this.actives = playerData.GetActives();
        this.weapons = playerData.GetWeapons();
        this.primaryWeapon = playerData.GetPrimaryWeapon();
        this.secondaryWeapon = playerData.GetSecondaryWeapon();
        this.utility1 = playerData.GetUtility1();
        this.utility2 = playerData.GetUtility2();
        this.locationSceneIndex = playerData.GetLocationSceneIndex();

        this.gold = playerData.GetGold();
        this.uniqueItems = playerData.GetUniqueItems();
        this.inventory = playerData.GetInventory();

        this.bank = playerData.GetBank();
        this.goldInBank = playerData.GetGoldInBank();
        this.npcConvo = playerData.GetNpcConvo();
    }
}
