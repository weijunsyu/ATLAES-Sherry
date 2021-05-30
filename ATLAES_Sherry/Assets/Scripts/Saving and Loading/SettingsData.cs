
[System.Serializable]
public class SettingsData
{
    // User Data:
    public bool isFullScreen;
    public int windowWidth;
    public int windowHeight;
    public bool utilityOverlayOn;
    public bool vSync;
    public int targetFPS;


    //constructor
    public SettingsData()
    {
        this.isFullScreen = MasterManager.userData.GetIsFullscreen();
        this.windowWidth = MasterManager.userData.GetWindowWidth();
        this.windowHeight = MasterManager.userData.GetWindowHeight();
        this.utilityOverlayOn = MasterManager.userData.GetUtilityOverlayOn();
        this.vSync = MasterManager.userData.GetVSync();
        this.targetFPS = MasterManager.userData.GetTargetFPS();
    }
}
