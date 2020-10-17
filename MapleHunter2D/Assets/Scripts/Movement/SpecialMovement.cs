
public static class SpecialMovement // Dash, Float(defend)
{
    // Assume character can indeed dash
    public static void DashMove(MovementController movementController)
    {
        float linearVelocity = MasterManager.playerCharacterNonPersistData.GetDashSpeed(); //update
        if (!movementController.IsFacingRight()) // player is facing left
        {
            linearVelocity = -linearVelocity;
        }
        movementController.SetHorizontal(linearVelocity);
        BasicMovement.StopVertical(movementController);
    }
    public static void Float(MovementController movementController, bool value) //where value = true if start floating, false if stop floating
    {
        if (value)
        {
            movementController.body.gravityScale /= GameConstants.FLOATING_BODY_GRAVITY_MODIFIER;
        }
        else if (!value)
        {
            movementController.body.gravityScale *= GameConstants.FLOATING_BODY_GRAVITY_MODIFIER;
        }
    }



} 
