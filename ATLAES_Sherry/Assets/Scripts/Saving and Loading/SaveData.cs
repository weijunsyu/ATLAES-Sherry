
[System.Serializable] public class SaveData
{
    // User Data:
    public bool isFullscreen;

    // World Data:
    public bool[] warpLocations;
    public bool[] bossesDefeated;
    public double playTime;
    // Player Character Persistent Data:
    public int currentHP;
    public bool[] weapons;
    public WeaponType primaryWeapon, secondaryWeapon;
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
        // User Data
        this.isFullscreen = MasterManager.userData.GetIsFullscreen();
        // World Data
        this.warpLocations = MasterManager.worldData.GetWarpLocations();
        this.bossesDefeated = MasterManager.worldData.GetBossesDefeated();
        this.playTime = MasterManager.worldData.GetPlayTime();
        // Player Character Persistent Data
        this.currentHP = MasterManager.playerCharacterPersistentData.GetCurrentHP();
        this.weapons = MasterManager.playerCharacterPersistentData.GetWeapons();
        this.primaryWeapon = MasterManager.playerCharacterPersistentData.GetPrimaryWeapon();
        this.secondaryWeapon = MasterManager.playerCharacterPersistentData.GetSecondaryWeapon();
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
