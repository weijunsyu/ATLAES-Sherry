
public class PlayerCharacterPersistentData
{
    // Player Character Data
    private int currentHP, maxHP = 100; // Blood (Hit Points) (HP)
    private bool[] weapons = new bool[(System.Enum.GetNames(typeof(WeaponType)).Length) - 1];
    private WeaponType primaryWeapon, secondaryWeapon = WeaponType.NONE;
    private int locationSceneIndex = GameConstants.TUTORIAL_LEVEL_INDEX;



    // Class Functions:
    public void ResetAllPlayerCharacterPersistentData()
    {
        SetCurrentHP(100); SetMaxHP(100);
        ResetWeapons();
        SetPrimaryWeapon(WeaponType.NONE);
        SetSecondaryWeapon(WeaponType.NONE);
        SetLocationSceneIndex(GameConstants.TUTORIAL_LEVEL_INDEX);
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
    public bool[] GetWeapons()
    {
        return weapons;
    }
    public void ResetWeapons()
    {
        System.Array.Clear(weapons, 0, weapons.Length);
    }
    public bool SetWeapons(bool[] array)
    {
        if (array.Length == weapons.Length)
        {
            System.Array.Copy(array, weapons, weapons.Length);
            return true;
        }
        return false;
    }
    public WeaponType GetPrimaryWeapon()
    {
        return primaryWeapon;
    }
    public bool SetPrimaryWeapon(WeaponType weapon, bool force = false, bool modify = false)
    {
        if (weapons[(int)weapon] == false)
        {
            if (force)
            {
                primaryWeapon = weapon;
                if (modify) // if modify is true but force is false this will NOT run
                {
                    weapons[(int)weapon] = true;
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
        if (weapons[(int)weapon] == false)
        {
            if (force)
            {
                secondaryWeapon = weapon;
                if (modify) // if modify is true but force is false this will NOT run
                {
                    weapons[(int)weapon] = true;
                }
            }
            return false;
        }
        secondaryWeapon = weapon;
        return true;
    }
    public int GetLocationSceneIndex()
    {
        return locationSceneIndex;
    }
    public void SetLocationSceneIndex(int value)
    {
        locationSceneIndex = value;
    }
}
