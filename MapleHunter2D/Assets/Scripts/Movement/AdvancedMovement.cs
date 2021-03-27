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
                                            (movementController.boxCollider.bounds.center.y + movementController.crouchColliderSize.y)); // Center-top
        Vector2 overlapSize = new Vector2((movementController.crouchColliderSize.x + GameConstants.COLLISION_CHECK_SHRINK_OFFSET),
                                          movementController.crouchColliderSize.y);
        Collider2D colliderHit = Physics2D.OverlapBox(overlapCenter, overlapSize, 0f, movementController.groundLayer);
        return (colliderHit == null);
    }
    public static void Crouch(MovementController movementController)
    {
        movementController.SetCollider(movementController.crouchColliderSize, movementController.crouchColliderOffset);
        //MasterManager.playerCharacterNonPersistData.SetMoveSpeed(GameConstants.PLAYER_CROUCH_MOVE_SPEED);
    }
    // Return true if character successfully stands, false if cannot stand
    public static bool Stand(MovementController movementController)
    {
        if (CanStand(movementController))
        {
            movementController.SetCollider(movementController.standColliderSize, movementController.standColliderOffset);
            //MasterManager.playerCharacterNonPersistData.SetMoveSpeed(GameConstants.PLAYER_BASE_STAND_MOVE_SPEED);
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool checkFront(MovementController movementController) //return true if object in front
    {
        int facingDirection;
        if (movementController.IsFacingRight())
        {
            facingDirection = 1;
        }
        else
        {
            facingDirection = -1;
        }
        Vector2 overlapCenter = new Vector2((movementController.boxCollider.bounds.center.x + (facingDirection * movementController.boxCollider.bounds.extents.x)),
                                            movementController.boxCollider.bounds.center.y);
        Vector2 overlapSize = new Vector2(GameConstants.COLLISION_CHECK_DISTANCE_OFFSET,
                                          ((movementController.boxCollider.bounds.extents.y * 2) + GameConstants.COLLISION_CHECK_SHRINK_OFFSET));
        Collider2D colliderHit = Physics2D.OverlapBox(overlapCenter, overlapSize, 0f, movementController.groundLayer);

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
