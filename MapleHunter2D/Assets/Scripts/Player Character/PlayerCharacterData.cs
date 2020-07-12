using UnityEngine;

public class PlayerCharacterData : MonoBehaviour
{
    //constants
    public const float jumpVelocity = 5f;
    public const float moveSpeed = 5f;

    // Game Parameters (for script calculations etc)
    [HideInInspector] public bool facingRight;
    [HideInInspector] public bool isMovingRight;
    [HideInInspector] public bool isMovingLeft;
    [HideInInspector] public bool canStop;

    //stats
    private int level = 0;

    private void Start()
    {
        //init game params
        facingRight = true;
        isMovingRight = false;
        isMovingLeft = false;
        canStop = true;
    }
}
