using UnityEngine;

public class SceneLoaderRef : MonoBehaviour
{
    private MasterManager masterManager = null;
    private SceneLoader sceneLoader = null;

    private void Awake()
    {
        masterManager = FindObjectOfType<MasterManager>();
        sceneLoader = masterManager.GetComponentInChildren<SceneLoader>();
    }

    public void LoadSceneByIndex(int index)
    {
        sceneLoader.LoadSceneByIndex(index);
    }

    public void AsyncLoadSceneByIndex(int index)
    {
        sceneLoader.AsyncLoadSceneByIndex(index);
    }
}
