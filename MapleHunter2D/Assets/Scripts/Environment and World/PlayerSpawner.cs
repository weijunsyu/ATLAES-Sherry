using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    // Cached References:
    [SerializeField] private GameObject playerObjectToSpawn = null;
    [HideInInspector] public GameObject playerCharacter = null;

    public void SpawnCharacter()
    {
        playerCharacter = Instantiate(playerObjectToSpawn, this.transform.position, Quaternion.identity, this.transform);
    }
}
