using UnityEngine;

public class PlayerMovement : GeneralMovement
{
    // Config parameters:

    // Cached References:
    [SerializeField] private PlayerCharacterData playerCharacterData = null;

    // State Parameters and Objects:
    private int airJumpsPerformed = 0;
    private float coyoteJumpTimer = 0f; // Timer run after initial airborne transition to determine if player can still jump
    private float jumpBufferTimer = 0f; // Timer run after jump input to determine if player can jump if input was early
    private bool jumpbufferToggle = false; // Toggle if jumpBufferTimer should start or stop
    private Vector2 crouchColliderSize;
    private Vector2 crouchColliderOffset;
    private bool attemptingStand = false;
    private bool canGroundJump = true;
    private float jumpDelayTimer = 0f;
    private bool canDash = true;
    private bool isFacingWall = false;
    private bool inputLeft = false;
    private bool inputRight = false;
    private bool isSliding = false;


    // Unity Events:
    protected override void Awake()
    {
        base.Awake(); //do all base class awake methods first
        crouchColliderSize = new Vector2(standColliderSize.x, (standColliderSize.y / 2));
        crouchColliderOffset = new Vector2(standColliderOffset.x, ((standColliderOffset.y - standColliderSize.y) / 4));
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
        if (isFacingWall)
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
        //(boxCollider.bounds.center.y + (boxCollider.bounds.extents.y * 2))
        Vector2 overlapSize = crouchColliderSize;
        Collider2D colliderHit = Physics2D.OverlapBox(overlapCenter, overlapSize, 0f, groundLayer);
        return (colliderHit == null);
    }
    public void Crouch()
    {
        attemptingStand = false;
        SetCollider(crouchColliderSize, crouchColliderOffset);
        playerCharacterData.SetMoveSpeed(playerCharacterData.GetCrouchingMoveSpeed());
    }
    public void Stand()
    {
        if (CanStand())
        {
            SetCollider(standColliderSize, standColliderOffset);
            playerCharacterData.SetMoveSpeed(playerCharacterData.GetStandingMoveSpeed());
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
            MoveWithTurn(playerCharacterData.GetMoveSpeed());
        }
        else
        {
            MoveWithTurn(-playerCharacterData.GetMoveSpeed());
        }
    }
    public void DashMove()
    {
        if (canDash)
        {
            float linearVelocity = playerCharacterData.GetDashSpeed();
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
            SetVertical(playerCharacterData.GetJumpVelocity());
            canGroundJump = false;
        }
        else
        {
            if (airJumpsPerformed++ < playerCharacterData.GetMaxAirJumps())
            {
                SetVertical(playerCharacterData.GetAirJumpVelocity());
                jumpbufferToggle = false; // Reset buffer toggle if jump press wasn't meant for ground jump
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
                                            boxCollider.bounds.center.y - (boxCollider.bounds.extents.y / 2));
        Vector2 overlapSize = new Vector2(GameConstants.COLLISION_CHECK_DISTANCE_OFFSET,
                                          ((boxCollider.bounds.extents.y * GameConstants.SIZE_FACTOR_WALL_SLIDE)
                                                                               + GameConstants.COLLISION_CHECK_SHRINK_OFFSET));
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
