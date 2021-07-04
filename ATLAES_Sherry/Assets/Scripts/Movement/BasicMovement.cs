using UnityEngine;

public static class BasicMovement // Jump, Strafe, Move(turning), Stop(x only, y only, both x and y)
{
    public static void Jump(MovementController movementController, float linearVelocity)
    {
        movementController.SetVertical(linearVelocity);
    }
    public static void Strafe(MovementController movementController, float linearVelocity, bool sliding = true)
    {
        if (sliding && !movementController.IsAirborne())
        {
            if (movementController.UpdateIsOnSlope())
            {
                MoveOnSlope(movementController, linearVelocity);
            }
            else
            {
                movementController.SetHorizontal(linearVelocity);
            }
        }
        else
        {
            movementController.SetHorizontal(linearVelocity);
        }
    }
    public static void MoveWithTurn(MovementController movementController, float linearVelocity, int direction = 0, bool sliding = true)
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
        Strafe(movementController, linearVelocity, sliding);
    }
    public static void MoveInDirection(MovementController movementController, float speed)
    {
        if (movementController.IsFacingRight())
        {
            Strafe(movementController, speed);
        }
        else
        {
            Strafe(movementController, -speed);
        }
    }
    public static void StopHorizontal(MovementController movementController, bool sliding = false)
    {
        if(sliding && movementController.UpdateIsOnSlope())
        {
            StopVertical(movementController);
        }
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


    private static void MoveOnSlope(MovementController movementController, float linearVelocity)
    {
        Vector2 slopeTangent = movementController.slopeTangent;
        Vector2 newVelocity = new Vector2(-linearVelocity * slopeTangent.x,
                                          -linearVelocity * slopeTangent.y);
        
        movementController.SetHorizontal(newVelocity.x);
        movementController.SetVertical(newVelocity.y);
    }
}
