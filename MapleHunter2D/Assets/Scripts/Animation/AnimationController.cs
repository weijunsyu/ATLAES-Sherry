using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    // Config Parameters

    // Cached References
    private Animator animator;

    // State Parameters and Objects:
    private int moveState;
    private int actionState;
    private int specialState;


    // Unity Events:
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    // Class Functions:
    public int GetMoveState()
    {
        return moveState;
    }
    public int GetActionState()
    {
        return actionState;
    }
    public int GetSpecialState()
    {
        return specialState;
    }
    public void SetMoveState(int state)
    {
        moveState = state;
    }
    public void SetActionState(int state)
    {
        actionState = state;
    }
    public void SetSpecialState(int state)
    {
        specialState = state;
    }
    public void RunAnimationStates()
    {
        animator.SetInteger("Move State", GetMoveState());
        animator.SetInteger("Action State", GetActionState());
        animator.SetInteger("Special State", GetSpecialState());
    }
}
