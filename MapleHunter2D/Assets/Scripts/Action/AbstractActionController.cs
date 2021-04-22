using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(MovementController))]
public abstract class AbstractActionController : MonoBehaviour
{
    // Config Parameters:

    // Cached References:
    protected BoxCollider2D boxCollider;
    protected MovementController movementController;

    // State Parameters and Objects:


    // Unity Events:
    protected virtual void Awake()
    {
        boxCollider = this.GetComponent<BoxCollider2D>();
        movementController = this.GetComponent<MovementController>();
    }
}
