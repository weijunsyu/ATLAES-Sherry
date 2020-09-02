using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    protected List<AbstractState> states = new List<AbstractState>();

    protected virtual void Awake()
    {
        movementController = this.GetComponent<MovementController>();
        animationController = this.GetComponent<AnimationController>();
    }
}
