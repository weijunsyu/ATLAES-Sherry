using UnityEngine;

public class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
{
    private static T _instance = null;
    public static T Instance
    {
        get
        {
            if (_instance = null)
            {
                T[] results = Resources.FindObjectsOfTypeAll<T>();
                Debug.Log("Test 1");
                if (results.Length == 0)
                {
                    Debug.Log("Results length is 0 of type " + typeof(T).ToString());
                    return null;
                }
                if (results.Length > 1)
                {
                    Debug.Log("Results length greater than 1 of type " + typeof(T).ToString());
                    return null;
                }
                _instance = results[0];
                _instance.hideFlags = HideFlags.DontUnloadUnusedAsset;
            }
            Debug.Log("Test 2 ");
            Debug.Log("Test 2 " + _instance.ToString());
            return _instance;

        }
    }
}
