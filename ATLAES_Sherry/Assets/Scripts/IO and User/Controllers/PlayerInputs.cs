using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    public enum InputMapValue
    {
        KEYBOARD,
        GAMEPAD,
        PLAYER_TWO
    }
    public enum InputActionValue
    {
        PAUSE = 0,
        SWITCH_WEAPON = 11,
        BURST = 12,
        RIGHT = 1,
        LEFT = 2,
        CROUCH = 3,
        UP = 4,
        GUARD = 5,
        JUMP = 6,
        DASH = 7,
        LIGHT = 8,
        MEDIUM = 9,
        HEAVY = 10,
    }
    public enum RawInputAction
    {
        PAUSE = 0,
        SWITCH_WEAPON = 11,
        BURST = 12,
        RIGHT_PRESS = 1,
        LEFT_PRESS = 2,
        CROUCH_PRESS = 3,
        UP_PRESS = 4,
        GUARD_PRESS = 5,
        JUMP_PRESS = 6,
        DASH_PRESS = 7,
        LIGHT_PRESS = 8,
        MEDIUM_PRESS = 9,
        HEAVY_PRESS = 10,
        RIGHT_RELEASE = -1,
        LEFT_RELEASE = -2,
        CROUCH_RELEASE = -3,
        UP_RELEASE = -4,
        GUARD_RELEASE = -5,
        JUMP_RELEASE = -6,
        DASH_RELEASE = -7,
        LIGHT_RELEASE = -8,
        MEDIUM_RELEASE = -9,
        HEAVY_RELEASE = -10,
    }

    public enum ComboInput
    {
        FORWARD_PRESS = 1,
        BACKWARD_PRESS = 2,
        CROUCH_PRESS = 3,
        UP_PRESS = 4,
        GUARD_PRESS = 5,
        JUMP_PRESS = 6,
        DASH_PRESS = 7,
        LIGHT_PRESS = 8,
        MEDIUM_PRESS = 9,
        HEAVY_PRESS = 10,
        FORWARD_RELEASE = -1,
        BACKWARD_RELEASE = -2,
        CROUCH_RELEASE = -3,
        UP_RELEASE = -4,
        GUARD_RELEASE = -5,
        JUMP_RELEASE = -6,
        DASH_RELEASE = -7,
        LIGHT_RELEASE = -8,
        MEDIUM_RELEASE = -9,
        HEAVY_RELEASE = -10,
    }

    public void LoadKeyBinds(InputActionAsset inputAsset)
    {
        InputActionMap keyboardMap = inputAsset.FindActionMap("Keyboard");
        InputActionMap gamepadMap = inputAsset.FindActionMap("Gamepad");
        InputActionMap playerTwoMap = inputAsset.FindActionMap("PlayerTwo");

        LoadKeyboardBinds(keyboardMap);
        LoadGamepadBinds(gamepadMap);
        LoadPlayerTwoBinds(playerTwoMap);
    }
    private void LoadKeyboardBinds(InputActionMap inputMap)
    {
        List<UserData.BindingSerializable> keyboardBindingList;
        if (MasterManager.userData.GetKeyboardBindingList(out keyboardBindingList))
        {
            Dictionary<System.Guid, string> overrides = new Dictionary<System.Guid, string>();
            foreach(var item in keyboardBindingList)
            {
                overrides.Add(new System.Guid(item.id), item.path);
            }

            var bindings = inputMap.bindings;
            for (int i = 0; i < bindings.Count; ++i)
            {
                if (overrides.TryGetValue(bindings[i].id, out string overridePath))
                {
                    inputMap.ApplyBindingOverride(i, new InputBinding { overridePath = overridePath });
                }
            }
        }
    }
    private void LoadGamepadBinds(InputActionMap inputMap)
    {
        List<UserData.BindingSerializable> gamepadBindingList;
        if (MasterManager.userData.GetKeyboardBindingList(out gamepadBindingList))
        {
            Dictionary<System.Guid, string> overrides = new Dictionary<System.Guid, string>();
            foreach (var item in gamepadBindingList)
            {
                overrides.Add(new System.Guid(item.id), item.path);
            }

            var bindings = inputMap.bindings;
            for (int i = 0; i < bindings.Count; ++i)
            {
                if (overrides.TryGetValue(bindings[i].id, out string overridePath))
                {
                    inputMap.ApplyBindingOverride(i, new InputBinding { overridePath = overridePath });
                }
            }
        }
    }
    private void LoadPlayerTwoBinds(InputActionMap inputMap)
    {
        List<UserData.BindingSerializable> playerTwoBindingList;
        if (MasterManager.userData.GetKeyboardBindingList(out playerTwoBindingList))
        {
            Dictionary<System.Guid, string> overrides = new Dictionary<System.Guid, string>();
            foreach (var item in playerTwoBindingList)
            {
                overrides.Add(new System.Guid(item.id), item.path);
            }

            var bindings = inputMap.bindings;
            for (int i = 0; i < bindings.Count; ++i)
            {
                if (overrides.TryGetValue(bindings[i].id, out string overridePath))
                {
                    inputMap.ApplyBindingOverride(i, new InputBinding { overridePath = overridePath });
                }
            }
        }
    }
}
