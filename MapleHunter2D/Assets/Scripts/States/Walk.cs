
public class Walk : AbstractState
{
    public Walk(int animationID, AnimationController animationController, MovementController movementController)
    {
        this.animationID = animationID;
        this.animationController = animationController;
        this.movementController = movementController;
    }


    public override void Enter()
    {
        // Set animator to walk animation
        animationController.SetMoveState(animationID);
        // Stop lingering movement
        BasicMovement.StopHorizontal(movementController);
    }
    public override void Execute()
    {
        // Allow for left and right movement on the ground
        
    }
    public override void Exit()
    {

    }
}

