using UnityEngine;

public class SingleplayerSaveLogic : MonoBehaviour
{
    [SerializeField] private SingleplayerData singleplayerData = null;

    private void Awake()
    {
        LoadSaves();
    }

    public void LoadSaves()
    {
        for(int i = 0; i < SingleplayerData.NUM_SAVE_SLOTS; i++)
        {
            singleplayerData.saveSlots[i] = SaveSystem.LoadPlayerData(i);
        }
    }
}
