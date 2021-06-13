using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class MovementController : MonoBehaviour
{
    // Config Parameters:

    // Cached References:
    [SerializeField] public LayerMask groundLayer;
    [SerializeField] private PhysicsMaterial2D standardMaterial;
    [SerializeField] private PhysicsMaterial2D slopeMaterial;
    
    [HideInInspector] public Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private CapsuleCollider2D capsuleCollider;
    private SpriteRenderer spriteRenderer;

    // Public Variables:
    [HideInInspector] public Vector2 standColliderSize;
    [HideInInspector] public Vector2 standColliderOffset;
    [HideInInspector] public Vector2 crouchColliderSize;
    [HideInInspector] public Vector2 crouchColliderOffset;
    [HideInInspector] public Vector2 jumpApexColliderSize;
    [HideInInspector] public Vector2 jumpApexColliderOffset;

    [HideInInspector] public Vector2 slopeTangent;
    //[HideInInspector] public Vector2 slopeNormal;
    //[HideInInspector] public float slopeAngle = 0;

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
    private float prevSlopeAngle = 0;

    private bool doSetLateVelocityX = false;
    private bool doSetLateVelocityY = false;
    private float setLateVelocityX = 0;
    private float setLateVelocityY = 0;
    
    private bool doAddLateVelocityX = false;
    private bool doAddLateVelocityY = false;
    private float addLateVelocityX = 0;
    private float addLateVelocityY = 0;


    // Unity Events:
    private void Awake()
    {
        body = this.GetComponent<Rigidbody2D>();
        boxCollider = this.GetComponent<BoxCollider2D>();
        capsuleCollider = this.GetComponent<CapsuleCollider2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        
        standColliderOffset = new Vector2(COLL_OFFSET_X, STAND_COLL_OFFSET_Y);
        standColliderSize = new Vector2(COLL_SIZE_X, STAND_COLL_SIZE_Y);
        crouchColliderOffset = new Vector2(COLL_OFFSET_X, CROUCH_COLL_OFFSET_Y);
        crouchColliderSize = new Vector2(COLL_SIZE_X, CROUCH_COLL_SIZE_Y);
        jumpApexColliderOffset = new Vector2(COLL_OFFSET_X, JUMP_COLL_OFFSET_Y);
        jumpApexColliderSize = new Vector2(COLL_SIZE_X, JUMP_COLL_SIZE_Y);

        boxCollider.offset = standColliderOffset;
        boxCollider.size = standColliderSize;
        capsuleCollider.offset = standColliderOffset;
        capsuleCollider.size = standColliderSize;

        boxCollider.enabled = true;
        capsuleCollider.enabled = false;
    }

    private void LateUpdate()
    {
        if (doSetLateVelocityX)
        {
            doSetLateVelocityX = false;
            SetHorizontal(setLateVelocityX);
        }
        if (doSetLateVelocityY)
        {
            doSetLateVelocityY = false;
            SetVertical(setLateVelocityY);
        }

        if (doAddLateVelocityX)
        {
            doAddLateVelocityX = false;
            AddHorizontal(addLateVelocityX);
        }
        if (doAddLateVelocityY)
        {
            doAddLateVelocityY = false;
            AddVertical(addLateVelocityY);
        }
    }

    // Class Functions:
    public void SetPhysicsMaterialSlope(bool isSlope)
    {
        if (isSlope)
        {
            boxCollider.sharedMaterial = slopeMaterial;
            capsuleCollider.sharedMaterial = slopeMaterial;
        }
        else
        {
            boxCollider.sharedMaterial = standardMaterial;
            capsuleCollider.sharedMaterial = standardMaterial;
        }
    }
    public Bounds GetColliderBounds()
    {
        if (boxCollider.enabled)
        {
            return boxCollider.bounds;
        }
        return capsuleCollider.bounds;
    }
    public (BoxCollider2D, CapsuleCollider2D) GetColliders()
    {
        return (boxCollider, capsuleCollider);
    }
    public void SetCollider(Vector2 size, Vector2 offset)
    {
        boxCollider.size = size;
        boxCollider.offset = offset;
        capsuleCollider.size = size;
        capsuleCollider.offset = offset;
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
        Bounds bounds = GetColliderBounds();
        Vector2 origin = new Vector2(bounds.center.x, bounds.center.y);
        float rayLength = bounds.extents.y + bounds.size.x + GameConstants.SLOPE_CHECK_RAY_LENGTH_OFFSET;
        Vector2 frontPos = origin;
        Vector2 backPos = origin;

        bool onSlopeFront = false;
        bool onSlopeBack = false;
        Vector2 tangentFront = Vector2.zero;
        Vector2 tangentBack = Vector2.zero;
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

        RaycastHit2D hitFront = SlopeCheck(frontPos, rayLength,ref tangentFront, out onSlopeFront);
        RaycastHit2D hitBack = SlopeCheck(backPos, rayLength, ref tangentBack, out onSlopeBack);

        //Debug.DrawRay(frontPos, (Vector2.down * rayLength), Color.cyan);
        //Debug.DrawRay(backPos, (Vector2.down * rayLength), Color.red);

        // Collider change check:
        if (onSlopeFront || onSlopeBack)
        {
            ChangeColliderTypeToCapsule(true);
        }
        else
        {
            ChangeColliderTypeToCapsule(false);
        }

        // Entering slope from bottom or Entering slope from top
        if (onSlopeFront && !onSlopeBack)
        {
            // Slope was entered from ground state (not a dropoff past the slope)
            if (hitBack)
            {
                // Entering slope from the top
                if (hitFront.point.y < hitBack.point.y)
                {
                    isOnSlope = PerformPreciseSlopeCheck();
                }
                // Entering slope from the bottom
                else
                {
                    isOnSlope = PerformPreciseSlopeCheck();
                }
            }
            // Slope was entered from airborne state
            else
            {
                slopeTangent = tangentFront;
                isOnSlope = true;
            }
        }
        // Leaving slope from bottom or leaving slope from top
        else if (!onSlopeFront && onSlopeBack)
        {
            // Slope exits into ground (not a dropoff past the slope)
            if (hitFront)
            {
                // Exit slope from the top
                if (hitFront.point.y > hitBack.point.y)
                {
                    slopeTangent = tangentFront;
                    isOnSlope = true;
                }
                // Exist slope from the bottom
                else
                {
                    slopeTangent = tangentBack;
                    isOnSlope = true;
                }
            }
            // Slope ends in a dropoff
            else
            {
                slopeTangent = tangentBack;
                isOnSlope = true;
            }
        }
        else if (onSlopeFront && onSlopeBack)
        {
            // Middle of slope or between two slopes

            // Set the tangent as the average of the 2
            slopeTangent = (tangentFront + tangentBack) / 2;
            isOnSlope = true;
        }
        else
        {
            // Not on a slope
            isOnSlope = false;
        }
        return IsOnSlope();
    }
    public bool UpdateAirborne()
    {
        Bounds bounds = GetColliderBounds();

        Vector2 overlapCenter = new Vector2(bounds.center.x, (bounds.center.y - bounds.extents.y));
        Vector2 overlapSize = new Vector2((bounds.size.x) + GameConstants.COLLISION_CHECK_SHRINK_OFFSET,
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

    // Return true if no late velocity was set prior, false otherwise.
    public bool AddLateVelocityX(float velocity)
    {
        bool flag = !doAddLateVelocityX;
        doAddLateVelocityX = true;
        addLateVelocityX = velocity;
        return flag;
    }
    // Return true if no late velocity was set prior, false otherwise.
    public bool AddLateVelocityY(float velocity)
    {
        bool flag = !doAddLateVelocityY;
        doAddLateVelocityY = true;
        addLateVelocityY = velocity;
        return flag;
    }
    // Return true if no late velocity was set prior, false otherwise.
    public bool SetLateVelocityX(float velocity)
    {
        bool flag = !doSetLateVelocityX;
        doSetLateVelocityX = true;
        setLateVelocityX = velocity;
        return flag;
    }
    // Return true if no late velocity was set prior, false otherwise.
    public bool SetLateVelocityY(float velocity)
    {
        bool flag = !doSetLateVelocityY;
        doSetLateVelocityY = true;
        setLateVelocityY = velocity;
        return flag;
    }


    private bool PerformPreciseSlopeCheck()
    {
        Bounds bounds = GetColliderBounds();
        Vector2 checkPos = new Vector2(bounds.center.x, bounds.center.y - bounds.extents.y);
        float rayLength = bounds.extents.x + GameConstants.SLOPE_CHECK_RAY_LENGTH_OFFSET;

        bool onSlope = false;
        Vector2 horizontalTan = Vector2.zero;
        Vector2 verticalTan = Vector2.zero;

        SlopeCheckHorizontal(checkPos, rayLength, ref horizontalTan, ref onSlope);
        SlopeCheckVertical(checkPos, rayLength, ref verticalTan, ref onSlope);

        //Debug.DrawRay(checkPos, (Vector2.down * rayVerticalLength), Color.cyan);

        slopeTangent = verticalTan;

        return onSlope;
    }
    private void SlopeCheckVertical(Vector2 checkPosition, float checkLength,
                                    ref Vector2 tangent, ref bool onSlope,
                                    bool test=false)
    {
        RaycastHit2D hit = Physics2D.Raycast(checkPosition, Vector2.down, checkLength, groundLayer);

        if (hit)
        {
            Vector2 normal = hit.normal;
            tangent = Vector2.Perpendicular(normal.normalized);
            float angle = Vector2.Angle(normal, Vector2.up);

            if (angle != prevSlopeAngle)
            {
                onSlope = true;
            }

            if (test)
            {
                Debug.DrawRay(hit.point, tangent, Color.green);
                Debug.DrawRay(hit.point, normal, Color.green);
            }
        }
    }
    private void SlopeCheckHorizontal(Vector2 checkPosition, float checkLength,
                                      ref Vector2 tangent, ref bool onSlope)
    {
        RaycastHit2D hitRight = Physics2D.Raycast(checkPosition, transform.right,
                                                  checkLength, groundLayer);
        RaycastHit2D hitLeft = Physics2D.Raycast(checkPosition, -transform.right,
                                                 checkLength, groundLayer);

        //Debug.DrawRay(checkPosition, transform.right * checkLength, Color.yellow);
        //Debug.DrawRay(checkPosition, -transform.right * checkLength, Color.yellow);

        if (hitRight)
        {
            tangent = Vector2.Perpendicular(hitRight.normal.normalized);
            onSlope = true;
        }
        else if (hitLeft)
        {
            tangent = Vector2.Perpendicular(hitLeft.normal.normalized);
            onSlope = true;
        }
        else
        {
            onSlope = false;
        }
    }

    private RaycastHit2D SlopeCheck(Vector2 checkPosition, float checkLength, 
                                           ref Vector2 tangent, out bool onSlope,
                                           bool test = false)
    {
        RaycastHit2D hit = Physics2D.Raycast(checkPosition, Vector2.down, checkLength, groundLayer);

        if (hit)
        {
            Vector2 normal = hit.normal;
            tangent = Vector2.Perpendicular(normal.normalized);
            float angle = Vector2.Angle(normal, Vector2.up);

            if (angle == 0)
            {
                onSlope = false;
            }
            else
            {
                onSlope = true;
            }

            if (test)
            {
                Debug.DrawRay(hit.point, tangent, Color.green);
                Debug.DrawRay(hit.point, normal, Color.green);
            }
        }
        else
        {
            onSlope = false;
        }
        return hit;
    }
    private void ChangeColliderTypeToCapsule(bool changeToCapsule)
    {
        if (changeToCapsule)
        {
            boxCollider.enabled = false;
            capsuleCollider.enabled = true;
        }
        else
        {
            boxCollider.enabled = true;
            capsuleCollider.enabled = false;
        }
    }
}
