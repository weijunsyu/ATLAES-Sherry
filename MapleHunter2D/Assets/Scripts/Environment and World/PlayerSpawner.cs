using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    // Cached References:
    [SerializeField] private GameObject playerObjectToSpawn = null;
    private GameObject playerCharacter = null;


    private void Start()
    {
        SpawnCharacter();
    }

    private void SpawnCharacter()
    {
        playerCharacter = Instantiate(playerObjectToSpawn, this.transform.position, Quaternion.identity, this.transform);
    }
}
