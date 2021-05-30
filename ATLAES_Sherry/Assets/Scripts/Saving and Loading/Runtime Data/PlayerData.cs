public class PlayerData
{
    // Player Character Data
    private int currentHP = GameConstants.MAX_HP; // Blood (Hit Points) (HP)
    private bool[] weapons = new bool[(System.Enum.GetNames(typeof(WeaponType)).Length)];
    private WeaponType primaryWeapon, secondaryWeapon = WeaponType.NONE;
    private int locationSceneIndex = GameConstants.TUTORIAL_LEVEL_INDEX;

    // Class Functions:
    public void ResetAllPlayerCharacterPersistentData()
    {
        SetCurrentHP(GameConstants.MAX_HP);
        ResetWeapons();
        SetPrimaryWeapon(WeaponType.NONE);
        SetSecondaryWeapon(WeaponType.NONE);
        SetLocationSceneIndex(GameConstants.TUTORIAL_LEVEL_INDEX);
    }
    public int GetCurrentHP()
    {
        return currentHP;
    }
    // Modify currentHP by value such that currentHP = max[0, min[(currentHP + value), maxHP]].
    public void ModifyCurrentHP(int value)
    {
        currentHP = (int)StaticFunctions.ModifyResourceValue(currentHP, value, GameConstants.MAX_HP);
    }
    public void SetCurrentHP(int value)
    {
        if (value < 0)
        {
            value = 0;
        }
        else if (value > GameConstants.MAX_HP)
        {
            value = GameConstants.MAX_HP;
        }
        currentHP = value;
    }
    public bool[] GetWeapons()
    {
        return weapons;
    }
    public void AddWeapons(params WeaponType[] weapons)
    {
        foreach (WeaponType weapon in weapons)
        {
            this.weapons[(int)weapon] = true;
        }
    }
    public void ResetWeapons()
    {
        System.Array.Clear(weapons, 0, weapons.Length);
        weapons[0] = true;
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
    public void SwapWeapons()
    {
        WeaponType oldPrimary = GetPrimaryWeapon();
        WeaponType oldSecondary = GetSecondaryWeapon();

        SetPrimaryWeapon(oldSecondary);
        SetSecondaryWeapon(oldPrimary);
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
