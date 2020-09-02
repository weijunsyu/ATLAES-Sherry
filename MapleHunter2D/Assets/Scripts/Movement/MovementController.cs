using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class MovementController : MonoBehaviour
{
    // Config Parameters:

    // Cached References:
    [SerializeField] public LayerMask groundLayer;
    
    [HideInInspector] private Rigidbody2D body;
    [HideInInspector] private BoxCollider2D boxCollider;

    // Public Variables:
    [HideInInspector] public Vector2 standColliderSize;
    [HideInInspector] public Vector2 standColliderOffset;

    // State Parameters and Objects:
    private bool isFacingRight = true;
    private bool isAirborne = false;
    

    // Unity Events:
    private void Awake()
    {
        body = this.GetComponent<Rigidbody2D>();
        boxCollider = this.GetComponent<BoxCollider2D>();
        standColliderSize = boxCollider.size;
        standColliderOffset = boxCollider.offset;
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
    public void Turn()
    {
        this.transform.Rotate(0f, 180f, 0);
        isFacingRight = !isFacingRight;
    }
}
