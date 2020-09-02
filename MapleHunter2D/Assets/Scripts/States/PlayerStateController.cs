using UnityEngine;

public class PlayerStateController : AbstractStateController
{
    //Config Parameters:

    // Cached References:

    // State Parameters and Objects:
    private Idle idle;

    private bool playerHasCharacterControl = true;


    // Unity Events:
    protected override void Awake()
    {
        base.Awake();
        InitializeStates();
    }

    // Class Functions:
    public bool GetPlayerHasCharacterControl()
    {
        return playerHasCharacterControl;
    }
    public void SetPlayerHasCharacterControl(bool value)
    {
        playerHasCharacterControl = value;
    }
    private void InitializeStates()
    {
        idle = new Idle(0, animationController, movementController);
    }
}
