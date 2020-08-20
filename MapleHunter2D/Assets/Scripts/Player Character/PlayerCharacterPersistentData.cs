
public class PlayerCharacterPersistentData
{
    // Player Character Data
    private int level = 1;
    private int currentStatPoints, totalStatPoints = 0; // Used to increase stats (HP, STR, FIN, INT, CHA)
    private int currentHP, maxHP = 100; // Blood (Hit Points) (HP)
    private int currentSTR, maxSTR = 1; // Strength
    private int currentFIN, maxFIN = 1; // Finesse
    private int currentINT, maxINT = 1; // Intelligence
    private int currentCHA, maxCHA = 1; // Charisma
    private int currentSkillPoints, totalSkillPoints = 0; // Used to learn skills (from general skill tree, vampire, and tech trees)
    private bool[] passives = new bool[System.Enum.GetNames(typeof(Passive)).Length]; // Passive skills tree (in UI broken down into general, blood (vampire), and tech tree)
    private bool[] actives = new bool[System.Enum.GetNames(typeof(UtilityType)).Length]; // Active skills tree (index = UtilityType, skipping index 0 (NONE)) (in UI: general, blood, tech)
    private int[] weapons = new int[(System.Enum.GetNames(typeof(WeaponType)).Length) - 1]; // player level (proficiency) with each weapon excluding WeaponType.NONE (index = WeaponType, value = level; 0 means weapon locked)
    private WeaponType primaryWeapon, secondaryWeapon = WeaponType.NONE;
    private UtilityType utility1, utility2 = UtilityType.NONE;
    private int locationSceneIndex = GameConstants.TUTORIAL_LEVEL_INDEX;



    // Class Functions:
    public void ResetAllPlayerCharacterPersistentData()
    {
        SetLevel(1);
        SetCurrentStatPoints(0); SetTotalStatPoints(0);
        SetCurrentHP(100); SetMaxHP(100);
        SetCurrentSTR(1); SetMaxSTR(1);
        SetCurrentFIN(1); SetMaxFIN(1);
        SetCurrentINT(1); SetMaxINT(1);
        SetCurrentCHA(1); SetMaxCHA(1);
        SetCurrentSkillPoints(0); SetTotalSkillPoints(0);
        ResetPassives();
        ResetActives();
        ResetWeapons();
        SetPrimaryWeapon(WeaponType.NONE);
        SetSecondaryWeapon(WeaponType.NONE);
        ResetUtility1();
        ResetUtility2();
        SetLocationSceneIndex(GameConstants.TUTORIAL_LEVEL_INDEX);
    }
    public int GetLevel()
    {
        return level;
    }
    public void ModifyLevel(int value)
    {
        level += value;
    }
    public void SetLevel(int value)
    {
        level = value;
    }
    public int GetCurrentStatPoints()
    {
        return currentStatPoints;
    }
    public void SetCurrentStatPoints(int value)
    {
        currentStatPoints = value;
    }
    public int GetTotalStatPoints()
    {
        return totalStatPoints;
    }
    public void SetTotalStatPoints(int value)
    {
        totalStatPoints = value;
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
    public void SetCurrentSTR(int value)
    {
        currentSTR = value;
    }
    public int GetMaxSTR()
    {
        return maxSTR;
    }
    public void SetMaxSTR(int value)
    {
        maxSTR = value;
    }
    public int GetCurrentFIN()
    {
        return currentFIN;
    }
    public void SetCurrentFIN(int value)
    {
        currentFIN = value;
    }
    public int GetMaxFIN()
    {
        return maxFIN;
    }
    public void SetMaxFIN(int value)
    {
        maxFIN = value;
    }
    public int GetCurrentINT()
    {
        return currentINT;
    }
    public void SetCurrentINT(int value)
    {
        currentINT = value;
    }
    public int GetMaxINT()
    {
        return maxINT;
    }
    public void SetMaxINT(int value)
    {
        maxINT = value;
    }
    public int GetCurrentCHA()
    {
        return currentCHA;
    }
    public void SetCurrentCHA(int value)
    {
        currentCHA = value;
    }
    public int GetMaxCHA()
    {
        return maxCHA;
    }
    public void SetMaxCHA(int value)
    {
        maxCHA = value;
    }
    public int GetCurrentSkillPoints()
    {
        return currentSkillPoints;
    }
    public void SetCurrentSkillPoints(int value)
    {
        currentSkillPoints = value;
    }
    public int GetTotalSkillPoints()
    {
        return totalSkillPoints;
    }
    public void SetTotalSkillPoints(int value)
    {
        totalSkillPoints = value;
    }
    public bool[] GetPassives()
    {
        return passives;
    }
    public void ResetPassives()
    {
        System.Array.Clear(passives, 0, passives.Length);
    }
    public bool[] GetActives()
    {
        return actives;
    }
    public void ResetActives()
    {
        System.Array.Clear(actives, 0, actives.Length);
    }
    public int[] GetWeapons()
    {
        return weapons;
    }
    public void ResetWeapons()
    {
        System.Array.Clear(weapons, 0, weapons.Length);
    }
    public WeaponType GetPrimaryWeapon()
    {
        return primaryWeapon;
    }
    public bool SetPrimaryWeapon(WeaponType weapon, bool force = false, bool modify = false)
    {
        if (weapons[(int)weapon] == 0)
        {
            if (force)
            {
                primaryWeapon = weapon;
                if (modify) // if modify is true but force is false this will NOT run
                {
                    weapons[(int)weapon] = 1;
                }
            }
            return false;
        }
        primaryWeapon = weapon;
        return true;
    }
    public WeaponType GetSecondaryWeapon()
    {
        return secondaryWeapon;
    }
    public bool SetSecondaryWeapon(WeaponType weapon, bool force = false, bool modify = false)
    {
        if (weapons[(int)weapon] == 0)
        {
            if (force)
            {
                secondaryWeapon = weapon;
                if (modify) // if modify is true but force is false this will NOT run
                {
                    weapons[(int)weapon] = 1;
                }
            }
            return false;
        }
        secondaryWeapon = weapon;
        return true;
    }
    public UtilityType GetUtility1()
    {
        return utility1;
    }
    public void ResetUtility1()
    {
        utility1 = UtilityType.NONE;
    }
    public UtilityType GetUtility2()
    {
        return utility2;
    }
    public void ResetUtility2()
    {
        utility2 = UtilityType.NONE;
    }
    public int GetLocationSceneIndex()
    {
        return locationSceneIndex;
    }
    public void SetLocationSceneIndex(int value)
    {
        locationSceneIndex = value;
    }
    private void SetPassives(bool[] array)
    {
        passives = array;
    }
    private void SetActives(bool[] array)
    {
        actives = array;
    }
    private void SetWeapons(int[] array)
    {
        weapons = array;
    }
}
