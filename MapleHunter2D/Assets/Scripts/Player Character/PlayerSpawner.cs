using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    // Cached References:
    [SerializeField] private GameObject playerObjectToSpawn = null;
    [SerializeField] private PlayerData playerData = null;
    private GameObject playerCharacter = null;


    private void Start()
    {
        playerData.ResetGame();
        SpawnCharacter();
    }

    private void SpawnCharacter()
    {
        playerCharacter = Instantiate(playerObjectToSpawn, this.transform.position, Quaternion.identity, this.transform);
    }
}
