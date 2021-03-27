using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    // Config Parameters

    // Cached References
    private Animator animator;

    // State Parameters and Objects:
    private int primaryState;
    private int secondaryState;
    private int overrideState;


    // Unity Events:
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    // Class Functions:
    public int GetPrimaryState()
    {
        return primaryState;
    }
    public int GetSecondaryState()
    {
        return secondaryState;
    }
    public int GetOverrideState()
    {
        return overrideState;
    }
    public void SetPrimaryState(int state)
    {
        primaryState = state;
    }
    public void SetSecondaryState(int state)
    {
        secondaryState = state;
    }
    public void SetOverrideState(int state)
    {
        overrideState = state;
    }
    public void RunAnimationStates()
    {
        animator.SetInteger("Primary State", GetPrimaryState());
        animator.SetInteger("Secondary State", GetSecondaryState());
        animator.SetInteger("Override State", GetOverrideState());
    }
}
