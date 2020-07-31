using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class GeneralMovement : MonoBehaviour
{
    // Config Parameters:

    // Cached References:
    [SerializeField] protected LayerMask groundLayer;
    protected Rigidbody2D body;
    protected CapsuleCollider2D capCollider;

    // State Parameters and Objects:
    protected bool isFacingRight = true;
    protected bool isAirborne = false;


    // Unity Events:
    protected virtual void Awake()
    {
        body = this.GetComponent<Rigidbody2D>();
        capCollider = this.GetComponent<CapsuleCollider2D>();
    }

    // Class Functions:
    public bool IsAirborne()
    {
        return isAirborne;
    }
    public bool UpdateAirborne()
    {
        Vector2 overlapCenter = new Vector2(capCollider.bounds.center.x, (capCollider.bounds.center.y - capCollider.bounds.extents.y));
        Vector2 overlapSize = new Vector2((capCollider.bounds.extents.x * 2) + GameConstants.IS_AIRBORNE_CHECK_BOX_X_OFFSET,
                                          GameConstants.IS_AIRBORNE_CHECK_BOX_Y_OFFSET);
        Collider2D colliderHit = Physics2D.OverlapBox(overlapCenter, overlapSize, 0f, groundLayer);

        Debug.DrawLine(overlapCenter, new Vector2(overlapCenter.x, overlapCenter.y - (overlapSize.y / 2)), Color.green);

        isAirborne = (colliderHit == null);
        return isAirborne;
    }
    public void SetAirborne(bool value)
    {
        isAirborne = value;
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
    protected void Turn()
    {
        this.transform.Rotate(0f, 180f, 0);
        isFacingRight = !isFacingRight;
    }
}
