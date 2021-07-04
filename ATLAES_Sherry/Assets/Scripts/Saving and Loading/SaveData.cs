
[System.Serializable] public class SaveData
{
    // World Data:
    public int worldType;
    public int finishedGame;
    public bool[] warpLocations;
    public bool[] bossesDefeated;
    public double finishGameTime;
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
        // World Data
        this.worldType = MasterManager.worldData.GetWorldType();
        this.finishedGame = MasterManager.worldData.GetFinishedGame();
        this.warpLocations = MasterManager.worldData.GetWarpLocations();
        this.bossesDefeated = MasterManager.worldData.GetBossesDefeated();
        this.finishGameTime = MasterManager.worldData.GetFinishGameTime();
        this.playTime = MasterManager.worldData.GetPlayTime();
        // Player Character Persistent Data
        this.currentHP = MasterManager.playerData.GetCurrentHP();
        this.weapons = MasterManager.playerData.GetWeapons();
        this.primaryWeapon = MasterManager.playerData.GetPrimaryWeapon();
        this.secondaryWeapon = MasterManager.playerData.GetSecondaryWeapon();
        this.locationSceneIndex = MasterManager.playerData.GetLocationSceneIndex();
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
