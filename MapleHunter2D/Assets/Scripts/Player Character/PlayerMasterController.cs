using UnityEngine;

public class PlayerMasterController : MonoBehaviour
{
    //Config Parameters:

    // Cached References:
    [SerializeField] private PlayerMovement playerMovement = null;
    [SerializeField] private PlayerAction playerAction = null;
    [SerializeField] private ComboSystem comboSystem = null;
    [SerializeField] private PlayerStateController playerStateController = null;
    [SerializeField] private PlayerInputController playerInputController = null;


    // Public Variables: (Character States)
    public bool isMoving = false;
    public bool isAirborne = false;
    public bool isDead = false;
    public bool isJumping = false;
    public bool isCrouching = false;
    public bool isSliding = false;
    public Vector2 mousePositionPixels = Vector2.zero;
    public Vector2 aimDirection;
    


    // State Parameters and Objects:
    private bool playerHasCharacterControl = true;


    // Unity Events:


    // Class Functions:
    public bool GetPlayerHasCharacterControl()
    {
        return playerHasCharacterControl;
    }
    public void SetPlayerHasCharacterControl(bool value)
    {
        playerHasCharacterControl = value;
    }

}
