using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/WorldData")]
public class WorldData : ScriptableObject
{
    // Player Game Data
    private bool[] warpLocations = new bool[GameConstants.TOTAL_NUMBER_WARP_LOCATIONS]; // teleports unlocked to target locations
    private bool[] bossesDefeated = new bool[GameConstants.TOTAL_NUMBER_BOSSES]; // Bosses that have been defeated
    private float playTime = 0; // Holds the total playtime of the player on this particular save

    // Unity Events:
    private void Awake()
    {
        ResetAllWorldData();
    }

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
    public float GetPlayTime()
    {
        return playTime;
    }
    public void AddToPlayTime(float valueToAdd)
    {
        playTime += valueToAdd;
    }
    public void ResetPlayTime()
    {
        playTime = 0;
    }
    private void SetWarpLocations(bool[] newWarpLocations)
    {
        warpLocations = newWarpLocations;
    }
    private void SetBossesDefeated(bool[] newBossesDefeated)
    {
        bossesDefeated = newBossesDefeated;
    }
    private void SetPlayTime(float newPlayTime)
    {
        playTime = newPlayTime;
    }
}
