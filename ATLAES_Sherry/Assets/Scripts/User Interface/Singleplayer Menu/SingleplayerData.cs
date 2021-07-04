using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/SingleplayerData")]
public class SingleplayerData : ScriptableObject
{
    public const int NUM_SAVE_SLOTS = 9;

    [HideInInspector] public SaveData[] saveSlots = new SaveData[NUM_SAVE_SLOTS];
}
