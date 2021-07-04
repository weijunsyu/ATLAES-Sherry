using System.Collections.Generic;
using UnityEngine;

public class PlayerActionController : AbstractActionController
{

    // Config parameters:

    // Cached References:

    // State Parameters and Objects:

    // Unity Events:
    protected override void Awake()
    {
        base.Awake();
    }

    // Class Functions:
    public void ImpartRelativeForce(Vector2 force)
    {
        if (!movementController.IsFacingRight())
        {
            force.x = -force.x;
        }
        movementController.ImpartForce(force);
    }
    public void ImpartRelativeImpulse(Vector2 force)
    {
        if (!movementController.IsFacingRight())
        {
            force.x = -force.x;
        }
        movementController.ImpartImpulse(force);
    }
}
