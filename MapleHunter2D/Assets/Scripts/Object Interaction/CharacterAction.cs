using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class CharacterAction : MonoBehaviour
{
    // Config Parameters:

    // Cached References:
    protected CapsuleCollider2D capCollider;

    // State Parameters and Objects:


    // Unity Events:
    protected virtual void Awake()
    {
        capCollider = this.GetComponent<CapsuleCollider2D>();
    }


    // Class Functions:
    public bool isCollidingUp()
    {
        Vector2 overlapCenter = new Vector2(capCollider.bounds.center.x, (capCollider.bounds.center.y + capCollider.bounds.extents.y));
        Vector2 overlapSize = new Vector2((capCollider.bounds.extents.x * 2), GameConstants.DIRECTIONAL_BOX_OFFSET);
        Collider2D colliderHit = Physics2D.OverlapBox(overlapCenter, overlapSize, 0f);

        Debug.DrawLine(overlapCenter, new Vector2(overlapCenter.x, overlapCenter.y + (overlapSize.y / 2)), Color.red);

        return colliderHit != null;
    }
    public bool isCollidingDown()
    {
        Vector2 overlapCenter = new Vector2(capCollider.bounds.center.x, (capCollider.bounds.center.y - capCollider.bounds.extents.y));
        Vector2 overlapSize = new Vector2((capCollider.bounds.extents.x * 2), GameConstants.DIRECTIONAL_BOX_OFFSET);
        Collider2D colliderHit = Physics2D.OverlapBox(overlapCenter, overlapSize, 0f);

        Debug.DrawLine(overlapCenter, new Vector2(overlapCenter.x, overlapCenter.y - (overlapSize.y / 2)), Color.red);

        return colliderHit != null;
    }
    public bool isCollidingRight()
    {
        Vector2 overlapCenter = new Vector2((capCollider.bounds.center.x + capCollider.bounds.extents.x), capCollider.bounds.center.y);
        Vector2 overlapSize = new Vector2(GameConstants.DIRECTIONAL_BOX_OFFSET, (capCollider.bounds.extents.y * 2));
        Collider2D colliderHit = Physics2D.OverlapBox(overlapCenter, overlapSize, 0f);

        Debug.DrawLine(overlapCenter, new Vector2(overlapCenter.x + (overlapSize.x / 2), overlapCenter.y), Color.red);

        return colliderHit != null;
    }
    public bool isCollidingLeft()
    {
        Vector2 overlapCenter = new Vector2((capCollider.bounds.center.x - capCollider.bounds.extents.x), capCollider.bounds.center.y);
        Vector2 overlapSize = new Vector2(GameConstants.DIRECTIONAL_BOX_OFFSET, (capCollider.bounds.extents.y * 2));
        Collider2D colliderHit = Physics2D.OverlapBox(overlapCenter, overlapSize, 0f);

        Debug.DrawLine(overlapCenter, new Vector2(overlapCenter.x - (overlapSize.x / 2), overlapCenter.y), Color.red);

        return colliderHit != null;
    }
}
