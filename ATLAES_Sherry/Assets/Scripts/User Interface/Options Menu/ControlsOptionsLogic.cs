using UnityEngine;
using UnityEngine.InputSystem;

public class ControlsOptionsLogic : MonoBehaviour
{
    [HideInInspector] InputActionAsset inputAsset = null;

    public void RemapKeyboardButton(int inputActionValue)
    {
        InputAction actionToRebind = DetermineInputActionFromInt(inputActionValue,
                                                                 PlayerInputs.InputMapValue.KEYBOARD);
        RemapButtonClicked(actionToRebind);
    }
    public void RemapGamepadButton(int inputActionValue)
    {
        InputAction actionToRebind = DetermineInputActionFromInt(inputActionValue,
                                                                 PlayerInputs.InputMapValue.GAMEPAD);
        RemapButtonClicked(actionToRebind);
    }
    public void RemapPlayerTwoButton(int inputActionValue)
    {
        InputAction actionToRebind = DetermineInputActionFromInt(inputActionValue,
                                                                 PlayerInputs.InputMapValue.PLAYER_TWO);
        RemapButtonClicked(actionToRebind);
    }


    private void RemapButtonClicked(InputAction actionToRebind)
    {
        var rebindOperation = actionToRebind.PerformInteractiveRebinding()
                    // To avoid accidental input from mouse motion
                    .WithControlsExcluding("Mouse")
                    .OnMatchWaitForAnother(0.1f)
                    .Start();
    }
    private InputAction DetermineInputActionFromInt(int inputActionValue, PlayerInputs.InputMapValue mapValue)
    {
        InputActionMap actionMap = null;
        switch (mapValue)
        {
            case PlayerInputs.InputMapValue.KEYBOARD:
                actionMap = inputAsset.FindActionMap("Keyboard");
                break;
            case PlayerInputs.InputMapValue.GAMEPAD:
                actionMap = inputAsset.FindActionMap("Gamepad");
                break;
            case PlayerInputs.InputMapValue.PLAYER_TWO:
                actionMap = inputAsset.FindActionMap("PlayerTwo");
                break;
        }

        switch (inputActionValue)
        {
            case 0:
                return actionMap.FindAction("Pause");
            case 11:
                return actionMap.FindAction("SwitchWeapon");
            case 12:
                return actionMap.FindAction("Burst");
            case 1:
                return actionMap.FindAction("Right");
            case 2:
                return actionMap.FindAction("Left");
            case 3:
                return actionMap.FindAction("Crouch");
            case 4:
                return actionMap.FindAction("Up");
            case 5:
                return actionMap.FindAction("Guard");
            case 6:
                return actionMap.FindAction("Jump");
            case 7:
                return actionMap.FindAction("Dash");
            case 8:
                return actionMap.FindAction("Light");
            case 9:
                return actionMap.FindAction("Medium");
            case 10:
                return actionMap.FindAction("Heavy");
            default:
                return null;
        }
    }

}
