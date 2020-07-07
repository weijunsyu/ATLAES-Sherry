using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    // Return the index number of the current scene
    public static int GetCurrentSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
    // Load immediately the next Scene
    public static void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if ((currentSceneIndex + 1) < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            Debug.LogError("Reached end of scene list, next scene does not exist. Cannot load.");
        }
    }

    public static void LoadPreviousScreen()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex - 1 > 0)
        {
            SceneManager.LoadScene(currentSceneIndex - 1);
        }
        else
        {
            Debug.LogError("Reached beginning of scene list, previous scene does not exist. Cannot load.");
        }
    }
    public static void LoadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
    public static void LoadFromEnd(int reversedIndex)
    {
        int index = SceneManager.sceneCountInBuildSettings - 1 - reversedIndex;
        SceneManager.LoadScene(index);
    }

    // Functions for Async Loading of scenes:
}
