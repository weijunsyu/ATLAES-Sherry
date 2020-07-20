using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // List of all valid inputs in order of importance from least to most important
    // (more imortant inputs override less important imputs)
    enum MovementInput
    {
        STOP, //stop in horizontal plane only (gravity is a thing)
        MOVE_RIGHT,
        MOVE_LEFT,
        JUMP,
        DASH
    }
    enum ActionInput
    {
        STOP, //stop all actions
        ATTACK
    }

    private VirtualController virtualController = null;

    private List<MovementInput> movementInputList = new List<MovementInput>(); //should never be emtpy as character should be STOP if not doing anything
    private List<ActionInput> actionInputList = new List<ActionInput>(); //should never be emtpy as character should be STOP if not doing anything

    private void Awake()
    {
        virtualController = new VirtualController();
        /*
         * Right now movement stops if player collides with walls etc that stop body velocity thus to restart movement
         * check for collision with ground and ReEvaluateMovementInput() at that time
         */
        //Move Right
        virtualController.PlayerCharacter.MoveRight.performed += ctx => MovementAddEvaluate(MovementInput.MOVE_RIGHT);
        virtualController.PlayerCharacter.MoveRight.canceled += ctx => MovementRemoveEvaluate(MovementInput.MOVE_RIGHT);
        //Move Left
        virtualController.PlayerCharacter.MoveLeft.performed += ctx => MovementAddEvaluate(MovementInput.MOVE_LEFT);
        virtualController.PlayerCharacter.MoveLeft.canceled += ctx => MovementRemoveEvaluate(MovementInput.MOVE_LEFT);

        //Jump
        virtualController.PlayerCharacter.Jump.started += ctx => MovementAddEvaluateRemove(MovementInput.JUMP);

        //Dash
        virtualController.PlayerCharacter.Dash.performed += ctx => MovementAddEvaluate(MovementInput.DASH);
        virtualController.PlayerCharacter.Dash.canceled += ctx => MovementRemoveEvaluate(MovementInput.DASH);
    }

    private void OnEnable()
    {
        virtualController.Enable();
    }
    private void Start()
    {
        movementInputList.Add(MovementInput.STOP); //movementInputList should always have stop
    }

    private void OnDisable()
    {
        virtualController.Disable();
    }

    public void ReEvaluateMovementInput()
    {
        EvaluateMovementInput(movementInputList.Max());
    }

    private void MovementAddEvaluate(MovementInput input)
    {
        MovementInput newInput = AddToMovementInputList(input);
        EvaluateMovementInput(newInput);
    }
    private void MovementRemoveEvaluate(MovementInput input)
    {
        MovementInput newInput = RemoveFromMovementInputList(input);
        EvaluateMovementInput(newInput);
    }
    private void MovementAddEvaluateRemove(MovementInput input)
    {
        MovementAddEvaluate(input);
        MovementRemoveEvaluate(input);
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
    private void EvaluateMovementInput(MovementInput input)
    {
        switch (input)
        {
            case MovementInput.MOVE_RIGHT:
                Movement.Move(this.gameObject, PlayerCharacterData.moveSpeed);
                break;
            case MovementInput.MOVE_LEFT:
                Movement.Move(this.gameObject, -PlayerCharacterData.moveSpeed);
                break;
            case MovementInput.JUMP:
                Movement.Jump(this.gameObject, PlayerCharacterData.jumpVelocity);
                break;
            case MovementInput.DASH:
                break;
            default:
                Movement.StopHorizontal(this.gameObject);
                break;
        }
    }
    private void EvaluateActionInput(ActionInput input)
    {
        switch (input)
        {
            case ActionInput.ATTACK:
                break;
            default:
                break;
        }
    }
}
