using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalPersistentObject : MonoBehaviour
{
    private void Awake()
    {
        KeepPersistentStatus();
    }

    private void Start()
    {
        //init all persistent objects such as playerData
        PlayerData playerData = new PlayerData();
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
