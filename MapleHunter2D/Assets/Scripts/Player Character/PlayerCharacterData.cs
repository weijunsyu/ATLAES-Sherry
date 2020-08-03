using UnityEngine;

public class PlayerCharacterData : CharacterObjectData
{
    // Config parameters:

    // Cached References:

    // State Parameters and Objects: (including: current stats and player parameters [current HP, debufs, speed, etc])
    private bool playerHasControl = true; //true if player has input control, false otherwise (Highest precedence for input control)

    private float airJumpVelocity = 8f;
    private float dashSpeed = 15f;
    private float dashDuration = 0.15f;
    private float dodgeDuration = 0.1f;
    private float crouchingMoveSpeed = 2.5f; // Speed the player can move at while crouching
    private float standingMoveSpeed = 5.5f; // Speed the player can move at while standing (default player position)


    // Skills
    private int maxAirJumps = 1;

    // Unity Events:


    // Class Functions:
    public bool GetPlayerHasControl()
    {
        return playerHasControl;
    }
    public void SetPlayerHasControl(bool value)
    {
        playerHasControl = value;
    }
    public float GetAirJumpVelocity()
    {
        return airJumpVelocity;
    }
    public void ModifyAirJumpVelocity(float value)
    {
        airJumpVelocity = ModifyResourceValue(airJumpVelocity, value);
    }
    public bool SetAirJumpVelocity(float value)
    {
        airJumpVelocity = value;
        if (value < 0)
        {
            return false;
        }
        return true;
    }
    public float GetDashSpeed()
    {
        return dashSpeed;
    }
    public void ModifyDashSpeed(float value)
    {
        dashSpeed = ModifyResourceValue(dashSpeed, value);
    }
    public bool SetDashSpeed(float value)
    {
        dashSpeed = value;
        if (value < 0)
        {
            return false;
        }
        return true;
    }
    public float GetDashDuration()
    {
        return dashDuration;
    }
    public void ModifyDashDuration(float value)
    {
        dashDuration = ModifyResourceValue(dashDuration, value);
    }
    public bool SetDashDuration(float value)
    {
        dashDuration = value;
        if (value < 0)
        {
            return false;
        }
        return true;
    }
    public float GetDodgeDuration()
    {
        return dodgeDuration;
    }
    public float GetCrouchingMoveSpeed()
    {
        return crouchingMoveSpeed;
    }
    public void SetCrouchingMoveSpeed(float value)
    {
        crouchingMoveSpeed = value;
    }
    public float GetStandingMoveSpeed()
    {
        return standingMoveSpeed;
    }
    public void SetStandingMoveSpeed(float value)
    {
        standingMoveSpeed = value;
    }
    public int GetMaxAirJumps()
    {
        return maxAirJumps;
    }
}
