using UnityEngine;

/* 
 * Crouching mechanics (check head collision, crouch, stand)
 * Sliding mechanics 
 * 
 */
public static class AdvancedMovement 
{
    /* Check if player character can stand back up (assume character is already crouching or dashing)
     * Implemented by simply checking if current collider has ground collider above itself */
    public static bool CanStand(MovementController movementController)
    {
        Bounds bounds = movementController.GetColliderBounds();
        float yCenterOffset = 0.275f;
        Vector2 overlapCenter = new Vector2(bounds.center.x,
                                            movementController.transform.position.y + yCenterOffset);
        Vector2 overlapSize = new Vector2((bounds.size.x + GameConstants.COLLISION_CHECK_SHRINK_OFFSET),
                                          (movementController.standColliderSize.y - movementController.crouchColliderSize.y)
                                          + GameConstants.COLLISION_CHECK_SHRINK_OFFSET);
        Collider2D colliderHit = Physics2D.OverlapBox(overlapCenter, overlapSize, 0f, movementController.groundLayer);
        return (colliderHit == null);
    }
    public static void Crouch(MovementController movementController)
    {
        movementController.SetCollider(movementController.crouchColliderSize, movementController.crouchColliderOffset);
    }
    // Return true if character successfully stands, false if cannot stand
    public static bool Stand(MovementController movementController)
    {
        if (CanStand(movementController))
        {
            movementController.SetCollider(movementController.standColliderSize, movementController.standColliderOffset);
            return true;
        }
        else
        {
            return false;
        }
    }
    //return true if object in front of lower leg
    public static bool CheckSlide(MovementController movementController)
    {
        Bounds bounds = movementController.GetColliderBounds();
        Vector2 origin = new Vector2(bounds.center.x, bounds.center.y - (bounds.extents.y * 0.66f));
        Vector2 size = new Vector2(GameConstants.FRONT_CHECK_DISTANCE_CAST, (bounds.extents.y * 0.66f));
        Vector2 rayDirection;
        if (movementController.IsFacingRight())
        {
            rayDirection = Vector2.right;
            origin.x += bounds.extents.x;
        }
        else
        {
            rayDirection = Vector2.left;
            origin.x -= bounds.extents.x;
        }
        //Vector2 topV = new Vector2(origin.x, (origin.y + (size.y / 2)));
        //Vector2 botV = new Vector2(origin.x, (origin.y - (size.y / 2)));
        //Debug.DrawRay((Vector3)(topV), (Vector3)(rayDirection * 50f), Color.green);
        //Debug.DrawRay((Vector3)(botV), (Vector3)(rayDirection * 50f), Color.green);

        Collider2D colliderHit = Physics2D.OverlapBox(origin, size, 0, movementController.groundLayer);
        return (colliderHit != null);
    }

    //return true if object in front
    public static bool CheckFront(MovementController movementController)
    {
        Bounds bounds = movementController.GetColliderBounds();
        Vector2 origin = new Vector2(bounds.center.x, bounds.center.y);
        Vector2 size = new Vector2(GameConstants.FRONT_CHECK_DISTANCE_CAST,
                                   (bounds.size.y + GameConstants.COLLISION_CHECK_SHRINK_OFFSET));
        Vector2 rayDirection;
        if (movementController.IsFacingRight())
        {
            rayDirection = Vector2.right;
            origin.x += bounds.extents.x;
        }
        else
        {
            rayDirection = Vector2.left;
            origin.x -= bounds.extents.x;
        }
        //Vector2 topV = new Vector2(origin.x, (origin.y + (size.y / 2)));
        //Vector2 botV = new Vector2(origin.x, (origin.y - (size.y / 2)));
        //Debug.DrawRay((Vector3)(topV), (Vector3)(rayDirection * 50f), Color.green);
        //Debug.DrawRay((Vector3)(botV), (Vector3)(rayDirection * 50f), Color.green);

        Collider2D colliderHit = Physics2D.OverlapBox(origin, size, 0, movementController.groundLayer);
        return (colliderHit != null);
    }
    //return true if object behind
    public static bool CheckBack(MovementController movementController)
    {
        Bounds bounds = movementController.GetColliderBounds();
        Vector2 origin = new Vector2(bounds.center.x, bounds.center.y);
        Vector2 size = new Vector2(GameConstants.BACK_CHECK_DISTANCE_CAST, (bounds.extents.y + GameConstants.COLLISION_CHECK_SHRINK_OFFSET));
        Vector2 rayDirection;
        if (movementController.IsFacingRight())
        {
            rayDirection = Vector2.left;
            origin.x -= bounds.extents.x;
        }
        else
        {
            rayDirection = Vector2.right;
            origin.x += bounds.extents.x;
        }
        //Vector2 topV = new Vector2(origin.x, (origin.y + (size.y / 2)));
        //Vector2 botV = new Vector2(origin.x, (origin.y - (size.y / 2)));
        //Debug.DrawRay((Vector3)(topV), (Vector3)(rayDirection * 50f), Color.green);
        //Debug.DrawRay((Vector3)(botV), (Vector3)(rayDirection * 50f), Color.green);

        Collider2D colliderHit = Physics2D.OverlapBox(origin, size, 0, movementController.groundLayer);
        return (colliderHit != null);
    }
    public static bool CheckSlideFar(MovementController movementController)
    {
        Bounds bounds = movementController.GetColliderBounds();
        Vector2 origin = new Vector2(bounds.center.x, bounds.center.y - (bounds.extents.y * 0.66f));
        Vector2 size = new Vector2(GameConstants.FRONT_CHECK_FAR_DISTANCE_CAST, (bounds.extents.y * 0.66f));
        Vector2 rayDirection;
        if (movementController.IsFacingRight())
        {
            rayDirection = Vector2.right;
            origin.x += bounds.extents.x;
        }
        else
        {
            rayDirection = Vector2.left;
            origin.x -= bounds.extents.x;
        }
        //Vector2 topV = new Vector2(origin.x, (origin.y + (size.y / 2)));
        //Vector2 botV = new Vector2(origin.x, (origin.y - (size.y / 2)));
        //Debug.DrawRay((Vector3)(topV), (Vector3)(rayDirection * 50f), Color.green);
        //Debug.DrawRay((Vector3)(botV), (Vector3)(rayDirection * 50f), Color.green);

        Collider2D colliderHit = Physics2D.OverlapBox(origin, size, 0, movementController.groundLayer);
        return (colliderHit != null);
    }

    public static bool CheckDown(MovementController movementController)
    {
        Bounds bounds = movementController.GetColliderBounds();
        Vector2 origin = new Vector2(bounds.center.x, (bounds.center.y - bounds.extents.y));
        Vector2 size = new Vector2(bounds.size.x + GameConstants.COLLISION_CHECK_SHRINK_OFFSET,
                                   bounds.size.y);

        Collider2D colliderHit = Physics2D.OverlapBox(origin, size, 0, movementController.groundLayer);
        return (colliderHit != null);
    }

    public static void Slide(MovementController movementController, float slideSpeed)
    {
        if(movementController.body.velocity.y < slideSpeed)
        {
            movementController.body.velocity = new Vector2(movementController.body.velocity.x, slideSpeed);
        }
    }
}
