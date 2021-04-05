
public class PlayerCharacterPersistentData
{
    // Player Character Data
    private int currentHP = GameConstants.PLAYER_MAX_HP; // Blood (Hit Points) (HP)
    private bool[] weapons = new bool[(System.Enum.GetNames(typeof(WeaponType)).Length) - 1];
    private WeaponType primaryWeapon, secondaryWeapon = WeaponType.NONE;
    private int locationSceneIndex = GameConstants.TUTORIAL_LEVEL_INDEX;

    // Class Functions:
    public void ResetAllPlayerCharacterPersistentData()
    {
        SetCurrentHP(100);
        ResetWeapons();
        SetPrimaryWeapon(WeaponType.NONE);
        SetSecondaryWeapon(WeaponType.NONE);
        SetLocationSceneIndex(GameConstants.TUTORIAL_LEVEL_INDEX);
    }
    public int GetCurrentHP()
    {
        return currentHP;
    }
    public void SetCurrentHP(int value)
    {
        currentHP = value;
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
