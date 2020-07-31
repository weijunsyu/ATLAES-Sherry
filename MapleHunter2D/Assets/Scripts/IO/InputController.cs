using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InputController : MonoBehaviour
{
    // Definitions:
    /*
     * List of movement inputs in order of importance from least to most important
     * such that more imortant inputs override less important inputs
     */
    private enum MovementInput
    {
        STOP = 0, // Stop in horizontal plane only (gravity is a thing)
        MOVE_RIGHT = 1,
        MOVE_LEFT = 2,
        CROUCH = 3,
        DASH = 4,
        JUMP = 5,
        DODGE = 6
    }
    /*
     * List of action inputs of which ALL ACTIONS CAN EXIST INDEPENDENT OF EACH OTHER
     * No precedence of any kind
     */
    private enum ActionInput
    {
        UP = 7, // Used for combos and entering portals / interactions
        PRIMARY = 8,
        SECONDARY = 9,
        UTILITY_1 = 10,
        UTILITY_2 = 11
    }


    // Cached References:
    [SerializeField] private PlayerCharacterData playerCharacterData = null;
    [SerializeField] private PlayerMovement playerMovement = null;
    [SerializeField] private PlayerAction playerAction = null;
    private VirtualController virtualController;

    // State Parameters and Objects:
    private List<MovementInput> movementInputList = new List<MovementInput>(); //should never be emtpy as character should be STOP if not doing anything
    private List<ActionInput> actionInputList = new List<ActionInput>(); //when empty it means no action is being performed at current point in time
    private bool aimAttackIsSecondary; //toggle aim attack between primary and secondary attack (used only in controller input)
    private int currentComboPosition; //stores the current number of inputs in potential combo
    private float comboInputInitialTime; //store the time when potential combo starts
    private float comboInputCurrentTime; //stores the current time (used to find delta time between combo start and combo evaluation

    // Unity Events:
    private void Awake()
    {
        virtualController = new VirtualController();
        
        // Move Right
        virtualController.MouseAndKeyboard.MoveRight.performed += ctx => MovementAddEvaluate(MovementInput.MOVE_RIGHT);
        virtualController.MouseAndKeyboard.MoveRight.canceled += ctx => MovementRemoveEvaluate(MovementInput.MOVE_RIGHT);
        virtualController.GamepadController.MoveRight.performed += ctx => MovementAddEvaluate(MovementInput.MOVE_RIGHT);
        virtualController.GamepadController.MoveRight.canceled += ctx => MovementRemoveEvaluate(MovementInput.MOVE_RIGHT);
        // Move Left
        virtualController.MouseAndKeyboard.MoveLeft.performed += ctx => MovementAddEvaluate(MovementInput.MOVE_LEFT);
        virtualController.MouseAndKeyboard.MoveLeft.canceled += ctx => MovementRemoveEvaluate(MovementInput.MOVE_LEFT);
        virtualController.GamepadController.MoveLeft.performed += ctx => MovementAddEvaluate(MovementInput.MOVE_LEFT);
        virtualController.GamepadController.MoveLeft.canceled += ctx => MovementRemoveEvaluate(MovementInput.MOVE_LEFT);
        // Jump
        virtualController.MouseAndKeyboard.Jump.started += ctx => MovementAddEvaluateRemove(MovementInput.JUMP);
        virtualController.GamepadController.Jump.started += ctx => MovementAddEvaluateRemove(MovementInput.JUMP);

        // Crouch
        virtualController.MouseAndKeyboard.Crouch.performed += ctx => MovementAddEvaluate(MovementInput.CROUCH);
        virtualController.MouseAndKeyboard.Crouch.canceled += ctx => MovementRemoveEvaluate(MovementInput.CROUCH);
        virtualController.GamepadController.Crouch.performed += ctx => MovementAddEvaluate(MovementInput.CROUCH);
        virtualController.GamepadController.Crouch.canceled += ctx => MovementRemoveEvaluate(MovementInput.CROUCH);

        // Up
        virtualController.MouseAndKeyboard.Up.performed += ctx => ActionAddEvaluate(ActionInput.UP);
        virtualController.MouseAndKeyboard.Up.canceled += ctx => ActionRemoveEvaluate(ActionInput.UP);
        virtualController.GamepadController.Up.performed += ctx => ActionAddEvaluate(ActionInput.UP);
        virtualController.GamepadController.Up.canceled += ctx => ActionRemoveEvaluate(ActionInput.UP);

        // Dodge
        virtualController.MouseAndKeyboard.Dodge.started += ctx => MovementAddEvaluateRemove(MovementInput.DODGE);
        virtualController.GamepadController.Dodge.started += ctx => MovementAddEvaluateRemove(MovementInput.DODGE);
        // Dash
        virtualController.MouseAndKeyboard.Dash.started += ctx => MovementAddEvaluateRemove(MovementInput.DASH);
        virtualController.GamepadController.Dash.started += ctx => MovementAddEvaluateRemove(MovementInput.DASH);

        // Primary
        virtualController.MouseAndKeyboard.Primary.performed += ctx => ActionAddEvaluate(ActionInput.PRIMARY);
        virtualController.MouseAndKeyboard.Primary.canceled += ctx => ActionRemoveEvaluate(ActionInput.PRIMARY);
        virtualController.GamepadController.Primary.performed += ctx => ActionAddEvaluate(ActionInput.PRIMARY);
        virtualController.GamepadController.Primary.canceled += ctx => ActionRemoveEvaluate(ActionInput.PRIMARY);
        // Secondary
        virtualController.MouseAndKeyboard.Secondary.performed += ctx => ActionAddEvaluate(ActionInput.SECONDARY);
        virtualController.MouseAndKeyboard.Secondary.canceled += ctx => ActionRemoveEvaluate(ActionInput.SECONDARY);
        virtualController.GamepadController.Secondary.performed += ctx => ActionAddEvaluate(ActionInput.SECONDARY);
        virtualController.GamepadController.Secondary.canceled += ctx => ActionRemoveEvaluate(ActionInput.SECONDARY);
        // Utility 1
        virtualController.MouseAndKeyboard.Utility1.performed += ctx => ActionAddEvaluate(ActionInput.UTILITY_1);
        virtualController.MouseAndKeyboard.Utility1.canceled += ctx => ActionRemoveEvaluate(ActionInput.UTILITY_1);
        virtualController.GamepadController.Utility1.performed += ctx => ActionAddEvaluate(ActionInput.UTILITY_1);
        virtualController.GamepadController.Utility1.canceled += ctx => ActionRemoveEvaluate(ActionInput.UTILITY_1);
        // Utility 2
        virtualController.MouseAndKeyboard.Utility2.performed += ctx => ActionAddEvaluate(ActionInput.UTILITY_2);
        virtualController.MouseAndKeyboard.Utility2.canceled += ctx => ActionRemoveEvaluate(ActionInput.UTILITY_2);
        virtualController.GamepadController.Utility2.performed += ctx => ActionAddEvaluate(ActionInput.UTILITY_2);
        virtualController.GamepadController.Utility2.canceled += ctx => ActionRemoveEvaluate(ActionInput.UTILITY_2);

        // Pause Game
        virtualController.MouseAndKeyboard.PauseGame.started += ctx => PauseGame();
        virtualController.GamepadController.PauseGame.started += ctx => PauseGame();

        // MOUSE ONLY:
        // Aim
        virtualController.MouseAndKeyboard.Aim.performed += ctx => FreeAim(ctx.ReadValue<Vector2>());

        // GAMEPAD ONLY:
        // Aim Attack (primary attack on direction aimed)
        virtualController.GamepadController.AimAttack.performed += ctx => AimAttack(ctx.ReadValue<Vector2>());
        // Hold Secondary Aim Attack Mode (hold to switch Aim Attack to Secondary from Primary)
        virtualController.GamepadController.HoldSecondaryAimAttack.performed += ctx => aimAttackIsSecondary = true;
        virtualController.GamepadController.HoldSecondaryAimAttack.canceled += ctx => aimAttackIsSecondary = false;

    }

    private void OnEnable()
    {
        // Reset state parameters and objects:
        movementInputList.Clear();
        movementInputList.Add(MovementInput.STOP); //movementInputList should always have stop
        actionInputList.Clear();
        aimAttackIsSecondary = false;
        currentComboPosition = 0;
        comboInputInitialTime = 0;
        comboInputCurrentTime = 0;

        // Enable virtual controller:
        virtualController.Enable();
    }
    private void Update()
    {
        ReEvaluateMovementInput();
    }
    private void OnDisable()
    {
        virtualController.Disable();
    }


    // Class Functions:
    private void ReEvaluateMovementInput()
    {
        EvaluateMovementInput(movementInputList.Max());
    }
    private void FreeAim(Vector2 direction)
    {
        playerAction.SetReticleAndAim(direction);
    }

    private void AimAttack(Vector2 direction)
    {
        playerAction.AimCharacterJoystick(direction);
        if (aimAttackIsSecondary)
        {
            //Debug.Log("Aim is Secondary");
            ActionAddEvaluate(ActionInput.SECONDARY);
        }
        else
        {
            //Debug.Log("Aim is Primary");
            ActionAddEvaluate(ActionInput.PRIMARY);
        }
        if (direction == Vector2.zero) // Reset Primary and Secondary actions when Right Stick resets at [0,0]
        {
            //Debug.Log("Aim is Reset");
            ActionRemoveEvaluate(ActionInput.SECONDARY);
            ActionRemoveEvaluate(ActionInput.PRIMARY);
        }
    }

    private void MovementAddEvaluate(MovementInput input)
    {
        MovementInput newInput = AddToMovementInputList(input);
        EvaluateMovementInput(newInput);
        
        EvaluateCombo((int)input); //check if input is combo
    }
    private void ActionAddEvaluate(ActionInput input)
    {
        AddToActionInputList(input);
        EvaluateActionInputs();
        
        EvaluateCombo((int)input); //check if input is combo
    }
    private void MovementRemoveEvaluate(MovementInput input)
    {
        MovementInput newInput = RemoveFromMovementInputList(input);
        EvaluateMovementInput(newInput);
    }
    private void ActionRemoveEvaluate(ActionInput input)
    {
        RemoveFromActionInputList(input);
        EvaluateActionInputs();
    }
    private void MovementAddEvaluateRemove(MovementInput input)
    {
        MovementAddEvaluate(input);
        MovementRemoveEvaluate(input);
    }
    private void ActionAddEvaluateRemove(ActionInput input)
    {
        ActionAddEvaluate(input);
        ActionRemoveEvaluate(input);
    }

    // Add MovementInput input into list of currentInputs if not already in list and return the MovementInput of most precedence
    private MovementInput AddToMovementInputList(MovementInput input)
    {
        if (!movementInputList.Any()) // MovementInput list is empty 
        {
            if(input != MovementInput.STOP) //input is NOT stop
            {
                movementInputList.Add(MovementInput.STOP);
                movementInputList.Add(input);
            }
            else //input IS stop
            {
                movementInputList.Add(input); //add stop to list
            }
            return input;
        }
        else // MovementInput list not empty
        {
            
            if (!movementInputList.Contains(input)) //if input does not already exist in list
            {
                movementInputList.Add(input);
            }
            return movementInputList.Max();
        }
    }
    private void AddToActionInputList(ActionInput input)
    {
        if (!actionInputList.Contains(input))
        {
            actionInputList.Add(input);
        }
    }

    // Remove ALL instances of specified inputs from the input list and return the MovementInput of most precedence or STOP in case of empty list
    private MovementInput RemoveFromMovementInputList(params MovementInput[] inputListToRemove)
    {
        if (!movementInputList.Any()) // MovementInput list is empty 
        {
            movementInputList.Add(MovementInput.STOP);
            return MovementInput.STOP;
        }
        else // MovementInput list not empty
        {
            foreach (MovementInput inputToRemove in inputListToRemove)
            {
                movementInputList.RemoveAll(input => input == inputToRemove);
            }
            return movementInputList.Max();
        }
    }
    private void RemoveFromActionInputList(params ActionInput[] inputListToRemove)
    {
        foreach (ActionInput inputToRemove in inputListToRemove)
        {
            actionInputList.RemoveAll(input => input == inputToRemove);
        }
    }
    private void EvaluateMovementInput(MovementInput input)
    {
        if (playerCharacterData.playerHasControl)
        {
            switch (input)
            {
                case MovementInput.MOVE_RIGHT:
                    //Debug.Log("Move Right performed");
                    playerMovement.MoveWithTurn(playerCharacterData.moveSpeed);
                    break;
                case MovementInput.MOVE_LEFT:
                    //Debug.Log("Move Left performed");
                    playerMovement.MoveWithTurn(-playerCharacterData.moveSpeed);
                    break;
                case MovementInput.CROUCH:
                    //Debug.Log("Crouch performed");
                    break;
                case MovementInput.DASH:
                    //Debug.Log("Dash performed");
                    break;
                case MovementInput.JUMP:
                    //Debug.Log("Jump performed");
                    playerMovement.Jump(playerCharacterData.jumpVelocity);
                    break;
                case MovementInput.DODGE:
                    //Debug.Log("Dodge performed");
                    break;
                default:
                    //Debug.Log("Stop performed");
                    playerMovement.StopHorizontal();
                    break;
            }
        }
    }
    private void EvaluateActionInput(ActionInput input)
    {
        if (playerCharacterData.playerHasControl)
        {
            switch (input)
            {
                case ActionInput.UP:
                    //Debug.Log("Up performed");
                    break;
                case ActionInput.PRIMARY:
                    //Debug.Log("Primary performed");
                    break;
                case ActionInput.SECONDARY:
                    //Debug.Log("Secondary performed");
                    break;
                case ActionInput.UTILITY_1:
                    //Debug.Log("Utility 1 performed");
                    break;
                case ActionInput.UTILITY_2:
                    //Debug.Log("Utility 2 performed");
                    break;
                default:
                    //Debug.Log("No action performed");
                    break;
            }
        }
    }
    private void EvaluateActionInputs()
    {
        actionInputList.ForEach(input => EvaluateActionInput(input));
    }

    private void EvaluateCombo(int inputValue)
    {
        comboInputCurrentTime = Time.time;
        //check if previous inputs have expired in potential combo
        float livedTime = comboInputCurrentTime - comboInputInitialTime;
        if (livedTime > GameConstants.COMBO_INPUT_LIFESPAN_IN_SECONDS) // combo invalid; input delay too large
        {
            //reset combo
            currentComboPosition = 0;
        }

        if (currentComboPosition == 0) //if input is the start of a new potential combo
        {
            comboInputInitialTime = Time.time;
        }

        if (ComboSystem.NarrowCombo(inputValue, currentComboPosition)) //input part of a valid combo
        {
            currentComboPosition++;
        }
        else // input invalid for current combo OR input was the last in combo sequence and combo was performed
        {
            currentComboPosition = 0;
        }
    }
    private void PauseGame()
    {
        Debug.Log("Pause Game Button Pressed");
    }
}
