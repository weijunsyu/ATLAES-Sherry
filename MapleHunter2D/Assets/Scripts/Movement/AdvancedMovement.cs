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
        Vector2 overlapCenter = new Vector2(movementController.boxCollider.bounds.center.x,
                                            (movementController.transform.position.y + movementController.standColliderOffset.y)); // Center when standing
        Vector2 overlapSize = new Vector2((movementController.boxCollider.size.x + GameConstants.COLLISION_CHECK_SHRINK_OFFSET),
                                          movementController.standColliderSize.y + GameConstants.COLLISION_CHECK_SHRINK_OFFSET);
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
    public static void checkFront(MovementController movementController, out bool topHit, out bool bottomHit)
    {
        topHit = checkFrontTop(movementController);
        bottomHit = checkFrontBottom(movementController);
    }

    //return true if object in front of foot
    public static bool checkFrontBottom(MovementController movementController)
    {
        Bounds bounds = movementController.boxCollider.bounds;
        Vector2 bottomRayOrigin = new Vector2(bounds.center.x, bounds.center.y - bounds.extents.y);
        Vector2 rayDirection;
        float rayDistance = GameConstants.SLIDING_CHECK_DISTANCE_CAST;
        if (movementController.IsFacingRight())
        {
            rayDirection = Vector2.right;
            bottomRayOrigin.x += bounds.extents.x;
        }
        else
        {
            rayDirection = Vector2.left;
            bottomRayOrigin.x -= bounds.extents.x;
        }
        
        //Debug.DrawRay((Vector3)(bottomRayOrigin), (Vector3)(rayDirection * rayDistance), Color.green);
        RaycastHit2D bottomColliderHit = Physics2D.Raycast(bottomRayOrigin, rayDirection, rayDistance, movementController.groundLayer);

        return (bottomColliderHit.collider != null);
    }

    //return true if object in front of head
    public static bool checkFrontTop(MovementController movementController)
    {
        Bounds bounds= movementController.boxCollider.bounds;
        Vector2 topRayOrigin = new Vector2(bounds.center.x, bounds.center.y + bounds.extents.y);
        Vector2 rayDirection;
        float rayDistance = GameConstants.SLIDING_CHECK_DISTANCE_CAST;
        if (movementController.IsFacingRight())
        {
            rayDirection = Vector2.right;
            topRayOrigin.x += bounds.extents.x;
        }
        else
        {
            rayDirection = Vector2.left;
            topRayOrigin.x -= bounds.extents.x;
        }

        //Debug.DrawRay((Vector3)(topRayOrigin), (Vector3)(rayDirection * rayDistance), Color.green);
        RaycastHit2D topColliderHit = Physics2D.Raycast(topRayOrigin, rayDirection, rayDistance, movementController.groundLayer);

        return (topColliderHit.collider != null);
    }

    public static void Slide(MovementController movementController, float slideSpeed)
    {
        if(movementController.body.velocity.y < slideSpeed)
        {
            movementController.body.velocity = new Vector2(movementController.body.velocity.x, slideSpeed);
        }
    }
}
