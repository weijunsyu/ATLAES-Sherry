using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/PlayerData")]
public class PlayerData : ScriptableObject
{
    // Persistent Data (Saved data):
    // Player Game Data
    private bool[] warpLocations; // teleports unlocked to target locations
    private bool[] bossesDefeated; // Bosses that have been defeated
    private float playTime; // Holds the total playtime of the player on this particular save
    // Player Character Data
    private int level;
    private int currentStatPoints, totalStatPoints; // Used to increase stats (HP, STR, FIN, INT, CHA)
    private int currentHP, maxHP; // Blood (Hit Points) (HP)
    private int currentSTR, maxSTR; // Strength
    private int currentFIN, maxFIN; // Finesse
    private int currentINT, maxINT; // Intelligence
    private int currentCHA, maxCHA; // Charisma
    private int currentSkillPoints, totalSkillPoints; // Used to learn skills (from general skill tree, vampire, and tech trees)
    private bool[] passives; // Passive skills tree (in UI broken down into general, blood (vampire), and tech tree)
    private bool[] actives; // Active skills tree (index = UtilityType, skipping index 0 (NONE)) (in UI: general, blood, tech)
    private int[] weapons; // player level (proficiency) with each weapon (index = WeaponType, value = level; 0 means weapon locked)
    private WeaponType primaryWeapon, secondaryWeapon;
    private UtilityType utility1, utility2;
    private int locationSceneIndex;
    // Inventory Data
    private int gold; // Number of gold coins (money) the player owns
    private bool[] uniqueItems; // Unique items unlocked (items that do not respawn and only occur once in game but are not weapons)
    private int[] inventory; // List of items in player inventory (index = ItemID, value = amount)
    // NPC and Environment Data
    private int[] bank; // List of items in bank (index = ItemID, value = amount)
    private int goldInBank; // Number of gold coins (money) the player owns in the bank
    private int[] npcConvo; // List of NPC conversation and interaction status (index = NamedNPC, value = progress along convo path)

    // Non-Persistent Data (Unsaved data):
    // Player Game Data
    // Player Character Data
    private float moveSpeed;
    private float jumpVelocity;
    private float airJumpVelocity;
    private int maxAirJumps;
    private float dashSpeed;
    private float dashDuration;
    private bool playerHasCharacterControl;
    private AnimationState animationState;
    // Inventory Data
    // NPC and Environment Data


    // Unity Events:


    // Class Functions:

    // Get, modify, and set functions for variables
    public bool[] GetWarpLocations()
    {
        return warpLocations;
    }
    public bool[] GetBossesDefeated()
    {
        return bossesDefeated;
    }
    public float GetPlayTime()
    {
        return playTime;
    }
    public int GetLevel()
    {
        return level;
    }
    public void ModifyLevel(int value)
    {
        level += value;
    }
    public int GetCurrentStatPoints()
    {
        return currentStatPoints;
    }
    public int GetTotalStatPoints()
    {
        return totalStatPoints;
    }
    public int GetCurrentHP()
    {
        return currentHP;
    }
    /* Modify currentHP by value such that currentHP = max[0, min[(currentHP + value), maxHP]].
     * Optional force tag : if set to true then current HP value can go above max HP value. */
    public void ModifyCurrentHP(int value, bool force = false)
    {
        if (force) // no max cap
        {
            currentHP = (int)StaticFunctions.ModifyResourceValue(currentHP, value);
        }
        else
        {
            currentHP = (int)StaticFunctions.ModifyResourceValue(currentHP, value, maxHP);
        }
    }
    public bool SetCurrentHP(int value)
    {
        currentHP = value;
        if (value < 0 || value > maxHP)
        {
            return false;
        }
        return true;
    }
    public int GetMaxHP()
    {
        return maxHP;
    }
    public void ModifyMaxHP(int value)
    {
        maxHP += value;
    }
    public void SetMaxHP(int value)
    {
        maxHP = value;
    }
    public int GetCurrentSTR()
    {
        return currentSTR;
    }
    public int GetMaxSTR()
    {
        return maxSTR;
    }
    public int GetCurrentFIN()
    {
        return currentFIN;
    }
    public int GetMaxFIN()
    {
        return maxFIN;
    }
    public int GetCurrentINT()
    {
        return currentINT;
    }
    public int GetMaxINT()
    {
        return maxINT;
    }
    public int GetCurrentCHA()
    {
        return currentCHA;
    }
    public int GetMaxCHA()
    {
        return maxCHA;
    }
    public int GetCurrentSkillPoints()
    {
        return currentSkillPoints;
    }
    public int GetTotalSkillPoints()
    {
        return totalSkillPoints;
    }
    public bool[] GetPassives()
    {
        return passives;
    }
    public bool[] GetActives()
    {
        return actives;
    }
    public int[] GetWeapons()
    {
        return weapons;
    }
    public WeaponType GetPrimaryWeapon()
    {
        return primaryWeapon;
    }
    public WeaponType GetSecondaryWeapon()
    {
        return secondaryWeapon;
    }
    public UtilityType GetUtility1()
    {
        return utility1;
    }
    public UtilityType GetUtility2()
    {
        return utility2;
    }
    public int GetLocationSceneIndex()
    {
        return locationSceneIndex;
    }
    public int GetGold()
    {
        return gold;
    }
    public bool[] GetUniqueItems()
    {
        return uniqueItems;
    }
    public int[] GetInventory()
    {
        return inventory;
    }
    public int[] GetBank()
    {
        return bank;
    }
    public int GetGoldInBank()
    {
        return goldInBank;
    }
    public int[] GetNpcConvo()
    {
        return npcConvo;
    }
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
    public void ModifyMoveSpeed(float value)
    {
        moveSpeed = StaticFunctions.ModifyResourceValue(moveSpeed, value);
    }
    public bool SetMoveSpeed(float value)
    {
        moveSpeed = value;
        if (value < 0)
        {
            return false;
        }
        return true;
    }
    public float GetJumpVelocity()
    {
        return jumpVelocity;
    }
    public void ModifyJumpVelocity(float value)
    {
        jumpVelocity = StaticFunctions.ModifyResourceValue(jumpVelocity, value);
    }
    public void SetJumpVelocity(float value)
    {
        jumpVelocity = value;
    }
    public float GetAirJumpVelocity()
    {
        return airJumpVelocity;
    }
    public void ModifyAirJumpVelocity(float value)
    {
        airJumpVelocity = StaticFunctions.ModifyResourceValue(airJumpVelocity, value);
    }
    public bool SetAirJumpVelocity(float value)
    {
        airJumpVelocity = value;
        if (value < 0)
        {
            return false;
        }
        return true;
    }
    public int GetMaxAirJumps()
    {
        return maxAirJumps;
    }
    public float GetDashSpeed()
    {
        return dashSpeed;
    }
    public void ModifyDashSpeed(float value)
    {
        dashSpeed = StaticFunctions.ModifyResourceValue(dashSpeed, value);
    }
    public bool SetDashSpeed(float value)
    {
        dashSpeed = value;
        if (value < 0)
        {
            return false;
        }
        return true;
    }
    public float GetDashDuration()
    {
        return dashDuration;
    }
    public void ModifyDashDuration(float value)
    {
        dashDuration = StaticFunctions.ModifyResourceValue(dashDuration, value);
    }
    public bool SetDashDuration(float value)
    {
        dashDuration = value;
        if (value < 0)
        {
            return false;
        }
        return true;
    }
    public bool GetPlayerHasCharacterControl()
    {
        return playerHasCharacterControl;
    }
    public AnimationState GetAnimationState()
    {
        return animationState;
    }


    // Saving and Loading Wrapper Fuctionality
    public void SaveGame(int saveNumber)
    {
        SaveSystem.SavePlayerData(this, saveNumber);
    }
    public void ResetGame()
    {
        warpLocations = new bool[GameConstants.TOTAL_NUMBER_WARP_LOCATIONS];
        bossesDefeated = new bool[GameConstants.TOTAL_NUMBER_BOSSES];
        playTime = 0;

        level = 1;
        currentStatPoints = totalStatPoints = 0;
        currentHP = maxHP = 100;
        currentSTR = maxSTR = 1;
        currentFIN = maxFIN = 1;
        currentINT = maxINT = 1;
        currentCHA = maxCHA = 1;
        currentSkillPoints = totalSkillPoints = 0;
        passives = new bool[System.Enum.GetNames(typeof(Passive)).Length];
        actives = new bool[System.Enum.GetNames(typeof(UtilityType)).Length];
        weapons = new int[System.Enum.GetNames(typeof(WeaponType)).Length]; weapons[(int)WeaponType.UNARMED] = 1;
        primaryWeapon = WeaponType.UNARMED;
        secondaryWeapon = WeaponType.UNARMED;
        utility1 = UtilityType.NONE;
        utility2 = UtilityType.NONE;
        locationSceneIndex = GameConstants.TUTORIAL_LEVEL_INDEX;

        gold = 0;
        uniqueItems = new bool[GameConstants.TOTAL_NUMBER_UNIQUE_ITEMS];
        inventory = new int[GameConstants.PLAYER_INVENTORY_SIZE];

        bank = new int[GameConstants.PLAYER_BANK_SIZE];
        goldInBank = 0;
        npcConvo = new int[System.Enum.GetNames(typeof(NamedNPC)).Length];

        moveSpeed = GameConstants.PLAYER_BASE_STAND_MOVE_SPEED;
        jumpVelocity = GameConstants.PLAYER_BASE_GROUND_JUMP_VELOCITY;
        airJumpVelocity = GameConstants.PLAYER_BASE_AIR_JUMP_VELOCITY;
        maxAirJumps = GameConstants.PLAYER_BASE_AIR_JUMP_NUMBER;
        dashSpeed = GameConstants.PLAYER_BASE_DASH_SPEED;
        dashDuration = GameConstants.PLAYER_BASE_DASH_DURATION;
        playerHasCharacterControl = true;
        animationState = AnimationState.IDLE;
}

    // Return true if load successful, false otherwise
    public bool LoadGame(int saveNumber)
    {
        SaveData data = SaveSystem.LoadPlayerData(saveNumber);

        if (data != null) //savefile exists
        {
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
            this.weapons = data.weapons;
            this.inventory = data.inventory;

            this.bank = data.bank;
            this.goldInBank = data.goldInBank;
            this.npcConvo = data.npcConvo;

            return true;
        }
        else //savefile does not exist
        {
            return false;
        }
    }
}
