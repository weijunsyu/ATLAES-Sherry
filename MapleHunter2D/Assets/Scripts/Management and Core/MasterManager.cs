using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/MasterManager")]
public class MasterManager : SingletonScriptableObject<MasterManager>
{
    //Definitions:

    // Config Parameters:

    // Cached References:
    [SerializeField] private PlayerData _playerData;

    // State Parameters and Objects
    public static PlayerData PlayerData { get { return Instance._playerData; } }
}
