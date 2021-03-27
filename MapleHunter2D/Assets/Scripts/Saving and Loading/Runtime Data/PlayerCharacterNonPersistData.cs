
public class PlayerCharacterNonPersistData
{
    // Player Character Data
    private float moveSpeed = GameConstants.PLAYER_BASE_WALK_MOVE_SPEED;
    private float jumpVelocity = GameConstants.PLAYER_BASE_GROUND_JUMP_VELOCITY;
    private float airJumpVelocity = GameConstants.PLAYER_BASE_AIR_JUMP_VELOCITY;
    private int maxAirJumps = GameConstants.PLAYER_NUMBER_AIR_JUMP;
    private float dashSpeed = GameConstants.PLAYER_BASE_DASH_SPEED;
    private float dashDuration = GameConstants.PLAYER_BASE_DASH_DURATION;




    // Class Functions:
    public void ResetAllPlayerCharacterNonPersistData()
    {
        SetMoveSpeed(GameConstants.PLAYER_BASE_WALK_MOVE_SPEED);
        SetJumpVelocity(GameConstants.PLAYER_BASE_GROUND_JUMP_VELOCITY);
        SetAirJumpVelocity(GameConstants.PLAYER_BASE_AIR_JUMP_VELOCITY);
        SetMaxAirJumps(GameConstants.PLAYER_NUMBER_AIR_JUMP);
        SetDashSpeed(GameConstants.PLAYER_BASE_DASH_SPEED);
        SetDashDuration(GameConstants.PLAYER_BASE_DASH_DURATION);
    }
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
    public void ModifyMoveSpeed(float value)
    {
        moveSpeed = StaticFunctions.ModifyResourceValue(moveSpeed, value);
    }
    public bool SetMoveSpeed(float value)
    {
        moveSpeed = value;
        if (value < 0)
        {
            return false;
        }
        return true;
    }
    public float GetJumpVelocity()
    {
        return jumpVelocity;
    }
    public void ModifyJumpVelocity(float value)
    {
        jumpVelocity = StaticFunctions.ModifyResourceValue(jumpVelocity, value);
    }
    public void SetJumpVelocity(float value)
    {
        jumpVelocity = value;
    }
    public float GetAirJumpVelocity()
    {
        return airJumpVelocity;
    }
    public void ModifyAirJumpVelocity(float value)
    {
        airJumpVelocity = StaticFunctions.ModifyResourceValue(airJumpVelocity, value);
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
    public int GetMaxAirJumps()
    {
        return maxAirJumps;
    }
    public void SetMaxAirJumps(int value)
    {
        maxAirJumps = value;
    }
    public float GetDashSpeed()
    {
        return dashSpeed;
    }
    public void ModifyDashSpeed(float value)
    {
        dashSpeed = StaticFunctions.ModifyResourceValue(dashSpeed, value);
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
        dashDuration = StaticFunctions.ModifyResourceValue(dashDuration, value);
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
}
