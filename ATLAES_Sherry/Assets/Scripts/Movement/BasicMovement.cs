public static class BasicMovement // Jump, Strafe, Move(turning), Stop(x only, y only, both x and y)
{
    public static void Jump(MovementController movementController, float linearVelocity)
    {
        movementController.SetVertical(linearVelocity);
    }
    public static void Strafe(MovementController movementController, float linearVelocity)
    {
        movementController.SetHorizontal(linearVelocity);
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
        //If linearVelocity == 0 then do nothing
        movementController.SetHorizontal(linearVelocity);
    }
    public static void StopHorizontal(MovementController movementController)
    {
        movementController.SetHorizontal(0);
    }
    public static void StopVertical(MovementController movementController)
    {
        movementController.SetVertical(0);
        movementController.NegateGravity();
    }
    public static void StopAll(MovementController movementController)
    {
        StopHorizontal(movementController);
        StopVertical(movementController);
    }
}
