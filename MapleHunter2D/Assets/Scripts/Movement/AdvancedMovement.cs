
public static class AdvancedMovement
{
    /* Check if player character can stand back up (assume character is already crouching or dashing)
     * Implemented by simply checking if current collider has ground collider above itself */
    public static bool CanStand()
    {
        Vector2 overlapCenter = new Vector2(boxCollider.bounds.center.x, (boxCollider.bounds.center.y + crouchColliderSize.y)); // Center-top
        Vector2 overlapSize = new Vector2((crouchColliderSize.x + GameConstants.COLLISION_CHECK_SHRINK_OFFSET), crouchColliderSize.y);
        Collider2D colliderHit = Physics2D.OverlapBox(overlapCenter, overlapSize, 0f, groundLayer);
        return (colliderHit == null);
    }
    public static void Crouch(MovementController movementController)
    {
        attemptingStand = false;
        SetCollider(crouchColliderSize, crouchColliderOffset);
        MasterManager.playerCharacterNonPersistData.SetMoveSpeed(GameConstants.PLAYER_BASE_CROUCH_MOVE_SPEED);
    }
    public static void Stand(MovementController movementController)
    {
        if (CanStand())
        {
            SetCollider(standColliderSize, standColliderOffset);
            MasterManager.playerCharacterNonPersistData.SetMoveSpeed(GameConstants.PLAYER_BASE_STAND_MOVE_SPEED);
        }
        else
        {
            attemptingStand = true;
        }
    }
}
