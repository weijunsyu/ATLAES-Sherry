using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    //Config Parameters:

    // Cached References:
    [SerializeField] private PlayerOnlyMovement playerMovement = null;
    [SerializeField] private PlayerAction playerAction = null;
    [SerializeField] private ComboSystem comboSystem = null;
    [SerializeField] private PlayerAnimationController playerStateController = null;
    private PlayerControls playerControls;

    // State Parameters and Objects:
    private List<OrderedInput> orderedInputList = new List<OrderedInput>(); //should never be emtpy as character should be STOP if not doing anything
    private List<UnorderedInput> unorderedInputList = new List<UnorderedInput>(); //when empty it means no action is being performed at current point in time
    private bool aimAttackIsSecondary; //toggle aim attack between primary and secondary attack (used only in controller input)
    private Coroutine dashRoutine = null;
    private bool isEvaluatingCharacterInputs = true;


    // Unity Events:
    private void Awake()
    {
        playerControls = new PlayerControls();

        // Move Right
        playerControls.MouseAndKeyboard.MoveRight.performed += ctx => OrderedAddEvaluate(OrderedInput.MOVE_RIGHT);
        playerControls.MouseAndKeyboard.MoveRight.canceled += ctx => OrderedRemoveEvaluate(OrderedInput.MOVE_RIGHT);
        playerControls.GamepadController.MoveRight.performed += ctx => OrderedAddEvaluate(OrderedInput.MOVE_RIGHT);
        playerControls.GamepadController.MoveRight.canceled += ctx => OrderedRemoveEvaluate(OrderedInput.MOVE_RIGHT);
        // Move Left
        playerControls.MouseAndKeyboard.MoveLeft.performed += ctx => OrderedAddEvaluate(OrderedInput.MOVE_LEFT);
        playerControls.MouseAndKeyboard.MoveLeft.canceled += ctx => OrderedRemoveEvaluate(OrderedInput.MOVE_LEFT);
        playerControls.GamepadController.MoveLeft.performed += ctx => OrderedAddEvaluate(OrderedInput.MOVE_LEFT);
        playerControls.GamepadController.MoveLeft.canceled += ctx => OrderedRemoveEvaluate(OrderedInput.MOVE_LEFT);
        // Jump
        playerControls.MouseAndKeyboard.Jump.started += ctx => OrderedAddEvaluateRemove(OrderedInput.JUMP);
        playerControls.GamepadController.Jump.started += ctx => OrderedAddEvaluateRemove(OrderedInput.JUMP);

        // Crouch
        playerControls.MouseAndKeyboard.Crouch.performed += ctx => UnorderedAddEvaluate(UnorderedInput.CROUCH);
        playerControls.MouseAndKeyboard.Crouch.canceled += ctx => { UnorderedRemoveEvaluate(UnorderedInput.CROUCH); playerMovement.Stand(); };
        playerControls.GamepadController.Crouch.performed += ctx => UnorderedAddEvaluate(UnorderedInput.CROUCH);
        playerControls.GamepadController.Crouch.canceled += ctx => { UnorderedRemoveEvaluate(UnorderedInput.CROUCH); playerMovement.Stand(); };

        // Up
        playerControls.MouseAndKeyboard.Up.performed += ctx => UnorderedAddEvaluate(UnorderedInput.UP);
        playerControls.MouseAndKeyboard.Up.canceled += ctx => UnorderedRemoveEvaluate(UnorderedInput.UP);
        playerControls.GamepadController.Up.performed += ctx => UnorderedAddEvaluate(UnorderedInput.UP);
        playerControls.GamepadController.Up.canceled += ctx => UnorderedRemoveEvaluate(UnorderedInput.UP);

        // Defend
        playerControls.MouseAndKeyboard.Defend.performed += ctx => StartDefend();
        playerControls.MouseAndKeyboard.Defend.canceled += ctx => StopDefend();
        playerControls.GamepadController.Defend.performed += ctx => StartDefend();
        playerControls.GamepadController.Defend.canceled += ctx => StopDefend();
        // Dash
        playerControls.MouseAndKeyboard.Dash.started += ctx => Dash();
        playerControls.GamepadController.Dash.started += ctx => Dash();

        // Primary
        playerControls.MouseAndKeyboard.Primary.performed += ctx => UnorderedAddEvaluate(UnorderedInput.PRIMARY);
        playerControls.MouseAndKeyboard.Primary.canceled += ctx => UnorderedRemoveEvaluate(UnorderedInput.PRIMARY);
        playerControls.GamepadController.Primary.performed += ctx => UnorderedAddEvaluate(UnorderedInput.PRIMARY);
        playerControls.GamepadController.Primary.canceled += ctx => UnorderedRemoveEvaluate(UnorderedInput.PRIMARY);
        // Secondary
        playerControls.MouseAndKeyboard.Secondary.performed += ctx => UnorderedAddEvaluate(UnorderedInput.SECONDARY);
        playerControls.MouseAndKeyboard.Secondary.canceled += ctx => UnorderedRemoveEvaluate(UnorderedInput.SECONDARY);
        playerControls.GamepadController.Secondary.performed += ctx => UnorderedAddEvaluate(UnorderedInput.SECONDARY);
        playerControls.GamepadController.Secondary.canceled += ctx => UnorderedRemoveEvaluate(UnorderedInput.SECONDARY);
        // Utility 1
        playerControls.MouseAndKeyboard.Utility1.performed += ctx => UnorderedAddEvaluate(UnorderedInput.UTILITY_1);
        playerControls.MouseAndKeyboard.Utility1.canceled += ctx => UnorderedRemoveEvaluate(UnorderedInput.UTILITY_1);
        playerControls.GamepadController.Utility1.performed += ctx => UnorderedAddEvaluate(UnorderedInput.UTILITY_1);
        playerControls.GamepadController.Utility1.canceled += ctx => UnorderedRemoveEvaluate(UnorderedInput.UTILITY_1);
        // Utility 2
        playerControls.MouseAndKeyboard.Utility2.performed += ctx => UnorderedAddEvaluate(UnorderedInput.UTILITY_2);
        playerControls.MouseAndKeyboard.Utility2.canceled += ctx => UnorderedRemoveEvaluate(UnorderedInput.UTILITY_2);
        playerControls.GamepadController.Utility2.performed += ctx => UnorderedAddEvaluate(UnorderedInput.UTILITY_2);
        playerControls.GamepadController.Utility2.canceled += ctx => UnorderedRemoveEvaluate(UnorderedInput.UTILITY_2);

        // MOUSE ONLY:
        // Aim
        playerControls.MouseAndKeyboard.Aim.performed += ctx => FreeAim(ctx.ReadValue<Vector2>());

        // GAMEPAD ONLY:
        // Aim Attack (primary attack on direction aimed)
        playerControls.GamepadController.AimAttack.performed += ctx => AimAttack(ctx.ReadValue<Vector2>());
        // Hold Secondary Aim Attack Mode (hold to switch Aim Attack to Secondary from Primary)
        playerControls.GamepadController.HoldSecondaryAimAttack.performed += ctx => aimAttackIsSecondary = true;
        playerControls.GamepadController.HoldSecondaryAimAttack.canceled += ctx => aimAttackIsSecondary = false;

    }

    private void OnEnable()
    {
        // Reset state parameters and objects:
        orderedInputList.Clear();
        orderedInputList.Add(OrderedInput.STOP); //orderedInputList should always have stop
        unorderedInputList.Clear();
        aimAttackIsSecondary = false;

        // Enable virtual controller:
        playerControls.Enable();
    }
    private void Update()
    {
        ReEvaluateOrderedInput();
    }
    private void OnDisable()
    {
        playerControls.Disable();
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
    }
    private void UnorderedAddEvaluate(UnorderedInput input)
    {
        AddToUnorderedInputList(input);
        EvaluateUnorderedInputs();
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
        if (isEvaluatingCharacterInputs)
        {
            switch (input)
            {
                case OrderedInput.MOVE_RIGHT:
                    //Debug.Log("Move Right performed");
                    playerMovement.Move(OrderedInput.MOVE_RIGHT);
                    // if sliding: do stuff
                    playerStateController.SetAnimationState(PlayerAnimationState.WALK);
                    break;
                case OrderedInput.MOVE_LEFT:
                    //Debug.Log("Move Left performed");
                    playerMovement.Move(OrderedInput.MOVE_LEFT);
                    // if sliding: do stuff
                    playerStateController.SetAnimationState(PlayerAnimationState.WALK);
                    break;
                case OrderedInput.DASH:
                    //Debug.Log("Dash performed");
                    playerMovement.DashMove();
                    break;
                case OrderedInput.JUMP:
                    //Debug.Log("Jump performed");
                    if (playerStateController.GetAnimationState() == PlayerAnimationState.DASH)
                    {
                        EndDash();
                    }
                    playerMovement.Jump();
                    playerStateController.SetAnimationState(PlayerAnimationState.JUMP);
                    break;
                case OrderedInput.DEFEND:
                    //Debug.Log("Defend performed");
                    if (playerStateController.GetAnimationState() == PlayerAnimationState.DASH)
                    {
                        EndDash();
                    }
                    playerMovement.StopAll();
                    playerAction.DefendAction();
                    playerStateController.SetAnimationState(PlayerAnimationState.DEFEND);
                    break;
                default:
                    //Debug.Log("Stop performed");
                    playerMovement.StopHorizontal();
                    playerStateController.SetAnimationState(PlayerAnimationState.IDLE);
                    break;
            }
        }
    }
    private void EvaluateUnorderedInput(UnorderedInput input)
    {
        if (isEvaluatingCharacterInputs)
        {
            switch (input)
            {
                case UnorderedInput.CROUCH:
                    //Debug.Log("Crouch performed");
                    if (playerStateController.GetAnimationState() == PlayerAnimationState.DASH)
                    {
                        EndDash();
                    }
                    playerMovement.Crouch();
                    playerStateController.SetAnimationState(PlayerAnimationState.CROUCH);
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
        if ((playerStateController.GetAnimationState() != PlayerAnimationState.DASH) && playerMovement.CanDash() && !playerMovement.GetIsSliding())
        {
            dashRoutine = StartCoroutine(DashRoutine());
        }
    }
    IEnumerator DashRoutine()
    {
        playerStateController.SetAnimationState(PlayerAnimationState.DASH);
        OrderedAddEvaluate(OrderedInput.DASH);
        playerMovement.Crouch();
        yield return new WaitForSeconds(MasterManager.playerCharacterNonPersistData.GetDashDuration());
        OrderedRemoveEvaluate(OrderedInput.DASH);
        playerMovement.Stand();
        playerStateController.SetAnimationState(PlayerAnimationState.IDLE);
    }
    private void EndDash()
    {
        StopCoroutine(dashRoutine);
        RemoveFromOrderedInputList(OrderedInput.DASH);
        playerMovement.Stand();
        playerStateController.SetAnimationState(PlayerAnimationState.IDLE);
    }
    private void StartDefend()
    {
        playerMovement.Defend(true);
        OrderedAddEvaluate(OrderedInput.DEFEND);
        isEvaluatingCharacterInputs = false;
    }
    private void StopDefend()
    {
        playerMovement.Defend(false);
        isEvaluatingCharacterInputs = true;
        OrderedRemoveEvaluate(OrderedInput.DEFEND);
    }
}
