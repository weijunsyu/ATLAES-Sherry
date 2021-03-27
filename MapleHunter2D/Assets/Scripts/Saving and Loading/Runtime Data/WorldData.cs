
public class WorldData
{
    // Player Game Data
    private bool[] warpLocations = new bool[GameConstants.TOTAL_NUMBER_WARP_LOCATIONS]; // teleports unlocked to target locations
    private bool[] bossesDefeated = new bool[GameConstants.TOTAL_NUMBER_BOSSES]; // Bosses that have been defeated
    private double playTime = 0; // Holds the total playtime of the player on this particular save


    // Class Functions:
    public void ResetAllWorldData()
    {
        ResetWarpLocations();
        ResetBossesDefeated();
        ResetPlayTime();
    }
    public bool[] GetWarpLocations()
    {
        return warpLocations;
    }
    public bool ModifyWarpLocation(int index, bool value = true)
    {
        if (warpLocations[index] == value)
        {
            return false;
        }
        warpLocations[index] = value;
        return true;
    }
    public void ResetWarpLocations()
    {
        System.Array.Clear(warpLocations, 0, warpLocations.Length);
    }
    public bool[] GetBossesDefeated()
    {
        return bossesDefeated;
    }
    public bool SetWarpLocations(bool[] array)
    {
        if(array.Length == warpLocations.Length)
        {
            System.Array.Copy(array, warpLocations, warpLocations.Length);
            return true;
        }
        return false;
    }
    public bool ModifyBossesDefeated(int index, bool value = true)
    {
        if (bossesDefeated[index] == value)
        {
            return false;
        }
        bossesDefeated[index] = value;
        return true;
    }
    public void ResetBossesDefeated()
    {
        System.Array.Clear(bossesDefeated, 0, bossesDefeated.Length);
    }
    public bool SetBossesDefeated(bool[] array)
    {
        if (array.Length == bossesDefeated.Length)
        {
            System.Array.Copy(array, bossesDefeated, bossesDefeated.Length);
            return true;
        }
        return false;
    }
    public double GetPlayTime()
    {
        return playTime;
    }
    public void AddToPlayTime(double valueToAdd)
    {
        playTime += valueToAdd;
    }
    public void ResetPlayTime()
    {
        playTime = 0;
    }
    public void SetPlayTime(double newPlayTime)
    {
        playTime = newPlayTime;
    }
}
