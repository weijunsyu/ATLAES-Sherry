using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    // Cached References:
    [SerializeField] private GameObject playerObjectToSpawn = null;


    private void Start()
    {
        SpawnCharacter();
    }

    private void SpawnCharacter()
    {
        GameObject playerCharacter = Instantiate(playerObjectToSpawn, this.transform.position, Quaternion.identity, this.transform);
    }
}
