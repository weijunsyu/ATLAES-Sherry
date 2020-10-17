using UnityEngine;

[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(AnimationController))]
public abstract class AbstractStateController : MonoBehaviour
{
    // Config Parameters:

    // Cached References:
    protected MovementController movementController;
    protected AnimationController animationController;

    // State Parameters and Objects:
    protected AbstractState moveState;
    protected AbstractState actionState;
    protected AbstractState specialState;

    protected virtual void Awake()
    {
        movementController = this.GetComponent<MovementController>();
        animationController = this.GetComponent<AnimationController>();
    }
}
