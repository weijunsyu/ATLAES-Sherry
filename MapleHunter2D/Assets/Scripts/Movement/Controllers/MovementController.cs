using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class MovementController : MonoBehaviour
{
    // Config Parameters:

    // Cached References:
    [SerializeField] public LayerMask groundLayer;
    
    [HideInInspector] public Rigidbody2D body;
    [HideInInspector] public BoxCollider2D boxCollider;

    // Public Variables:
    [HideInInspector] public Vector2 standColliderSize;
    [HideInInspector] public Vector2 standColliderOffset;
    [HideInInspector] public Vector2 crouchColliderSize;
    [HideInInspector] public Vector2 crouchColliderOffset;
    [HideInInspector] public Vector2 jumpApexColliderSize;
    [HideInInspector] public Vector2 jumpApexColliderOffset;

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
    

    // Unity Events:
    private void Awake()
    {
        body = this.GetComponent<Rigidbody2D>();
        boxCollider = this.GetComponent<BoxCollider2D>();
        
        standColliderOffset = new Vector2(COLL_OFFSET_X, STAND_COLL_OFFSET_Y);
        standColliderSize = new Vector2(COLL_SIZE_X, STAND_COLL_SIZE_Y);
        crouchColliderOffset = new Vector2(COLL_OFFSET_X, CROUCH_COLL_OFFSET_Y);
        crouchColliderSize = new Vector2(COLL_SIZE_X, CROUCH_COLL_SIZE_Y);
        jumpApexColliderOffset = new Vector2(COLL_OFFSET_X, JUMP_COLL_OFFSET_Y);
        jumpApexColliderSize = new Vector2(COLL_SIZE_X, JUMP_COLL_SIZE_Y);

        boxCollider.offset = standColliderOffset;
        boxCollider.size = standColliderSize;
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
    public Vector2 GetVelocity()
    {
        return body.velocity;
    }
    public bool UpdateAirborne()
    {
        Vector2 overlapCenter = new Vector2(boxCollider.bounds.center.x, (boxCollider.bounds.center.y - boxCollider.bounds.extents.y));
        Vector2 overlapSize = new Vector2((boxCollider.bounds.extents.x * 2) + GameConstants.COLLISION_CHECK_SHRINK_OFFSET,
                                          GameConstants.COLLISION_CHECK_DISTANCE_OFFSET);
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
        this.transform.Rotate(0f, 180f, 0);
        isFacingRight = !isFacingRight;
    }
}
