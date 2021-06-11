using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class MovementController : MonoBehaviour
{
    // Config Parameters:

    // Cached References:
    [SerializeField] public LayerMask groundLayer;
    [SerializeField] public PhysicsMaterial2D standardMaterial;
    [SerializeField] public PhysicsMaterial2D slopeMaterial;
    
    [HideInInspector] public Rigidbody2D body;
    [HideInInspector] public BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;

    // Public Variables:
    [HideInInspector] public Vector2 standColliderSize;
    [HideInInspector] public Vector2 standColliderOffset;
    [HideInInspector] public Vector2 crouchColliderSize;
    [HideInInspector] public Vector2 crouchColliderOffset;
    [HideInInspector] public Vector2 jumpApexColliderSize;
    [HideInInspector] public Vector2 jumpApexColliderOffset;

    [HideInInspector] public Vector2 slopeTangent;
    [HideInInspector] public Vector2 slopeNormal;

    // State Parameters and Objects:
    private const float COLL_OFFSET_X = 0f;
    private const float COLL_SIZE_X = 0.35f;
    private const float STAND_COLL_OFFSET_Y = -0.15f;
    private const float STAND_COLL_SIZE_Y = 1.2f;
    private const float CROUCH_COLL_OFFSET_Y = -0.325f;
    private const float CROUCH_COLL_SIZE_Y = 0.85f;
    private const float JUMP_COLL_OFFSET_Y = 0f;
    private const float JUMP_COLL_SIZE_Y = 0.9f;

    private bool isFacingRight = true;
    private bool isAirborne = false;
    private bool isOnSlope = false;


    // Unity Events:
    private void Awake()
    {
        body = this.GetComponent<Rigidbody2D>();
        boxCollider = this.GetComponent<BoxCollider2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        
        standColliderOffset = new Vector2(COLL_OFFSET_X, STAND_COLL_OFFSET_Y);
        standColliderSize = new Vector2(COLL_SIZE_X, STAND_COLL_SIZE_Y);
        crouchColliderOffset = new Vector2(COLL_OFFSET_X, CROUCH_COLL_OFFSET_Y);
        crouchColliderSize = new Vector2(COLL_SIZE_X, CROUCH_COLL_SIZE_Y);
        jumpApexColliderOffset = new Vector2(COLL_OFFSET_X, JUMP_COLL_OFFSET_Y);
        jumpApexColliderSize = new Vector2(COLL_SIZE_X, JUMP_COLL_SIZE_Y);

        boxCollider.offset = standColliderOffset;
        boxCollider.size = standColliderSize;

        boxCollider.enabled = true;
    }

    // Class Functions:
    public void SetCollider(Vector2 size, Vector2 offset)
    {
        boxCollider.size = size;
        boxCollider.offset = offset;
    }
    public bool IsFacingRight()
    {
        return isFacingRight;
    }
    public bool IsAirborne()
    {
        return isAirborne;
    }
    public bool IsOnSlope()
    {
        return isOnSlope;
    }
    public Vector2 GetVelocity()
    {
        return body.velocity;
    }
    public bool UpdateIsOnSlope()
    {
        Bounds bounds = boxCollider.bounds;
        Vector2 origin = new Vector2(bounds.center.x, bounds.center.y - bounds.extents.y);
        float rayLength = bounds.size.x + GameConstants.SLOPE_CHECK_RAY_LENGTH_OFFSET;
        Vector2 frontPos = origin;
        Vector2 backPos = origin;

        float slopeAngleFromVerticalFront = 0;
        float slopeAngleFromVerticalBack = 0;
        Vector2 slopeTangentFront = new Vector2();
        Vector2 slopeTangentBack = new Vector2();
        bool onSlopeFront = false;
        bool onSlopeBack = false;
        float xOffset = bounds.extents.x;

        if (IsFacingRight())
        {
            frontPos.x += xOffset;
            backPos.x -= xOffset;
        }
        else
        {
            frontPos.x -= xOffset;
            backPos.x += xOffset;
        }

        RaycastHit2D hitFront = SlopeCheck(frontPos, rayLength, ref slopeAngleFromVerticalFront,
                                           ref slopeTangentFront, ref onSlopeFront, true);
        RaycastHit2D hitBack = SlopeCheck(backPos, rayLength, ref slopeAngleFromVerticalBack,
                                          ref slopeTangentBack, ref onSlopeBack, true);

        Debug.DrawRay(frontPos, (Vector2.down * rayLength), Color.cyan);
        Debug.DrawRay(backPos, (Vector2.down * rayLength), Color.red);

        if (onSlopeFront && !onSlopeBack)
        {
            slopeTangent = slopeTangentFront;
            isOnSlope = true;
        }
        else if (!onSlopeFront && onSlopeBack)
        {
            // hitBack MUST be true:
            if (hitFront)
            {
                if (hitBack.point.y < hitFront.point.y)
                {
                    slopeTangent = Vector2.left;
                }
                else
                {
                    slopeTangent = slopeTangentBack;
                }
            }
            else
            {
                slopeTangent = slopeTangentBack;
            }
            isOnSlope = true;
        }
        else if (onSlopeFront && onSlopeBack)
        {
            slopeTangent = (slopeTangentFront + slopeTangentBack) / 2;
            isOnSlope = true;
        }
        else
        {
            isOnSlope = false;
        }
        return isOnSlope;
    }
    public bool UpdateAirborne()
    {
        Vector2 overlapCenter = new Vector2(boxCollider.bounds.center.x, (boxCollider.bounds.center.y - boxCollider.bounds.extents.y));
        Vector2 overlapSize = new Vector2((boxCollider.bounds.size.x) + GameConstants.COLLISION_CHECK_SHRINK_OFFSET,
                                          GameConstants.COLLISION_CHECK_DISTANCE_OFFSET - GameConstants.COLLISION_CHECK_SHRINK_OFFSET);
        Collider2D colliderHit = Physics2D.OverlapBox(overlapCenter, overlapSize, 0f, groundLayer);

        isAirborne = (colliderHit == null);
        return isAirborne;
    }
    public void SetAirborne(bool value)
    {
        isAirborne = value;
    }
    public void NegateGravity()
    {
        body.AddForce(-Physics.gravity * body.gravityScale);
    }
    public void SetHorizontal(float xVelocity)
    {
        Vector2 currentVelocity = body.velocity;
        Vector2 newVelocity = new Vector2(xVelocity, currentVelocity.y);
        body.velocity = newVelocity;
    }
    public void SetVertical(float yVelocity)
    {
        Vector2 currentVelocity = body.velocity;
        Vector2 newVelocity = new Vector2(currentVelocity.x, yVelocity);
        body.velocity = newVelocity;
    }
    public void AddHorizontal(float xVelocity)
    {
        Vector2 currentVelocity = body.velocity;
        Vector2 newVelocity = new Vector2((currentVelocity.x + xVelocity), currentVelocity.y);
        body.velocity = newVelocity;
    }
    public void AddVertical(float yVelocity)
    {
        Vector2 currentVelocity = body.velocity;
        Vector2 newVelocity = new Vector2(currentVelocity.x, (currentVelocity.y + yVelocity));
        body.velocity = newVelocity;
    }
    public void ImpartForce(Vector2 force)
    {
        body.AddForce(force);
    }
    public void ImpartImpulse(Vector2 force)
    {
        body.AddForce(force, ForceMode2D.Impulse);
    }
    public void FaceRight()
    {
        if (!isFacingRight)
        {
            Turn();
        }
    }
    public void FaceLeft()
    {
        if (isFacingRight)
        {
            Turn();
        }
    }
    public void Turn()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
        isFacingRight = !isFacingRight;
    }
    private RaycastHit2D SlopeCheck(Vector2 checkPosition, float checkLength, 
                                        ref float slopeAngle, ref Vector2 slopeTangent, 
                                        ref bool onSlope, bool test = false)
    {
        RaycastHit2D hit = Physics2D.Raycast(checkPosition, Vector2.down, checkLength, groundLayer);

        if (hit)
        {
            slopeNormal = hit.normal;
            slopeTangent = Vector2.Perpendicular(slopeNormal.normalized);
            slopeAngle = Vector2.Angle(slopeNormal, Vector2.up);

            if (slopeAngle == 0)
            {
                onSlope = false;
            }
            else
            {
                onSlope = true;
            }

            if (test)
            {
                Debug.DrawRay(hit.point, slopeTangent, Color.green);
                Debug.DrawRay(hit.point, slopeNormal, Color.green);
            }
        }
        else
        {
            onSlope = false;
        }
        return hit;
    }
}
