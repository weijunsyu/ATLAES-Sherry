
public static class SpecialMovement // Dash, Float
{
    // Assume character can indeed dash
    public static void DashMove(MovementController movementController, float speed)
    {
        //float linearVelocity = MasterManager.playerCharacterNonPersistData.GetDashSpeed();
        float linearVelocity = speed;
        if (!movementController.IsFacingRight()) // player is facing left
        {
            linearVelocity = -linearVelocity;
        }
        movementController.SetHorizontal(linearVelocity);
        BasicMovement.StopVertical(movementController);
    }
    public static void Float(MovementController movementController, bool value, float gravity) //where value = true if start floating, false if stop floating
    {
        if (value)
        {
            movementController.body.gravityScale /= gravity;
            //movementController.body.gravityScale /= GameConstants.FLOATING_BODY_GRAVITY_MODIFIER;
        }
        else if (!value)
        {
            movementController.body.gravityScale *= gravity;
            //movementController.body.gravityScale *= GameConstants.FLOATING_BODY_GRAVITY_MODIFIER;
        }
    }



} 
