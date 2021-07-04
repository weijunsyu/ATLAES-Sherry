using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class UserData
{
    [System.Serializable]
    public struct BindingSerializable
    {
        public string id;
        public string path;

        public BindingSerializable(string bindingId, string bindingPath)
        {
            id = bindingId;
            path = bindingPath;
        }
    }

    // User Data
    private bool isFullscreen = GameConstants.DEFAULT_WINDOW_IS_FULLSCREEN;
    private int windowWidth = GameConstants.MIN_WINDOW_WIDTH;
    private int windowHeight = GameConstants.MIN_WINDOW_HEIGHT;
    private bool utilityOverlayOn = false;
    private int vSync = 1; // 1 is on, 0 is off (0, 1, 2, 3, 4 are all valid values)
    private int targetFPS = -1; // Where -1 is unlimited (setting is ignored if vSync != 0)
    private byte menuAlphaMask = 0; // Value between 0 and 255 denoting the alpha value
    private bool isMinimalist = false; // Turns off all unnecessary graphics
    private int menuProgression = 0;
    private float masterVolume = GameConstants.DEFAULT_MASTER_VOLUME;
    private float musicVolume = GameConstants.DEFAULT_MUSIC_VOLUME;
    private float effectsVolume = GameConstants.DEFAULT_EFFECTS_VOLUME;
    private bool gameTimer = false;
    private bool skipCutscenes = false;
    private bool equalLoadTimes = false;
    private bool customBindingsGamepad = false;
    private List<BindingSerializable> keyboardBindingList = null;
    private List<BindingSerializable> gamepadBindingList = null;
    private List<BindingSerializable> playerTwoBindingList = null;

    // Class Functions:

    public void ResetAllUserData(InputActionAsset inputAsset)
    {
        SetIsFullscreen(GameConstants.DEFAULT_WINDOW_IS_FULLSCREEN);
        SetWindowWidth(GameConstants.MIN_WINDOW_WIDTH);
        SetWindowHeight(GameConstants.MIN_WINDOW_HEIGHT);
        SetUtilityOverlayOn(false);
        SetVSync(true);
        SetTargetFPS(-1);
        SetMenuAlphaMask(0);
        SetIsMinimalist(false);
        SetMenuProgression(0);
        SetMasterVolume(GameConstants.DEFAULT_MASTER_VOLUME);
        SetMusicVolume(GameConstants.DEFAULT_MUSIC_VOLUME);
        SetEffectsVolume(GameConstants.DEFAULT_EFFECTS_VOLUME);
        SetGameTimer(false);
        SetSkipCutscenes(false);
        SetEqualLoadTimes(false);
        ResetAllKeybinds(inputAsset);

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
    public void ResetAllKeybinds(InputActionAsset inputAsset)
    {
        InputActionMap keyboardMap = inputAsset.FindActionMap("Keyboard");
        InputActionMap gamepadMap = inputAsset.FindActionMap("Gamepad");
        InputActionMap playerTwoMap = inputAsset.FindActionMap("PlayerTwo");

        ResetKeyboardBinds(keyboardMap);
        ResetGamepadBinds(gamepadMap);
        ResetPlayerTwoBinds(playerTwoMap);
    }
    public void ResetKeyboardBinds(InputActionMap inputMap)
    {
        inputMap.RemoveAllBindingOverrides();
        keyboardBindingList = null;
    }
    public void ResetGamepadBinds(InputActionMap inputMap)
    {
        inputMap.RemoveAllBindingOverrides();
        customBindingsGamepad = false;
        gamepadBindingList = null;
    }
    public void ResetPlayerTwoBinds(InputActionMap inputMap)
    {
        inputMap.RemoveAllBindingOverrides();
        playerTwoBindingList = null;
    }
    // Return true if custom keybinds have been made, false otherwise
    public bool GetKeyboardBindingList(out List<BindingSerializable> bindingList)
    {
        if (keyboardBindingList == null)
        {
            bindingList = null;
            return false;
        }
        else
        {
            bindingList = new List<BindingSerializable>();
            bindingList.AddRange(keyboardBindingList);
            return true;
        }
    }
    public void SetKeyboardBindingList(InputActionMap inputMap)
    {
        if (keyboardBindingList == null)
        {
            keyboardBindingList = new List<BindingSerializable>();
        }
        keyboardBindingList.Clear();

        foreach (var binding in inputMap.bindings)
        {
            if (!string.IsNullOrEmpty(binding.overridePath))
            {
                keyboardBindingList.Add(new BindingSerializable(binding.id.ToString(), binding.overridePath));
            }
        }
    }
    public bool GetGamepadBindingList(out List<BindingSerializable> bindingList)
    {
        if (gamepadBindingList == null)
        {
            bindingList = null;
            return false;
        }
        else
        {
            bindingList = new List<BindingSerializable>();
            bindingList.AddRange(gamepadBindingList);
            return true;
        }
    }
    public void SetGamepadBindingList(InputActionMap inputMap)
    {
        if (gamepadBindingList == null)
        {
            gamepadBindingList = new List<BindingSerializable>();
        }
        gamepadBindingList.Clear();

        foreach (var binding in inputMap.bindings)
        {
            if (!string.IsNullOrEmpty(binding.overridePath))
            {
                customBindingsGamepad = true;
                gamepadBindingList.Add(new BindingSerializable(binding.id.ToString(), binding.overridePath));
            }
        }
    }
    public bool GetPlayerTwoBindingList(out List<BindingSerializable> bindingList)
    {
        if (playerTwoBindingList == null)
        {
            bindingList = null;
            return false;
        }
        else
        {
            bindingList = new List<BindingSerializable>();
            bindingList.AddRange(playerTwoBindingList);
            return true;
        }
    }
    public void SetPlayerTwoBindingList(InputActionMap inputMap)
    {
        if (playerTwoBindingList == null)
        {
            playerTwoBindingList = new List<BindingSerializable>();
        }
        playerTwoBindingList.Clear();

        foreach (var binding in inputMap.bindings)
        {
            if (!string.IsNullOrEmpty(binding.overridePath))
            {
                playerTwoBindingList.Add(new BindingSerializable(binding.id.ToString(), binding.overridePath));
            }
        }
    }
    public bool GetCustomBindingsGamepad()
    {
        return customBindingsGamepad;
    }

    public bool GetGameTimer()
    {
        return gameTimer;
    }
    public void SetGameTimer(bool value)
    {
        gameTimer = value;
    }
    public bool GetSkipCutscenes()
    {
        return skipCutscenes;
    }
    public void SetSkipCutscenes(bool value)
    {
        skipCutscenes = value;
    }
    public bool GetEqualLoadTimes()
    {
        return equalLoadTimes;
    }
    public void SetEqualLoadTimes(bool value)
    {
        equalLoadTimes = value;
    }
    public float GetMasterVolume()
    {
        return masterVolume;
    }
    public void SetMasterVolume(float value)
    {
        masterVolume = value;
    }
    public float GetMusicVolume()
    {
        return musicVolume;
    }
    public void SetMusicVolume(float value)
    {
        musicVolume = value;
    }
    public float GetEffectsVolume()
    {
        return effectsVolume;
    }
    public void SetEffectsVolume(float value)
    {
        effectsVolume = value;
    }
    public int GetMenuProgression()
    {
        return menuProgression;
    }
    public void SetMenuProgression(int value)
    {
        menuProgression = value;
    }
    public byte GetMenuAlphaMask()
    {
        return menuAlphaMask;
    }
    public void SetMenuAlphaMask(byte value)
    {
        menuAlphaMask = value;
    }
    public bool GetIsMinimalist()
    {
        return isMinimalist;
    }
    public void SetIsMinimalist(bool value)
    {
        isMinimalist = value;
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
