
public class Idle : AbstractState
{
    public Idle(int animationID, AnimationController animationController, MovementController movementController)
    {
        this.animationID = animationID;
        this.animationController = animationController;
        this.movementController = movementController;
    }


    public override void Enter()
    {

        // Set animator to idle animation
        animationController.SetMoveState(animationID);
        // Stop character movement horizontally
        BasicMovement.StopHorizontal(movementController);

    }
    public override void Execute()
    {
        // Check if ground under player has disapeared (not implemented as of now)
        // movementController.UpdateAirborne();



    }
    public override void Exit()
    {

    }
}
