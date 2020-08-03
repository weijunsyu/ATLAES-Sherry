using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class GeneralMovement : MonoBehaviour
{
    // Config Parameters:

    // Cached References:
    [SerializeField] protected LayerMask groundLayer;
    protected Rigidbody2D body;
    protected BoxCollider2D boxCollider;

    // State Parameters and Objects:
    private bool isFacingRight = true;
    private bool isAirborne = false;
    protected Vector2 standColliderSize;
    protected Vector2 standColliderOffset;
    protected bool isFloating = false;


    // Unity Events:
    protected virtual void Awake()
    {
        body = this.GetComponent<Rigidbody2D>();
        boxCollider = this.GetComponent<BoxCollider2D>();
        standColliderSize = boxCollider.size;
        standColliderOffset = boxCollider.offset;
    }
    protected virtual void FixedUpdate()
    {
        if (isFloating)
        {
            if(body.velocity.y < GameConstants.FLOATING_MAX_DROP_SPEED)
            {
                body.velocity = new Vector2(body.velocity.x, GameConstants.FLOATING_MAX_DROP_SPEED);
            }
        }
    }

    // Class Functions:
    public void Float(bool value)
    {
        if (value && !isFloating)
        {
            body.gravityScale /= GameConstants.FLOATING_BODY_GRAVITY_MODIFIER;
            isFloating = true;
        }
        else if (!value && isFloating)
        {
            body.gravityScale *= GameConstants.FLOATING_BODY_GRAVITY_MODIFIER;
            isFloating = false;
        }
    }
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
    protected void Jump(float linearVelocity)
    {
        if (!IsAirborne())
        {
            SetVertical(linearVelocity);
        }
    }
    protected void MoveWithTurn(float linearVelocity)
    {
        if (linearVelocity > 0) //move to the right
        {
            if (!IsFacingRight()) //currently facing left
            {
                Turn(); //turn to face right
            }
        }
        else //move to left
        {
            if (IsFacingRight()) //currently facing right
            {
                Turn(); //turn to face left
            }
        }
        SetHorizontal(linearVelocity);
    }
    protected void SetHorizontal(float xVelocity)
    {
        Vector2 currentVelocity = body.velocity;
        Vector2 newVelocity = new Vector2(xVelocity, currentVelocity.y);
        body.velocity = newVelocity;
    }
    protected void SetVertical(float yVelocity)
    {
        Vector2 currentVelocity = body.velocity;
        Vector2 newVelocity = new Vector2(currentVelocity.x, yVelocity);
        body.velocity = newVelocity;
    }
    protected void AddHorizontal(float xVelocity)
    {
        Vector2 currentVelocity = body.velocity;
        Vector2 newVelocity = new Vector2((currentVelocity.x + xVelocity), currentVelocity.y);
        body.velocity = newVelocity;
    }
    protected void AddVertical(float yVelocity)
    {
        Vector2 currentVelocity = body.velocity;
        Vector2 newVelocity = new Vector2(currentVelocity.x, (currentVelocity.y + yVelocity));
        body.velocity = newVelocity;
    }
    protected void Turn()
    {
        this.transform.Rotate(0f, 180f, 0);
        isFacingRight = !isFacingRight;
    }
}
