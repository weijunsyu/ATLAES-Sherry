using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    //Config Parameters:

    // Cached References:
    [SerializeField] private PlayerCharacterData playerCharacterData = null;
    [SerializeField] private PlayerMovement playerMovement = null;
    [SerializeField] private PlayerAction playerAction = null;
    private VirtualController virtualController;

    // State Parameters and Objects:
    private List<OrderedInput> orderedInputList = new List<OrderedInput>(); //should never be emtpy as character should be STOP if not doing anything
    private List<UnorderedInput> unorderedInputList = new List<UnorderedInput>(); //when empty it means no action is being performed at current point in time
    private bool aimAttackIsSecondary; //toggle aim attack between primary and secondary attack (used only in controller input)
    private int currentComboPosition; //stores the current number of inputs in potential combo
    private float comboInputInitialTime; //store the time when potential combo starts
    private float comboInputCurrentTime; //stores the current time (used to find delta time between combo start and combo evaluation
    private Coroutine dashRoutine = null;
    private bool isDashing = false;
    private bool isEvaluatingInputs = true;


    // Unity Events:
    private void Awake()
    {
        virtualController = new VirtualController();
        
        // Move Right
        virtualController.MouseAndKeyboard.MoveRight.performed += ctx => { OrderedAddEvaluate(OrderedInput.MOVE_RIGHT); playerMovement.SetInputRight(true); };
        virtualController.MouseAndKeyboard.MoveRight.canceled += ctx => { OrderedRemoveEvaluate(OrderedInput.MOVE_RIGHT); playerMovement.SetInputRight(false); };
        virtualController.GamepadController.MoveRight.performed += ctx => { OrderedAddEvaluate(OrderedInput.MOVE_RIGHT); playerMovement.SetInputRight(true); };
        virtualController.GamepadController.MoveRight.canceled += ctx => { OrderedRemoveEvaluate(OrderedInput.MOVE_RIGHT); playerMovement.SetInputRight(false); };
        // Move Left
        virtualController.MouseAndKeyboard.MoveLeft.performed += ctx => { OrderedAddEvaluate(OrderedInput.MOVE_LEFT); playerMovement.SetInputLeft(true); };
        virtualController.MouseAndKeyboard.MoveLeft.canceled += ctx => { OrderedRemoveEvaluate(OrderedInput.MOVE_LEFT); playerMovement.SetInputLeft(false); };
        virtualController.GamepadController.MoveLeft.performed += ctx => { OrderedAddEvaluate(OrderedInput.MOVE_LEFT); playerMovement.SetInputLeft(true); };
        virtualController.GamepadController.MoveLeft.canceled += ctx => { OrderedRemoveEvaluate(OrderedInput.MOVE_LEFT); playerMovement.SetInputLeft(false); };
        // Jump
        virtualController.MouseAndKeyboard.Jump.started += ctx => OrderedAddEvaluateRemove(OrderedInput.JUMP);
        virtualController.GamepadController.Jump.started += ctx => OrderedAddEvaluateRemove(OrderedInput.JUMP);

        // Crouch
        virtualController.MouseAndKeyboard.Crouch.performed += ctx => UnorderedAddEvaluate(UnorderedInput.CROUCH);
        virtualController.MouseAndKeyboard.Crouch.canceled += ctx => { UnorderedRemoveEvaluate(UnorderedInput.CROUCH); playerMovement.Stand(); };
        virtualController.GamepadController.Crouch.performed += ctx => UnorderedAddEvaluate(UnorderedInput.CROUCH);
        virtualController.GamepadController.Crouch.canceled += ctx => { UnorderedRemoveEvaluate(UnorderedInput.CROUCH); playerMovement.Stand(); };

        // Up
        virtualController.MouseAndKeyboard.Up.performed += ctx => UnorderedAddEvaluate(UnorderedInput.UP);
        virtualController.MouseAndKeyboard.Up.canceled += ctx => UnorderedRemoveEvaluate(UnorderedInput.UP);
        virtualController.GamepadController.Up.performed += ctx => UnorderedAddEvaluate(UnorderedInput.UP);
        virtualController.GamepadController.Up.canceled += ctx => UnorderedRemoveEvaluate(UnorderedInput.UP);

        // Defend
        virtualController.MouseAndKeyboard.Defend.performed += ctx => StartDefend();
        virtualController.MouseAndKeyboard.Defend.canceled += ctx => StopDefend();
        virtualController.GamepadController.Defend.performed += ctx => StartDefend();
        virtualController.GamepadController.Defend.canceled += ctx => StopDefend();
        // Dash
        virtualController.MouseAndKeyboard.Dash.started += ctx => Dash();
        virtualController.GamepadController.Dash.started += ctx => Dash();

        // Primary
        virtualController.MouseAndKeyboard.Primary.performed += ctx => UnorderedAddEvaluate(UnorderedInput.PRIMARY);
        virtualController.MouseAndKeyboard.Primary.canceled += ctx => UnorderedRemoveEvaluate(UnorderedInput.PRIMARY);
        virtualController.GamepadController.Primary.performed += ctx => UnorderedAddEvaluate(UnorderedInput.PRIMARY);
        virtualController.GamepadController.Primary.canceled += ctx => UnorderedRemoveEvaluate(UnorderedInput.PRIMARY);
        // Secondary
        virtualController.MouseAndKeyboard.Secondary.performed += ctx => UnorderedAddEvaluate(UnorderedInput.SECONDARY);
        virtualController.MouseAndKeyboard.Secondary.canceled += ctx => UnorderedRemoveEvaluate(UnorderedInput.SECONDARY);
        virtualController.GamepadController.Secondary.performed += ctx => UnorderedAddEvaluate(UnorderedInput.SECONDARY);
        virtualController.GamepadController.Secondary.canceled += ctx => UnorderedRemoveEvaluate(UnorderedInput.SECONDARY);
        // Utility 1
        virtualController.MouseAndKeyboard.Utility1.performed += ctx => UnorderedAddEvaluate(UnorderedInput.UTILITY_1);
        virtualController.MouseAndKeyboard.Utility1.canceled += ctx => UnorderedRemoveEvaluate(UnorderedInput.UTILITY_1);
        virtualController.GamepadController.Utility1.performed += ctx => UnorderedAddEvaluate(UnorderedInput.UTILITY_1);
        virtualController.GamepadController.Utility1.canceled += ctx => UnorderedRemoveEvaluate(UnorderedInput.UTILITY_1);
        // Utility 2
        virtualController.MouseAndKeyboard.Utility2.performed += ctx => UnorderedAddEvaluate(UnorderedInput.UTILITY_2);
        virtualController.MouseAndKeyboard.Utility2.canceled += ctx => UnorderedRemoveEvaluate(UnorderedInput.UTILITY_2);
        virtualController.GamepadController.Utility2.performed += ctx => UnorderedAddEvaluate(UnorderedInput.UTILITY_2);
        virtualController.GamepadController.Utility2.canceled += ctx => UnorderedRemoveEvaluate(UnorderedInput.UTILITY_2);

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
        orderedInputList.Clear();
        orderedInputList.Add(OrderedInput.STOP); //orderedInputList should always have stop
        unorderedInputList.Clear();
        aimAttackIsSecondary = false;
        currentComboPosition = 0;
        comboInputInitialTime = 0;
        comboInputCurrentTime = 0;

        // Enable virtual controller:
        virtualController.Enable();
    }
    private void Update()
    {
        ReEvaluateOrderedInput();
    }
    private void OnDisable()
    {
        virtualController.Disable();
    }


    // Class Functions:
    private void ReEvaluateOrderedInput()
    {
        EvaluateOrderedInput(orderedInputList.Max());
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
            UnorderedAddEvaluate(UnorderedInput.SECONDARY);
        }
        else
        {
            //Debug.Log("Aim is Primary");
            UnorderedAddEvaluate(UnorderedInput.PRIMARY);
        }
        if (direction == Vector2.zero) // Reset Primary and Secondary actions when Right Stick resets at [0,0]
        {
            //Debug.Log("Aim is Reset");
            UnorderedRemoveEvaluate(UnorderedInput.SECONDARY);
            UnorderedRemoveEvaluate(UnorderedInput.PRIMARY);
        }
    }

    private void OrderedAddEvaluate(OrderedInput input)
    {
        OrderedInput newInput = AddToOrderedInputList(input);
        EvaluateOrderedInput(newInput);
        
        EvaluateCombo((int)input); //check if input is combo
    }
    private void UnorderedAddEvaluate(UnorderedInput input)
    {
        AddToUnorderedInputList(input);
        EvaluateUnorderedInputs();
        
        EvaluateCombo((int)input); //check if input is combo
    }
    private void OrderedRemoveEvaluate(OrderedInput input)
    {
        OrderedInput newInput = RemoveFromOrderedInputList(input);
        EvaluateOrderedInput(newInput);
    }
    private void UnorderedRemoveEvaluate(UnorderedInput input)
    {
        RemoveFromUnorderedInputList(input);
        EvaluateUnorderedInputs();
    }
    private void OrderedAddEvaluateRemove(OrderedInput input)
    {
        OrderedAddEvaluate(input);
        OrderedRemoveEvaluate(input);
    }
    private void UnorderedAddEvaluateRemove(UnorderedInput input)
    {
        UnorderedAddEvaluate(input);
        UnorderedRemoveEvaluate(input);
    }

    // Add OrderedInput input into list of currentInputs if not already in list and return the OrderedInput of most precedence
    private OrderedInput AddToOrderedInputList(OrderedInput input)
    {
        if (!orderedInputList.Any()) // OrderedInput list is empty 
        {
            if(input != OrderedInput.STOP) //input is NOT stop
            {
                orderedInputList.Add(OrderedInput.STOP);
                orderedInputList.Add(input);
            }
            else //input IS stop
            {
                orderedInputList.Add(input); //add stop to list
            }
            return input;
        }
        else // OrderedInput list not empty
        {
            
            if (!orderedInputList.Contains(input)) //if input does not already exist in list
            {
                orderedInputList.Add(input);
            }
            return orderedInputList.Max();
        }
    }
    private void AddToUnorderedInputList(UnorderedInput input)
    {
        if (!unorderedInputList.Contains(input))
        {
            unorderedInputList.Add(input);
        }
    }

    // Remove ALL instances of specified inputs from the input list and return the OrderedInput of most precedence or STOP in case of empty list
    private OrderedInput RemoveFromOrderedInputList(params OrderedInput[] inputListToRemove)
    {
        if (!orderedInputList.Any()) // OrderedInput list is empty 
        {
            orderedInputList.Add(OrderedInput.STOP);
            return OrderedInput.STOP;
        }
        else // OrderedInput list not empty
        {
            foreach (OrderedInput inputToRemove in inputListToRemove)
            {
                orderedInputList.RemoveAll(input => input == inputToRemove);
            }
            return orderedInputList.Max();
        }
    }
    private void RemoveFromUnorderedInputList(params UnorderedInput[] inputListToRemove)
    {
        foreach (UnorderedInput inputToRemove in inputListToRemove)
        {
            unorderedInputList.RemoveAll(input => input == inputToRemove);
        }
    }
    private void EvaluateOrderedInput(OrderedInput input)
    {
        if (isEvaluatingInputs && playerCharacterData.GetPlayerHasControl())
        {
            switch (input)
            {
                case OrderedInput.MOVE_RIGHT:
                    //Debug.Log("Move Right performed");
                    playerMovement.Move(OrderedInput.MOVE_RIGHT);
                    break;
                case OrderedInput.MOVE_LEFT:
                    //Debug.Log("Move Left performed");
                    playerMovement.Move(OrderedInput.MOVE_LEFT);
                    break;
                case OrderedInput.DASH:
                    //Debug.Log("Dash performed");
                    playerMovement.DashMove();
                    break;
                case OrderedInput.JUMP:
                    //Debug.Log("Jump performed");
                    if (isDashing)
                    {
                        EndDash();
                    }
                    playerMovement.Jump();
                    break;
                case OrderedInput.DEFEND:
                    //Debug.Log("Defend performed");
                    if (isDashing)
                    {
                        EndDash();
                    }
                    playerMovement.StopAll();
                    playerAction.DefendAction();
                    break;
                default:
                    //Debug.Log("Stop performed");
                    playerMovement.StopHorizontal();
                    break;
            }
        }
    }
    private void EvaluateUnorderedInput(UnorderedInput input)
    {
        if (isEvaluatingInputs && playerCharacterData.GetPlayerHasControl())
        {
            switch (input)
            {
                case UnorderedInput.CROUCH:
                    //Debug.Log("Crouch performed");
                    if (isDashing)
                    {
                        EndDash();
                    }
                    playerMovement.Crouch();
                    break;
                case UnorderedInput.UP:
                    //Debug.Log("Up performed");
                    break;
                case UnorderedInput.PRIMARY:
                    //Debug.Log("Primary performed");
                    break;
                case UnorderedInput.SECONDARY:
                    //Debug.Log("Secondary performed");
                    break;
                case UnorderedInput.UTILITY_1:
                    //Debug.Log("Utility 1 performed");
                    break;
                case UnorderedInput.UTILITY_2:
                    //Debug.Log("Utility 2 performed");
                    break;
                default:
                    //Debug.Log("No action performed");
                    break;
            }
        }
    }
    private void EvaluateUnorderedInputs()
    {
        unorderedInputList.ForEach(input => EvaluateUnorderedInput(input));
    }
    private void ResetOrderedInputs()
    {
        orderedInputList.Clear();
        orderedInputList.Add(OrderedInput.STOP);
    }
    private void ResetUnorderedInputs()
    {
        unorderedInputList.Clear();
    }
    private void Dash()
    {
        if (!isDashing && playerMovement.CanDash() && !playerMovement.GetIsSliding())
        {
            dashRoutine = StartCoroutine(DashRoutine());
        }
    }
    IEnumerator DashRoutine()
    {
        isDashing = true;
        OrderedAddEvaluate(OrderedInput.DASH);
        playerMovement.Crouch();
        yield return new WaitForSeconds(playerCharacterData.GetDashDuration());
        OrderedRemoveEvaluate(OrderedInput.DASH);
        playerMovement.Stand();
        isDashing = false;
    }
    private void EndDash()
    {
        StopCoroutine(dashRoutine);
        RemoveFromOrderedInputList(OrderedInput.DASH);
        playerMovement.Stand();
        isDashing = false;
    }
    private void StartDefend()
    {
        playerMovement.Float(true);
        OrderedAddEvaluate(OrderedInput.DEFEND);
        isEvaluatingInputs = false;
    }
    private void StopDefend()
    {
        playerMovement.Float(false);
        isEvaluatingInputs = true;
        OrderedRemoveEvaluate(OrderedInput.DEFEND);
    }
    private void EvaluateCombo(int inputValue)
    {
        if (!isEvaluatingInputs)
        {
            return; // If not evaluating inputs then ignore combos
        }
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
}
