using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CharacterAction : MonoBehaviour
{
    // Config Parameters:

    // Cached References:
    protected BoxCollider2D boxCollider;

    // State Parameters and Objects:


    // Unity Events:
    protected virtual void Awake()
    {
        boxCollider = this.GetComponent<BoxCollider2D>();
    }


    // Class Functions:
}
