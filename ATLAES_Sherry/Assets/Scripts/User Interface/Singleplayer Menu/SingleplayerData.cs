using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/SingleplayerData")]
public class SingleplayerData : ScriptableObject
{
    [HideInInspector] public SaveData adventureSave0 = null;
    [HideInInspector] public SaveData adventureSave1 = null;
    [HideInInspector] public SaveData adventureSave2 = null;

    [HideInInspector] public SaveData fightingSave3 = null;
    [HideInInspector] public SaveData fightingSave4 = null;
    [HideInInspector] public SaveData fightingSave5 = null;

    [HideInInspector] public SaveData platformerSave6 = null;
    [HideInInspector] public SaveData platformerSave7 = null;
    [HideInInspector] public SaveData platformerSave8 = null;

    [HideInInspector] public SaveData platformerSave9 = null;
    [HideInInspector] public SaveData platformerSave10 = null;
    [HideInInspector] public SaveData platformerSave11 = null;
}
