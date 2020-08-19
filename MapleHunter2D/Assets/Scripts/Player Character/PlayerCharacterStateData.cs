using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/PlayerCharacterStateData")]
public class PlayerCharacterStateData : ScriptableObject
{
    private bool playerHasCharacterControl = true;
    private AnimationState animationState = AnimationState.IDLE;


    // Unity Events:
    private void Awake()
    {
        ResetAllPlayerCharacterStateData();
    }



    // Class Functions:
    public void ResetAllPlayerCharacterStateData()
    {
        SetPlayerHasCharacterControl(true);
        SetAnimationState(AnimationState.IDLE);
    }
    public bool GetPlayerHasCharacterControl()
    {
        return playerHasCharacterControl;
    }
    public void SetPlayerHasCharacterControl(bool value)
    {
        playerHasCharacterControl = value;
    }
    public AnimationState GetAnimationState()
    {
        return animationState;
    }
    public void SetAnimationState(AnimationState state)
    {
        animationState = state;
    }
}
