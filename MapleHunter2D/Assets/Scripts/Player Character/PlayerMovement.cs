using UnityEngine;

public class PlayerMovement : GeneralMovement
{
    // Config parameters:

    // Cached References:

    // State Parameters and Objects:
    private float jumpDelayTimer = 0f;
    private float coyoteJumpTimer = 0f; // Timer run after initial airborne transition to determine if player can still jump
    private float jumpBufferTimer = 0f; // Timer run after jump input to determine if player can jump if input was early
    private bool jumpbufferToggle = false; // Toggle if jumpBufferTimer should start or stop
    private Vector2 crouchColliderSize;
    private Vector2 crouchColliderOffset;
    private int airJumpsPerformed = 0;
    private bool attemptingStand = false;
    private bool canGroundJump = true;
    private bool canDash = true;
    private bool isFacingWall = false;
    private bool isSliding = false;
    private bool inputRight = false;
    private bool inputLeft = false;


    // Unity Events:
    protected override void Awake()
    {
        base.Awake(); //do all base class awake methods first
        crouchColliderSize = new Vector2(standColliderSize.x, (standColliderSize.y / 2));
        crouchColliderOffset = new Vector2(standColliderOffset.x, (standColliderOffset.y * 3));
    }
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
    public bool CanDash()
    {
        return canDash;
    }
    /* Check if player character can stand back up (assume character is already crouching or dashing)
     * Implemented by simply checking if current collider has ground collider above itself */
    public bool CanStand()
    {
        Vector2 overlapCenter = new Vector2(boxCollider.bounds.center.x, (boxCollider.bounds.center.y + crouchColliderSize.y)); // Center-top
        Vector2 overlapSize = new Vector2((crouchColliderSize.x + GameConstants.COLLISION_CHECK_SHRINK_OFFSET), crouchColliderSize.y);
        Collider2D colliderHit = Physics2D.OverlapBox(overlapCenter, overlapSize, 0f, groundLayer);
        return (colliderHit == null);
    }
    public void Crouch()
    {
        attemptingStand = false;
        SetCollider(crouchColliderSize, crouchColliderOffset);
        MasterManager.playerCharacterNonPersistData.SetMoveSpeed(GameConstants.PLAYER_BASE_CROUCH_MOVE_SPEED);
    }
    public void Stand()
    {
        if (CanStand())
        {
            SetCollider(standColliderSize, standColliderOffset);
            MasterManager.playerCharacterNonPersistData.SetMoveSpeed(GameConstants.PLAYER_BASE_STAND_MOVE_SPEED);
        }
        else
        {
            attemptingStand = true;
        }
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
    public void DashMove()
    {
        if (canDash)
        {
            float linearVelocity = MasterManager.playerCharacterNonPersistData.GetDashSpeed();
            if (!IsFacingRight()) // player is facing left
            {
                linearVelocity = -linearVelocity;
            }
            SetHorizontal(linearVelocity);
            StopVertical();
            canDash = false;
            airJumpsPerformed = 0;
        }
        StopVertical();
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
    public void StopHorizontal()
    {
        SetHorizontal(0);
    }
    public void StopVertical()
    {
        SetVertical(0);
    }
    public void StopAll()
    {
        StopHorizontal();
        StopVertical();
    }
    private int CheckFront()
    {
        int facingDirection;
        if (IsFacingRight())
        {
            facingDirection = 1;
        }
        else
        {
            facingDirection = -1;
        }
        Vector2 overlapCenter = new Vector2((boxCollider.bounds.center.x + (facingDirection * boxCollider.bounds.extents.x)),
                                            boxCollider.bounds.center.y);
        Vector2 overlapSize = new Vector2(GameConstants.COLLISION_CHECK_DISTANCE_OFFSET,
                                          ((boxCollider.bounds.extents.y * 2) + GameConstants.COLLISION_CHECK_SHRINK_OFFSET));
        Collider2D colliderHit = Physics2D.OverlapBox(overlapCenter, overlapSize, 0f, groundLayer);

        isFacingWall = (colliderHit != null);
        return facingDirection;
    }
    private void Slide()
    {
        if (body.velocity.y < GameConstants.WALL_SLIDE_MAX_DROP_SPEED)
        {
            body.velocity = new Vector2(body.velocity.x, GameConstants.WALL_SLIDE_MAX_DROP_SPEED);
        }
    }
}
