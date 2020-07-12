using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private VirtualController virtualController = null;
    private PlayerCharacterData playerCharacterData = null;

    private bool horizontalMoveButtonPressedPrior = false;

    private void Awake()
    {
        virtualController = new VirtualController();


        //Strafe Right
        virtualController.PlayerCharacter.StrafeRight.performed += ctx => playerCharacterData.isMovingRight = true;
        virtualController.PlayerCharacter.StrafeRight.canceled += ctx => playerCharacterData.isMovingRight = false;
        //Strafe Left
        virtualController.PlayerCharacter.StrafeLeft.performed += ctx => playerCharacterData.isMovingLeft = true;
        virtualController.PlayerCharacter.StrafeLeft.canceled += ctx => playerCharacterData.isMovingLeft = false;



        //Jump
        virtualController.PlayerCharacter.Jump.performed += ctx => GetComponent<Movement>().Jump(PlayerCharacterData.jumpVelocity);
        //Dash
        virtualController.PlayerCharacter.Dash.performed += ctx => GetComponent<Movement>().Dash(10f, 1f);
        virtualController.PlayerCharacter.Dash.canceled += ctx => GetComponent<Movement>().StopHorizontal();
    }

    private void OnEnable()
    {
        virtualController.Enable();
    }
    private void Start()
    {
        playerCharacterData = GetComponent<PlayerCharacterData>();
    }
    private void FixedUpdate()
    {
        if (playerCharacterData.isMovingLeft && playerCharacterData.isMovingRight)
        {
            GetComponent<Movement>().StopHorizontal();
        }
        else if (playerCharacterData.isMovingLeft)
        {
            GetComponent<Movement>().Move(-PlayerCharacterData.moveSpeed);
            horizontalMoveButtonPressedPrior = true;
        }
        else if (playerCharacterData.isMovingRight)
        {
            GetComponent<Movement>().Move(PlayerCharacterData.moveSpeed);
            horizontalMoveButtonPressedPrior = true;
        }
        else
        {
            if (horizontalMoveButtonPressedPrior)
            {
                GetComponent<Movement>().StopHorizontal();
                horizontalMoveButtonPressedPrior = false;
            }
        }
    }

    private void OnDisable()
    {
        virtualController.Disable();
    }
}
