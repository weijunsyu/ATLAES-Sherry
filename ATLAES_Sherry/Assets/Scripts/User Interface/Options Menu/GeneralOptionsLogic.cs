using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GeneralOptionsLogic : MonoBehaviour
{
    [Header("Darken Menu Background Setting")]
    [SerializeField] private Toggle darkenMenuBackgroundsToggle = null;
    [SerializeField] private TextMeshProUGUI darkenMenuBackgroundsToggleText = null;
    [Header("Minimalist Mode Setting")]
    [SerializeField] private Toggle minimalistModeToggle = null;
    [SerializeField] private TextMeshProUGUI minimalistModeToggleText = null;
    [Header("Utility Overlay Setting")]
    [SerializeField] private Toggle utilityOverlayToggle = null;
    [SerializeField] private TextMeshProUGUI utilityOverlayToggleText = null;

    private MasterManager masterManager = null;

    private void Awake()
    {
        masterManager = FindObjectOfType<MasterManager>();
        InitSettings();
    }

    public void ToggleDarkMenuBackground(bool value)
    {
        StaticFunctions.ToggleTextYesNo(darkenMenuBackgroundsToggleText, value);
        if (value)
        {
            MasterManager.userData.SetMenuAlphaMask(GameConstants.MENU_ALPHA_DARKEN_VALUE);
        }
        else
        {
            MasterManager.userData.SetMenuAlphaMask(0);
        }
        MasterManager.SaveSettings();
    }
    public void ToggleMinimalistMode(bool value)
    {
        StaticFunctions.ToggleTextYesNo(minimalistModeToggleText, value);
        MasterManager.userData.SetIsMinimalist(value);
        MasterManager.SaveSettings();
    }
    public void ToggleUtilityOverlay(bool value)
    {
        StaticFunctions.ToggleTextYesNo(utilityOverlayToggleText, value);
        masterManager.ToggleUtilityOverlay(value);
        MasterManager.SaveSettings();
    }
    

    private void InitSettings()
    {
        if (MasterManager.userData.GetMenuAlphaMask() > 0)
        {
            darkenMenuBackgroundsToggle.isOn = true;
            darkenMenuBackgroundsToggleText.text = "YES";
        }
        else
        {
            darkenMenuBackgroundsToggle.isOn = false;
            darkenMenuBackgroundsToggleText.text = "NO";
        }
        
        if (MasterManager.userData.GetIsMinimalist())
        {
            minimalistModeToggle.isOn = true;
            minimalistModeToggleText.text = "YES";
        }
        else
        {
            minimalistModeToggle.isOn = false;
            minimalistModeToggleText.text = "NO";
        }
        if (MasterManager.userData.GetUtilityOverlayOn())
        {
            utilityOverlayToggle.isOn = true;
            utilityOverlayToggleText.text = "YES";
        }
        else
        {
            utilityOverlayToggle.isOn = false;
            utilityOverlayToggleText.text = "NO";
        }
    }
}
