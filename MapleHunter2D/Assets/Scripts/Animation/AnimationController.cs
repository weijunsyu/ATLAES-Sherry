using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    // Config Parameters

    // Cached References
    private Animator animator;

    // State Parameters and Objects:
    private int[] animationState = new int[3]; // moveState = 0, actionState = 1, specialState = 2


    // Unity Events:
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    // Class Functions:
    public int[] GetAnimationState()
    {
        return animationState;
    }
    public int GetMoveState()
    {
        return animationState[0];
    }
    public int GetActionState()
    {
        return animationState[1];
    }
    public int GetSpecialState()
    {
        return animationState[2];
    }
    public void SetAnimationState(int[] animationState)
    {
        this.animationState = animationState;
    }
    public void SetMoveState(int state)
    {
        animationState[0] = state;
    }
    public void SetActionState(int state)
    {
        animationState[1] = state;
    }
    public void SetSpecialState(int state)
    {
        animationState[2] = state;
    }
    public void RunAnimationState()
    {
        animator.SetInteger("Move State", GetAnimationState()[0]);
        animator.SetInteger("Action State", GetAnimationState()[1]);
        animator.SetInteger("Special State", GetAnimationState()[2]);
    }
}
