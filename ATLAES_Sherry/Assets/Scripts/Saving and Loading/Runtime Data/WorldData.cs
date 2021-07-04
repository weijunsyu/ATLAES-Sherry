
public class WorldData
{
    // Player Game Data
    private int worldType = -1; // -1 = unset, 0 = Adventure, 1 = Fighting, 2 = Hunter
    private int finishedGame = 0; // holds data for if the player finished the game and what ending it was
    private bool[] warpLocations = new bool[GameConstants.TOTAL_NUMBER_WARP_LOCATIONS]; // teleports unlocked to target locations
    private bool[] bossesDefeated = new bool[GameConstants.TOTAL_NUMBER_BOSSES]; // Bosses that have been defeated
    private double finishGameTime = 0; // Holds the time for first clear of game
    private double playTime = 0; // Holds the total playtime of the player on this particular save


    // Class Functions:
    public void ResetAllWorldData()
    {
        ResetWorldType();
        ResetFinishedGame();
        ResetWarpLocations();
        ResetBossesDefeated();
        ResetFinishGameTime();
        ResetPlayTime();
    }

    public int GetWorldType()
    {
        return worldType;
    }
    public void SetWorldType(int value)
    {
        worldType = value;
    }
    public void ResetWorldType()
    {
        worldType = -1;
    }
    public double GetFinishGameTime()
    {
        return finishGameTime;
    }
    public void SetFinishGameTime(double time)
    {
        if (finishGameTime > 0)
        {
            return;
        }
        finishGameTime = time;
    }
    public void ResetFinishGameTime()
    {
        finishGameTime = 0;
    }
    public int GetFinishedGame()
    {
        return finishedGame;
    }
    public void SetFinishedGameString(string ending)
    {
        switch (ending)
        {
            case "true":
                finishedGame = 3;
                break;
            case "good":
                finishedGame = 2;
                break;
            case "bad":
                finishedGame = 1;
                break;
        }
    }
    public void SetFinishedGame(int value)
    {
        finishedGame = value;
    }
    public void ResetFinishedGame()
    {
        finishedGame = 0;
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
