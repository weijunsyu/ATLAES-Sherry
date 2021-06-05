using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Canvas loadingScreen;
    [SerializeField] private Slider progressBar;

    private void Awake()
    {
        loadingScreen.enabled = false;
    }

    // Return the index number of the current scene
    public int GetCurrentSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
    // Load immediately the next Scene
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if ((currentSceneIndex + 1) < SceneManager.sceneCountInBuildSettings)
        {
            LoadSceneByIndex(currentSceneIndex + 1);
        }
        else
        {
            Debug.LogError("Reached end of scene list, next scene does not exist. Cannot load.");
        }
    }

    public void LoadPreviousScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex - 1 > 0)
        {
            LoadSceneByIndex(currentSceneIndex - 1);
        }
        else
        {
            Debug.LogError("Reached beginning of scene list, previous scene does not exist. Cannot load.");
        }
    }
    public void LoadFromEnd(int reversedIndex)
    {
        int index = SceneManager.sceneCountInBuildSettings - 1 - reversedIndex;
        LoadSceneByIndex(index);
    }
    public void LoadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Functions for Async Loading of scenes:
    public void AsyncLoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if ((currentSceneIndex + 1) < SceneManager.sceneCountInBuildSettings)
        {
            AsyncLoadSceneByIndex(currentSceneIndex + 1);
        }
        else
        {
            Debug.LogError("Reached end of scene list, next scene does not exist. Cannot load.");
        }
    }
    public void AsyncLoadPreviousScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex - 1 > 0)
        {
            AsyncLoadSceneByIndex(currentSceneIndex - 1);
        }
        else
        {
            Debug.LogError("Reached beginning of scene list, previous scene does not exist. Cannot load.");
        }
    }
    public void AsynLoadFromEnd(int reversedIndex)
    {
        int index = SceneManager.sceneCountInBuildSettings - 1 - reversedIndex;
        AsyncLoadSceneByIndex(index);
    }
    public void AsyncLoadSceneByIndex(int index)
    {
        StartCoroutine(AsyncLoadRoutine(index));
    }

    private IEnumerator AsyncLoadRoutine(int index)
    {
        loadingScreen.enabled = true;
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            progress = (progress * (705f - 38f)) + 38f;
            Debug.Log(progress);
            progressBar.value = progress;
            yield return null;
        }
        loadingScreen.enabled = false;
    }
}
