using UnityEngine;

public class CharacterObjectData : MonoBehaviour
{

    // Game Parameters (for script calculations etc)
    [HideInInspector] public bool isFacingRight;

    private void Start()
    {
        //init game params
        isFacingRight = true;
    }
}
