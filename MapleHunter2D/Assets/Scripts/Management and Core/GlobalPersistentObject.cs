using UnityEngine;
using UnityEngine.Audio;

public class GlobalPersistentObject : MonoBehaviour
{
    //Definitions:

    // Config Parameters

    // Cached References:
    [SerializeField] private AudioMixer mixer = null;

    // State Parameters and Objects
    public SaveLoadWrapper saveLoadWrapper = new SaveLoadWrapper();

    private void Awake()
    {
        KeepPersistentStatus();
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
