
public static class BasicMovement
{
    public static void Jump(MovementController movementController, float linearVelocity)
    {
        if (!movementController.IsAirborne())
        {
            movementController.SetVertical(linearVelocity);
        }
    }
    public static void MoveWithTurn(MovementController movementController, float linearVelocity, int direction = 0)
    {
        if (linearVelocity > 0 || direction == 1) //move to the right
        {
            if (!movementController.IsFacingRight()) //currently facing left
            {
                movementController.Turn(); //turn to face right
            }
        }
        else if (linearVelocity < 0 || direction == -1) //move to left
        {
            if (movementController.IsFacingRight()) //currently facing right
            {
                movementController.Turn(); //turn to face left
            }
        }
        //If linearVelocity == 0 then do nothing (if need some action add else block)
        movementController.SetHorizontal(linearVelocity);
    }
    public static void StopHorizontal(MovementController movementController)
    {
        movementController.SetHorizontal(0);
    }
    public static void StopVertical(MovementController movementController)
    {
        movementController.SetVertical(0);
    }
    public static void StopAll(MovementController movementController)
    {
        StopHorizontal(movementController);
        StopVertical(movementController);
    }
}
