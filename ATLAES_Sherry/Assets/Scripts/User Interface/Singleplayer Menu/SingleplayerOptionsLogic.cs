using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SingleplayerOptionsLogic : MonoBehaviour
{
    [Header("Game Timer Setting")]
    [SerializeField] private Toggle gameTimerToggle = null;
    [SerializeField] private TextMeshProUGUI gameTimerToggleText = null;
    [Header("Skip All Cutscenes Setting")]
    [SerializeField] private Toggle skipCutscenesToggle = null;
    [SerializeField] private TextMeshProUGUI skipCutscenesToggleText = null;
    [Header("Equalize Load Times Setting")]
    [SerializeField] private Toggle equalizeLoadTimesToggle = null;
    [SerializeField] private TextMeshProUGUI equalizeLoadTimesToggleText = null;


    private void Awake()
    {
        InitSettings();
    }

    public void GameTimerToggle(bool value)
    {
        StaticFunctions.ToggleTextYesNo(gameTimerToggleText, value);
        MasterManager.userData.SetGameTimer(value);
        MasterManager.SaveSettings();
    }
    public void SkipCutscenesToggle(bool value)
    {
        StaticFunctions.ToggleTextYesNo(skipCutscenesToggleText, value);
        MasterManager.userData.SetSkipCutscenes(value);
        MasterManager.SaveSettings();
    }
    public void EqualizeLoadTimesToggle(bool value)
    {
        StaticFunctions.ToggleTextYesNo(equalizeLoadTimesToggleText, value);
        MasterManager.userData.SetEqualLoadTimes(value);
        MasterManager.SaveSettings();
    }

    private void InitSettings()
    {
        gameTimerToggle.isOn = MasterManager.userData.GetGameTimer();
        StaticFunctions.ToggleTextYesNo(gameTimerToggleText, 
                                        MasterManager.userData.GetGameTimer());
        
        skipCutscenesToggle.isOn = MasterManager.userData.GetSkipCutscenes();
        StaticFunctions.ToggleTextYesNo(skipCutscenesToggleText, 
                                        MasterManager.userData.GetSkipCutscenes());
        
        equalizeLoadTimesToggle.isOn = MasterManager.userData.GetEqualLoadTimes();
        StaticFunctions.ToggleTextYesNo(equalizeLoadTimesToggleText, 
                                        MasterManager.userData.GetEqualLoadTimes());
    }
}
