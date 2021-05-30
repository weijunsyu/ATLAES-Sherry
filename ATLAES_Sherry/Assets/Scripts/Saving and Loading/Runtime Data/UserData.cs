using UnityEngine;

public class UserData
{
    // User Data
    private bool isFullscreen = GameConstants.DEFAULT_WINDOW_IS_FULLSCREEN;
    private int windowWidth = GameConstants.MIN_WINDOW_WIDTH;
    private int windowHeight = GameConstants.MIN_WINDOW_HEIGHT;
    private bool utilityOverlayOn = false;
    private int vSync = 1; // 1 is on, 0 is off (0, 1, 2, 3, 4 are all valid values)
    private int targetFPS = -1; // where -1 is unlimited (setting is ignored if vSync != 0)

    // Class Functions:

    public void ResetAllUserData()
    {
        SetIsFullscreen(GameConstants.DEFAULT_WINDOW_IS_FULLSCREEN);
        SetWindowWidth(GameConstants.MIN_WINDOW_WIDTH);
        SetWindowHeight(GameConstants.MIN_WINDOW_HEIGHT);
        SetUtilityOverlayOn(false);
        SetVSync(true);
        SetTargetFPS(-1);

        Screen.SetResolution(windowWidth, windowHeight, GetIsFullscreen());
        QualitySettings.vSyncCount = vSync;
        Application.targetFrameRate = targetFPS;
    }
    public void RunAllUserData()
    {
        RunVSync();
        RunTargetFPS();
        RunIsFullscreen();
    }

    public int GetWindowWidth()
    {
        return windowWidth;
    }
    public void SetWindowWidth(int width)
    {
        windowWidth = width;
    }
    public int GetWindowHeight()
    {
        return windowHeight;
    }
    public void SetWindowHeight(int height)
    {
        windowHeight = height;
    }
    public bool GetVSync()
    {
        if (vSync > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void SetVSync(bool value)
    {
        if (value)
        {
            vSync = 1;
        }
        else
        {
            vSync = 0;
        }
    }
    public void RunVSync()
    {
        QualitySettings.vSyncCount = vSync;
    }
    public int GetTargetFPS()
    {
        return targetFPS;
    }
    public void SetTargetFPS(int fps)
    {
        targetFPS = fps;
    }
    public void RunTargetFPS()
    {
        Application.targetFrameRate = targetFPS;
    }
    public bool GetIsFullscreen()
    {
        return isFullscreen;
    }

    public void SetIsFullscreen(bool value)
    {
        if (value)
        {
            SetWindowWidth(Screen.width);
            SetWindowHeight(Screen.height);
        }
        isFullscreen = value;
    }

    public void RunIsFullscreen()
    {
        if (isFullscreen)
        {
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
        }
        else
        {
            Screen.SetResolution(windowWidth, windowHeight, false);
        }
    }
    public bool GetUtilityOverlayOn()
    {
        return utilityOverlayOn;
    }
    public void SetUtilityOverlayOn(bool value)
    {
        utilityOverlayOn = value;
    }
}
