using UnityEngine;

public static class PlayerOnlyMovement
{



    // State Parameters and Objects:
    private float jumpDelayTimer = 0f;
    private float coyoteJumpTimer = 0f; // Timer run after initial airborne transition to determine if player can still jump
    private float jumpBufferTimer = 0f; // Timer run after jump input to determine if player can jump if input was early
    private bool jumpbufferToggle = false; // Toggle if jumpBufferTimer should start or stop

    private int airJumpsPerformed = 0;
    private bool attemptingStand = false;
    private bool canGroundJump = true;
    private bool canDash = true;
    private bool isFacingWall = false;
    private bool isSliding = false;
    private bool inputRight = false;
    private bool inputLeft = false;
    private bool isDefending = false;


    // Unity Events:
    private void Update()
    {
        if (jumpbufferToggle)
        {
            jumpBufferTimer += Time.deltaTime;
        }
        coyoteJumpTimer += Time.deltaTime;
        if (!canGroundJump)
        {
            jumpDelayTimer += Time.deltaTime;
        }
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (isDefending)
        {
            if (body.velocity.y < GameConstants.FLOATING_MAX_DROP_SPEED)
            {
                body.velocity = new Vector2(body.velocity.x, GameConstants.FLOATING_MAX_DROP_SPEED);
            }
        }
        if (!UpdateAirborne()) // If not airborne (and update update airbourne value)
        {
            if(jumpDelayTimer > GameConstants.JUMP_RESET_DELAY)
            {
                canGroundJump = true;
                jumpDelayTimer = 0;
            }
            canDash = true;
            airJumpsPerformed = 0;
            coyoteJumpTimer = 0;
            // Performe jump if jump buffer valid and player initiated a jump prior
            if (jumpbufferToggle && (jumpBufferTimer < GameConstants.JUMP_BUFFER))
            {
                Jump();
                jumpbufferToggle = false; // Reset buffer toggle
            }
        }
        if (attemptingStand) // If currently trying to stand
        {
            if (CanStand()) // If can stand
            {
                Stand();
                attemptingStand = false;
            }
        }
        int facingDirection = CheckFront();
        if (isFacingWall && IsAirborne())
        {
            if (facingDirection == 1 && inputRight) // Facing right and pressing right input
            {
                isSliding = true;
                Slide();
                canDash = true;
            }
            else if (facingDirection == -1 && inputLeft) // Facing left and pressing left input
            {
                isSliding = true;
                Slide();
                canDash = true;
            }
            else
            {
                isSliding = false;
            }
        }
        else
        {
            isSliding = false;
        }
    }

    // Class Functions:
    public bool GetIsSliding()
    {
        return isSliding;
    }
    public void SetInputRight(bool value)
    {
        inputRight = value;
    }
    public void SetInputLeft(bool value)
    {
        inputLeft = value;
    }
    public void Move(OrderedInput direction)
    {
        if (direction == OrderedInput.MOVE_RIGHT)
        {
            MoveWithTurn(MasterManager.playerCharacterNonPersistData.GetMoveSpeed(), 1);
        }
        else
        {
            MoveWithTurn(-MasterManager.playerCharacterNonPersistData.GetMoveSpeed(), -1);
        }
    }
    
    public void Jump()
    {
        // Early input forgiveness
        if (IsAirborne()) // (Is airborne) Cannot jump:
        {
            jumpbufferToggle = true; // Set buffer toggle
            jumpBufferTimer = 0; // Reset jumpBufferTimer
        }

        //Late input forgiveness and perform jump
        if (canGroundJump && coyoteJumpTimer < GameConstants.COYOTE_JUMP_DELAY)
        {
            SetVertical(MasterManager.playerCharacterNonPersistData.GetJumpVelocity());
            canGroundJump = false;
        }
        else
        {
            if (airJumpsPerformed++ < MasterManager.playerCharacterNonPersistData.GetMaxAirJumps())
            {
                SetVertical(MasterManager.playerCharacterNonPersistData.GetAirJumpVelocity());
                jumpbufferToggle = false; // Reset buffer toggle if jump press wasn't meant for ground jump
            }
            else //prevent integer overflow (from spamming jump in air)
            {
                airJumpsPerformed = MasterManager.playerCharacterNonPersistData.GetMaxAirJumps();
            }
        }
    }
}
