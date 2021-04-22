using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    public enum RawInput
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

    //Config Parameters:

    // Cached References:
    private PlayerControls playerControls;

    // Static Objects
    [HideInInspector] public static int numInputs = 11; // MUST MATCH NUMBER OF INPUTS GIVEN IN ENUM
    [HideInInspector] public static bool[] pressedInputs = new bool[numInputs]; // where false is unpressed and index -> input

    // State Parameters and Objects:
    private int[] socdRightLeft = new int[4] { 1, 2, 0, 0 }; /* Simultaneous Opposing Cardinal Directions (To determine left or right precedence)
                                                                Where [0] = (int)Input of [2], [1] = (int)Input of [3],  [2] = Right, [3] = Left
                                                                Where the value: -1 = physically pressed but release in code, 0 = released, 1 = pressed */
    private int[] socdDownUp = new int[4] { 3, 4, 0, 0 };    // Input order: Crouch , Up

    // Event System:
    public delegate void InputEventHandler(object sender, InputEventArgs input);
    public static event InputEventHandler OnInputEvent;

    // Unity Events:
    private void Awake()
    {
        playerControls = new PlayerControls();

        // Pause Game / Open Menu (event handler in master manager which then disables this script while in pause menu)
        playerControls.MouseAndKeyboard.PauseGame.performed += ctx => DoInput(RawInput.PAUSE);
        playerControls.GamepadController.PauseGame.performed += ctx => DoInput(RawInput.PAUSE);
        // Switch weapon
        playerControls.MouseAndKeyboard.SwitchWeapon.performed += ctx => DoInput(RawInput.SWITCH_WEAPON);
        playerControls.GamepadController.SwitchWeapon.performed += ctx => DoInput(RawInput.SWITCH_WEAPON);
        // Burst
        playerControls.MouseAndKeyboard.Burst.performed += ctx => DoInput(RawInput.BURST);
        playerControls.GamepadController.Burst.performed += ctx => DoInput(RawInput.BURST);

        // Move Right
        playerControls.MouseAndKeyboard.MoveRight.performed += ctx => EvaluateSOCD(socdRightLeft, RawInput.RIGHT_PRESS);
        playerControls.MouseAndKeyboard.MoveRight.canceled += ctx => EvaluateSOCD(socdRightLeft, RawInput.RIGHT_RELEASE);
        playerControls.GamepadController.MoveRight.performed += ctx => EvaluateSOCD(socdRightLeft, RawInput.RIGHT_PRESS);
        playerControls.GamepadController.MoveRight.canceled += ctx => EvaluateSOCD(socdRightLeft, RawInput.RIGHT_RELEASE);
        // Move Left
        playerControls.MouseAndKeyboard.MoveLeft.performed += ctx => EvaluateSOCD(socdRightLeft, RawInput.LEFT_PRESS);
        playerControls.MouseAndKeyboard.MoveLeft.canceled += ctx => EvaluateSOCD(socdRightLeft, RawInput.LEFT_RELEASE);
        playerControls.GamepadController.MoveLeft.performed += ctx => EvaluateSOCD(socdRightLeft, RawInput.LEFT_PRESS);
        playerControls.GamepadController.MoveLeft.canceled += ctx => EvaluateSOCD(socdRightLeft, RawInput.LEFT_RELEASE);
        // Crouch/Down
        playerControls.MouseAndKeyboard.Crouch.performed += ctx => EvaluateSOCD(socdDownUp, RawInput.CROUCH_PRESS);
        playerControls.MouseAndKeyboard.Crouch.canceled += ctx => EvaluateSOCD(socdDownUp, RawInput.CROUCH_RELEASE);
        playerControls.GamepadController.Crouch.performed += ctx => EvaluateSOCD(socdDownUp, RawInput.CROUCH_PRESS);
        playerControls.GamepadController.Crouch.canceled += ctx => EvaluateSOCD(socdDownUp, RawInput.CROUCH_RELEASE);
        // Up
        playerControls.MouseAndKeyboard.Up.performed += ctx => EvaluateSOCD(socdDownUp, RawInput.UP_PRESS);
        playerControls.MouseAndKeyboard.Up.canceled += ctx => EvaluateSOCD(socdDownUp, RawInput.UP_RELEASE);
        playerControls.GamepadController.Up.performed += ctx => EvaluateSOCD(socdDownUp, RawInput.UP_PRESS);
        playerControls.GamepadController.Up.canceled += ctx => EvaluateSOCD(socdDownUp, RawInput.UP_RELEASE);

        //Guard
        playerControls.MouseAndKeyboard.Guard.performed += ctx => DoInput(RawInput.GUARD_PRESS);
        playerControls.MouseAndKeyboard.Guard.canceled += ctx => DoInput(RawInput.GUARD_RELEASE);
        playerControls.GamepadController.Guard.performed += ctx => DoInput(RawInput.GUARD_PRESS);
        playerControls.GamepadController.Guard.canceled += ctx => DoInput(RawInput.GUARD_RELEASE);
        // Jump
        playerControls.MouseAndKeyboard.Jump.performed += ctx => DoInput(RawInput.JUMP_PRESS);
        playerControls.MouseAndKeyboard.Jump.canceled += ctx => DoInput(RawInput.JUMP_RELEASE);
        playerControls.GamepadController.Jump.performed += ctx => DoInput(RawInput.JUMP_PRESS);
        playerControls.GamepadController.Jump.canceled += ctx => DoInput(RawInput.JUMP_RELEASE);
        // Dash
        playerControls.MouseAndKeyboard.Dash.performed += ctx => DoInput(RawInput.DASH_PRESS);
        playerControls.MouseAndKeyboard.Dash.canceled += ctx => DoInput(RawInput.DASH_RELEASE);
        playerControls.GamepadController.Dash.performed += ctx => DoInput(RawInput.DASH_PRESS);
        playerControls.GamepadController.Dash.canceled += ctx => DoInput(RawInput.DASH_RELEASE);

        // Light attack
        playerControls.MouseAndKeyboard.Light.performed += ctx => DoInput(RawInput.LIGHT_PRESS);
        playerControls.MouseAndKeyboard.Light.canceled += ctx => DoInput(RawInput.LIGHT_RELEASE);
        playerControls.GamepadController.Light.performed += ctx => DoInput(RawInput.LIGHT_PRESS);
        playerControls.GamepadController.Light.canceled += ctx => DoInput(RawInput.LIGHT_RELEASE);
        // Medium attack
        playerControls.MouseAndKeyboard.Medium.performed += ctx => DoInput(RawInput.MEDIUM_PRESS);
        playerControls.MouseAndKeyboard.Medium.canceled += ctx => DoInput(RawInput.MEDIUM_RELEASE);
        playerControls.GamepadController.Medium.performed += ctx => DoInput(RawInput.MEDIUM_PRESS);
        playerControls.GamepadController.Medium.canceled += ctx => DoInput(RawInput.MEDIUM_RELEASE);
        // Heavy attack
        playerControls.MouseAndKeyboard.Heavy.performed += ctx => DoInput(RawInput.HEAVY_PRESS);
        playerControls.MouseAndKeyboard.Heavy.canceled += ctx => DoInput(RawInput.HEAVY_RELEASE);
        playerControls.GamepadController.Heavy.performed += ctx => DoInput(RawInput.HEAVY_PRESS);
        playerControls.GamepadController.Heavy.canceled += ctx => DoInput(RawInput.HEAVY_RELEASE);
    }

    private void OnEnable()
    {
        // Enable virtual controller:
        playerControls.Enable();
    }

    private void OnDisable()
    {
        // Disable virtual controller:
        playerControls.Disable();
    }

    // Class Functions:
    private void DoInput(RawInput input)
    {
        AddToInputArray(input);

        InputEventArgs inputEvent = new InputEventArgs();
        inputEvent.input = input;
        
        //Debug.Log("Input pressed RAW: " + input.ToString());
        if (OnInputEvent != null)
        {
            OnInputEvent(this, inputEvent);
            //Debug.Log("Input recived EVENT: " + input.ToString());
        }
    }

    private void AddToInputArray(RawInput rawInput)
    {
        int value = (int)rawInput;  

        if (rawInput == RawInput.PAUSE) // Input is PAUSE
        {
            for (int i = 0; i < numInputs; i++)
            {
                pressedInputs[i] = false; // reset the array to all unpressed
            }
            return;
        }
        else if (value > 10) // Input is switch weapon or burst
        {
            return;
        }
        else if (value < 0) // Input is a RELEASE
        {
            pressedInputs[Math.Abs(value)] = false;
        }
        else // input is a PRESS
        {
            pressedInputs[value] = true;
        }
    }

    // Cleans the output such that if left and right are being held the most recent input is taken.
    // Treats multiple buttons as if you let go of the old button and pressed only the new button even if
    // physically both buttons are being held. It then treats letting go of one of 2 held buttons as if you
    // let go of the currently active button and pressed the inactive button.
    private void EvaluateSOCD(int[] socd, RawInput input)
    {
        // NOTE: Comments written for the specific case of right and left cleaning
        int firstInput = socd[0]; // right
        int secondInput = socd[1]; // left

        if((int)input == firstInput) // If right is being pressed
        {
            socd[2] = 1; //set right to pressed
            if (socd[3] == 1) // If left is pressed
            {
                DoInput((RawInput)(-secondInput)); // if left is being held then unpress left
                socd[3] = -1; //change status to physically held but unpressed
            }
            DoInput(input); // press right
        }
        else if ((int)input == -firstInput) // If right is being unpressed
        {
            socd[2] = 0; //set right to unpressed
            if (socd[3] == -1) // if direction was right
            {
                DoInput(input); //release right
                socd[3] = 1; // Set left to pressed
                DoInput((RawInput)secondInput); // press left
            }
            else if (socd[3] == 0) // if left was not pressed at all
            {
                DoInput(input); // simply release right (stop moving)
            }
            //if (socd[3] == 1) { } // if direction was left, do nothing as it has already been released
        }
        else if ((int)input == secondInput) // If left is being pressed
        {
            socd[3] = 1; // Set left to pressed
            if (socd[2] == 1) // If right is pressed
            {
                DoInput((RawInput)(-firstInput)); // Unpress right
                socd[2] = -1; // set right to held but unpressed
            }
            DoInput(input); // press left
        }
        else if ((int)input == -secondInput) // If left is being unpressed
        {
            socd[3] = 0; // Set left to unpressed
            if (socd[2] == -1) // If right is held but not pressed
            {
                DoInput(input); // Release left
                socd[2] = 1; // Set right to pressed
                DoInput((RawInput)firstInput); // Press right
            }
            else if (socd[2] == 0) //If right is unpressed
            {
                DoInput(input); // Unpress Left
            }
            //if (socd[2] == 1) { }
        }
    }
}

public class InputEventArgs : EventArgs
{
    public PlayerInputController.RawInput input { get; set; }
}
