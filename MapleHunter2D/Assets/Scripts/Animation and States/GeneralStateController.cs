using UnityEngine;

[RequireComponent(typeof(Animator))]
public class GeneralStateController : MonoBehaviour
{
    // Config Parameters

    // Cached References
    protected Animator animator;

    // Public Variables:
    [HideInInspector] public bool isAirborne = false;

    // State Parameters and Objects:
    protected int animationState = 0;
    protected int moveState = 0;
    protected int actionState = 0;


    // Unity Events:
    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
    }


    // Class Functions:
    protected int GetAnimationState()
    {
        return animationState;
    }
    protected int GetMoveState()
    {
        return moveState;
    }
    protected int GetActionState()
    {
        return actionState;
    }
    protected void SetAnimationState(int state)
    {
        animationState = state;
    }
    protected void SetMoveState(int state)
    {
        moveState = state;
    }
    protected void SetActionState(int state)
    {
        actionState = state;
    }
    protected void RunAnimationState()
    {
        animator.SetInteger("Animation State", GetAnimationState());
    }
}
