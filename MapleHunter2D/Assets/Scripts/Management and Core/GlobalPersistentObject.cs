using UnityEngine;
using UnityEngine.Audio;

public class GlobalPersistentObject : MonoBehaviour
{
    // Config Parameters
    [SerializeField] private AudioMixer mixer = null;

    // State Parameters
    public PlayerCharacterData playerData = null;
    public SaveLoadWrapper saveLoadWrapper = new SaveLoadWrapper();


    private void Awake()
    {
        KeepPersistentStatus();
    }

    private void Start()
    {
        //init all persistent objects
        //saveLoadWrapper = new SaveLoadWrapper();
        //playerData = new PlayerCharacterData(); do this on loading of some save game and populate parameters at that time
    }

    private void KeepPersistentStatus()
    {
        int gameStatusCount = FindObjectsOfType<GlobalPersistentObject>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
