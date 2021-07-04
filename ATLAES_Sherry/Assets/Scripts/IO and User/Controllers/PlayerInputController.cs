using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInputData))]
public class PlayerInputController : MonoBehaviour
{

    //Config Parameters:

    // Cached References:
    [SerializeField] private PlayerInputData playerInputData = null;

    // State Parameters and Objects:
    private int[] socdRightLeft = new int[4] { 1, 2, 0, 0 }; /* Simultaneous Opposing Cardinal Directions (To determine left or right precedence)
                                                                Where [0] = (int)Input of [2], [1] = (int)Input of [3],  [2] = Right, [3] = Left
                                                                Where the value: -1 = physically pressed but release in code, 0 = released, 1 = pressed */
    private int[] socdDownUp = new int[4] { 3, 4, 0, 0 };    // Input order: Crouch , Up

    // Unity Events:


    // Class Functions:
    public void PauseInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            DoInput(PlayerInputs.RawInputAction.PAUSE);
        }
    }
    public void SwitchWeaponInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            DoInput(PlayerInputs.RawInputAction.SWITCH_WEAPON);
        }
    }
    public void BurstInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            DoInput(PlayerInputs.RawInputAction.BURST);
        }
    }
    public void RightInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            EvaluateSOCD(socdRightLeft, PlayerInputs.RawInputAction.RIGHT_PRESS);
        }
        if (context.canceled)
        {
            EvaluateSOCD(socdRightLeft, PlayerInputs.RawInputAction.RIGHT_RELEASE);
        }
    }
    public void LeftInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            EvaluateSOCD(socdRightLeft, PlayerInputs.RawInputAction.LEFT_PRESS);
        }
        if (context.canceled)
        {
            EvaluateSOCD(socdRightLeft, PlayerInputs.RawInputAction.LEFT_RELEASE);
        }
    }
    public void CrouchInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            EvaluateSOCD(socdDownUp, PlayerInputs.RawInputAction.CROUCH_PRESS);
        }
        if (context.canceled)
        {
            EvaluateSOCD(socdDownUp, PlayerInputs.RawInputAction.CROUCH_RELEASE);
        }
    }
    public void UpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            EvaluateSOCD(socdDownUp, PlayerInputs.RawInputAction.UP_PRESS);
        }
        if (context.canceled)
        {
            EvaluateSOCD(socdDownUp, PlayerInputs.RawInputAction.UP_RELEASE);
        }
    }
    public void GuardInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            DoInput(PlayerInputs.RawInputAction.GUARD_PRESS);
        }
        if (context.canceled)
        {
            DoInput(PlayerInputs.RawInputAction.GUARD_RELEASE);
        }
    }
    public void JumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            DoInput(PlayerInputs.RawInputAction.JUMP_PRESS);
        }
        if (context.canceled)
        {
            DoInput(PlayerInputs.RawInputAction.JUMP_RELEASE);
        }
    }
    public void DashInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            DoInput(PlayerInputs.RawInputAction.DASH_PRESS);
        }
        if (context.canceled)
        {
            DoInput(PlayerInputs.RawInputAction.DASH_RELEASE);
        }
    }
    public void LightInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            DoInput(PlayerInputs.RawInputAction.LIGHT_PRESS);
        }
        if (context.canceled)
        {
            DoInput(PlayerInputs.RawInputAction.LIGHT_RELEASE);
        }
    }
    public void MediumInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            DoInput(PlayerInputs.RawInputAction.MEDIUM_PRESS);
        }
        if (context.canceled)
        {
            DoInput(PlayerInputs.RawInputAction.MEDIUM_RELEASE);
        }
    }
    public void HeavyInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            DoInput(PlayerInputs.RawInputAction.HEAVY_PRESS);
        }
        if (context.canceled)
        {
            DoInput(PlayerInputs.RawInputAction.HEAVY_RELEASE);
        }
    }


    private void DoInput(PlayerInputs.RawInputAction input)
    {
        AddToInputBuffer(input);
        AddToInputArray(input);
        AddToTokenArray(input);
    }
    private void AddToInputBuffer(PlayerInputs.RawInputAction rawInput)
    {
        int value = (int)rawInput;
        if (value != 0 && value < 11)
        {
            playerInputData.AddToBuffer(rawInput);
        }
    }
    private void AddToInputArray(PlayerInputs.RawInputAction rawInput)
    {
        int value = (int)rawInput;  

        if (rawInput == PlayerInputs.RawInputAction.PAUSE) // Input is PAUSE
        {
            for (int i = 0; i < GameConstants.NUM_INPUTS; i++)
            {
                playerInputData.pressedInputs[i] = false; // reset the array to all unpressed
            }
            return;
        }
        else if (value > 10) // Input is switch weapon or burst
        {
            return;
        }
        else if (value < 0) // Input is a RELEASE
        {
            playerInputData.pressedInputs[Math.Abs(value)] = false;
        }
        else // input is a PRESS
        {
            playerInputData.pressedInputs[value] = true;
        }
    }
    private void AddToTokenArray(PlayerInputs.RawInputAction rawInput)
    {
        int value = (int)rawInput;

        if (rawInput == PlayerInputs.RawInputAction.PAUSE) // Input is PAUSE
        {
            for (int i = 0; i < GameConstants.NUM_INPUTS; i++)
            {
                playerInputData.inputTokens[i] = false; // reset the array to all unpressed
            }
            return;
        }
        else if (value > 10) // Input is switch weapon or burst
        {
            return;
        }
        else if (value < 0) // Input is a RELEASE
        {
            playerInputData.inputTokens[Math.Abs(value)] = false;
        }
        else // input is a PRESS
        {
            playerInputData.inputTokens[value] = true;
        }
    }


    // Cleans the output such that if left and right are being held the most recent input is taken.
    // Treats multiple buttons as if you let go of the old button and pressed only the new button even if
    // physically both buttons are being held. It then treats letting go of one of 2 held buttons as if you
    // let go of the currently active button and pressed the inactive button.
    private void EvaluateSOCD(int[] socd, PlayerInputs.RawInputAction rawInput)
    {
        // NOTE: Comments written for the specific case of right and left cleaning
        int firstInput = socd[0]; // right
        int secondInput = socd[1]; // left

        if((int)rawInput == firstInput) // If right is being pressed
        {
            socd[2] = 1; //set right to pressed
            if (socd[3] == 1) // If left is pressed
            {
                DoInput((PlayerInputs.RawInputAction)(-secondInput)); // if left is being held then unpress left
                socd[3] = -1; //change status to physically held but unpressed
            }
            DoInput(rawInput); // press right
        }
        else if ((int)rawInput == -firstInput) // If right is being unpressed
        {
            socd[2] = 0; //set right to unpressed
            if (socd[3] == -1) // if direction was right
            {
                DoInput(rawInput); //release right
                socd[3] = 1; // Set left to pressed
                DoInput((PlayerInputs.RawInputAction)secondInput); // press left
            }
            else if (socd[3] == 0) // if left was not pressed at all
            {
                DoInput(rawInput); // simply release right (stop moving)
            }
            //if (socd[3] == 1) { } // if direction was left, do nothing as it has already been released
        }
        else if ((int)rawInput == secondInput) // If left is being pressed
        {
            socd[3] = 1; // Set left to pressed
            if (socd[2] == 1) // If right is pressed
            {
                DoInput((PlayerInputs.RawInputAction)(-firstInput)); // Unpress right
                socd[2] = -1; // set right to held but unpressed
            }
            DoInput(rawInput); // press left
        }
        else if ((int)rawInput == -secondInput) // If left is being unpressed
        {
            socd[3] = 0; // Set left to unpressed
            if (socd[2] == -1) // If right is held but not pressed
            {
                DoInput(rawInput); // Release left
                socd[2] = 1; // Set right to pressed
                DoInput((PlayerInputs.RawInputAction)firstInput); // Press right
            }
            else if (socd[2] == 0) //If right is unpressed
            {
                DoInput(rawInput); // Unpress Left
            }
            //if (socd[2] == 1) { }
        }
    }


    
}
