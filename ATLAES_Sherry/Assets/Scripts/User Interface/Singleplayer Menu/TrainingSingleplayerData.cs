using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/TrainingModeData")]
public class TrainingSingleplayerData : ScriptableObject
{
    [HideInInspector] public const int CLASSIC_INDEX = 4;
    [HideInInspector] public const int BOXED_INDEX = 5;
    [HideInInspector] public const int ISLAND_INDEX = 6;
    [HideInInspector] public const int PLATFORMS_INDEX = 7;
    [HideInInspector] public const int LEFT_PRIMARY = 0;
    [HideInInspector] public const int LEFT_SECONDARY = 1;
    [HideInInspector] public const int RIGHT_PRIMARY = 2;
    [HideInInspector] public const int RIGHT_SECONDARY = 3;

    [HideInInspector] public bool isLeftPlayer;
    [HideInInspector] public WeaponType leftPrimary;
    [HideInInspector] public WeaponType leftSecondary;
    [HideInInspector] public WeaponType rightPrimary;
    [HideInInspector] public WeaponType rightSecondary;
    [HideInInspector] public int stageSceneIndex;

    [HideInInspector] public int tempWeaponSelector = -1;
}
