using System.Collections.Generic;

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
    public byte menuAlphaMask;
    public bool isMinimalist;
    public int menuProgression;
    public float masterVolume;
    public float musicVolume;
    public float effectsVolume;
    public bool gameTimer;
    public bool skipCutscenes;
    public bool equalLoadTimes;
    public bool customBindingsGamepad;
    public List<UserData.BindingSerializable> keyboardBindingList;
    public List<UserData.BindingSerializable> gamepadBindingList;
    public List<UserData.BindingSerializable> playerTwoBindingList;


    //constructor
    public SettingsData()
    {
        this.isFullScreen = MasterManager.userData.GetIsFullscreen();
        this.windowWidth = MasterManager.userData.GetWindowWidth();
        this.windowHeight = MasterManager.userData.GetWindowHeight();
        this.utilityOverlayOn = MasterManager.userData.GetUtilityOverlayOn();
        this.vSync = MasterManager.userData.GetVSync();
        this.targetFPS = MasterManager.userData.GetTargetFPS();
        this.menuAlphaMask = MasterManager.userData.GetMenuAlphaMask();
        this.isMinimalist = MasterManager.userData.GetIsMinimalist();
        this.menuProgression = MasterManager.userData.GetMenuProgression();
        this.masterVolume = MasterManager.userData.GetMasterVolume();
        this.musicVolume = MasterManager.userData.GetMusicVolume();
        this.effectsVolume = MasterManager.userData.GetEffectsVolume();
        this.gameTimer = MasterManager.userData.GetGameTimer();
        this.skipCutscenes = MasterManager.userData.GetSkipCutscenes();
        this.equalLoadTimes = MasterManager.userData.GetEqualLoadTimes();
        this.customBindingsGamepad = MasterManager.userData.GetCustomBindingsGamepad();
        MasterManager.userData.GetKeyboardBindingList(out this.keyboardBindingList);
        MasterManager.userData.GetGamepadBindingList(out this.gamepadBindingList);
        MasterManager.userData.GetPlayerTwoBindingList(out this.playerTwoBindingList);
    }
}
