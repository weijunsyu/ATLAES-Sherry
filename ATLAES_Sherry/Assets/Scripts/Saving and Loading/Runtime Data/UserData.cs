using UnityEngine;

public class UserData
{
    // User Data
    private bool isFullscreen = GameConstants.DEFAULT_WINDOW_IS_FULLSCREEN;

    // Class Functions:

    public void ResetAllUserData()
    {
        SetIsFullscreen(GameConstants.DEFAULT_WINDOW_IS_FULLSCREEN);
        
        
        Screen.SetResolution(GameConstants.MIN_WINDOW_WIDTH, GameConstants.MIN_WINDOW_HEIGHT, GetIsFullscreen());
    }

    public bool GetIsFullscreen()
    {
        return isFullscreen;
    }

    public void SetIsFullscreen(bool value)
    {
        isFullscreen = value;
    }

    public void RunIsFullscreen()
    {
        SetAndRunIsFullscreen(isFullscreen);
    }

    public void SetAndRunIsFullscreen(bool value)
    {
        if (value)
        {
            SetAndRunFullscreen();
        }
        else
        {
            SetAndRunWindowed();
        }
    }

    private void SetAndRunFullscreen()
    {
        isFullscreen = true;
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, isFullscreen);
    }
    private void SetAndRunWindowed()
    {
        isFullscreen = false;
        Screen.SetResolution(GameConstants.MIN_WINDOW_WIDTH, GameConstants.MIN_WINDOW_HEIGHT, isFullscreen);
    }
}
