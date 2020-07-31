using UnityEngine;

public class PlayerCharacterData : CharacterObjectData
{
    // Config parameters:
    [SerializeField] public float jumpVelocity = 4f;
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public float dashSpeed = 20f;

    // Cached References:

    // State Parameters and Objects:
    [HideInInspector] public bool playerHasControl = true; //true if player has control over character (user input is accepted), false otherwise

    // Stats
    private int level = 0;

    //Skills
    private int maxAirJumps = 1;

    // Unity Events:


    // Class Functions:
    public int GetMaxAirJumps()
    {
        return maxAirJumps;
    }
}
