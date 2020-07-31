using UnityEngine;

public class PlayerMovement : GeneralMovement
{
    // Config parameters:
    [SerializeField] private float canJumpDelayAfterAirborneInSeconds = 0.125f;

    // Cached References:
    [SerializeField] private PlayerCharacterData playerCharacterData = null;

    // State Parameters and Objects:
    private int airJumpsPerformed = 0;
    private float canGroundJumpAfterAirborneTimer = 0; //timer run after initial airborne transition to determine if player can still jump
    private bool groundedJumpPerformed = false;

    // Unity Events:
    private void FixedUpdate()
    {
        if (!UpdateAirborne()) //check if player is airborne every physics update
        {
            ResetAirJumps();
            if (canGroundJumpAfterAirborneTimer > canJumpDelayAfterAirborneInSeconds) //prevent resetting while in air due to airborne check height
            {
                canGroundJumpAfterAirborneTimer = 0; //reset canGroundJumpAfterAirborneTimer
                groundedJumpPerformed = false; //reset ground jump counter
            }
        }
        else // player went airborne
        {
            canGroundJumpAfterAirborneTimer += Time.fixedDeltaTime;
        }
    }

    // Class Functions:
    public void MoveWithTurn(float linearVelocity)
    {
        if (linearVelocity > 0) //move to the right
        {
            if (!isFacingRight) //currently facing left
            {
                Turn(); //turn to face right
            }
        }
        else //move to left
        {
            if (isFacingRight) //currently facing right
            {
                Turn(); //turn to face left
            }
        }
        SetHorizontal(linearVelocity);
    }
    public void Jump(float linearVelocity)
    {

        if (!groundedJumpPerformed && (canGroundJumpAfterAirborneTimer < canJumpDelayAfterAirborneInSeconds))
        {
            SetVertical(linearVelocity);
            groundedJumpPerformed = true;
        }
        else
        {
            if (airJumpsPerformed++ < playerCharacterData.GetMaxAirJumps())
            {
                SetVertical(linearVelocity);
            }
            else //prevent integer overflow (from spamming jump in air)
            {
                airJumpsPerformed = playerCharacterData.GetMaxAirJumps();
            }
        }
    }
    public void StopHorizontal()
    {
        SetHorizontal(0);
    }
    private void ResetAirJumps()
    {
        airJumpsPerformed = 0;
    }
}
