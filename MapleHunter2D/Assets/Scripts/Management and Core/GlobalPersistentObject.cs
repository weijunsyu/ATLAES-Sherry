using UnityEngine;
using UnityEngine.Audio;

public class GlobalPersistentObject : MonoBehaviour
{
    // Config Parameters
    [SerializeField] private AudioMixer mixer = null;

    // State Parameters
    public PlayerData playerData;
    //public SceneLoader sceneLoader; //Un-comment if static functions do not work (and remove static from all functions in SceneLoader)


    private void Awake()
    {
        KeepPersistentStatus();
    }

    private void Start()
    {
        //init all persistent objects such as playerData
        playerData = new PlayerData();
        //sceneLoader = new SceneLoader(); //Un-comment if static functions do not work (and remove static from all functions in SceneLoader)
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
