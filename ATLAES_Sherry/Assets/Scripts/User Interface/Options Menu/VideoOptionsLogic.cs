using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VideoOptionsLogic : MonoBehaviour
{
    [Header("Fullscreen Setting")]
    [SerializeField] private Toggle fullscreenToggle = null;
    [SerializeField] private TextMeshProUGUI fullscreenToggleText = null;
    [Header("VSync Setting")]
    [SerializeField] private Toggle vSyncToggle = null;
    [SerializeField] private TextMeshProUGUI vSyncToggleText = null;
    [Header("Target FPS Setting")]
    [SerializeField] private TextMeshProUGUI targetFpsText = null;
    [SerializeField] private TextMeshProUGUI fpsText = null;
    [SerializeField] private TMP_InputField fpsInput = null;
    [SerializeField] private Image fpsBorder = null;
    [SerializeField] private Slider fpsSlider = null;
    [SerializeField] private Image sliderFill = null;
    [SerializeField] private Image sliderHandle = null;

    private void Awake()
    {
        InitSettings();
    }


    public void ToggleFullscreen(bool value)
    {
        StaticFunctions.ToggleTextYesNo(fullscreenToggleText, value);
        MasterManager.userData.SetIsFullscreen(value);
        MasterManager.userData.RunIsFullscreen();
        MasterManager.SaveSettings();
    }
    public void ToggleVSync(bool value)
    {
        StaticFunctions.ToggleTextYesNo(vSyncToggleText, value);
        MasterManager.userData.SetVSync(value);
        MasterManager.userData.RunVSync();
        MasterManager.SaveSettings();

        if (value)
        {
            DisableFpsSetting();
        }
        else
        {
            EnableFpsSetting();
        }
    }
    public void HandleFpsSlider(float value)
    {
        int trueValue = DetermineFpsValueFromSlider(value);
        if (trueValue == GameConstants.FPS_5)
        {
            fpsText.text = "Unlimited";
        }
        else
        {
            fpsText.text = trueValue.ToString();
        }
        MasterManager.userData.SetTargetFPS(trueValue);
        MasterManager.userData.RunTargetFPS();
        MasterManager.SaveSettings();
    }
    public void HandleFpsInput(string value)
    {
        int trueValue;
        if (int.TryParse(value, out trueValue))
        {
            trueValue = Mathf.Clamp(trueValue, GameConstants.MIN_FPS, GameConstants.MAX_FPS);
            fpsSlider.value = RoundFpsToSliderValue(trueValue);
            fpsText.text = trueValue.ToString();
            MasterManager.userData.SetTargetFPS(trueValue);
            MasterManager.userData.RunTargetFPS();
            MasterManager.SaveSettings();
        }
        fpsInput.text = "";
    }

    private void EnableFpsSetting()
    {
        targetFpsText.color = GameConstants.WHITE;
        fpsSlider.interactable = true;
        sliderFill.color = GameConstants.RED;
        sliderHandle.color = GameConstants.WHITE;
        fpsInput.interactable = true;
        fpsBorder.color = GameConstants.WHITE;
    }
    private void DisableFpsSetting()
    {
        targetFpsText.color = GameConstants.DARK_GREY;
        fpsSlider.interactable = false;
        sliderFill.color = GameConstants.DARK_GREY;
        sliderHandle.color = GameConstants.DARK_GREY;
        fpsInput.interactable = false;
        fpsBorder.color = GameConstants.DARK_GREY;
    }
    private int DetermineFpsValueFromSlider(float value)
    {
        switch (value)
        {
            case 0:
                return GameConstants.FPS_0;
            case 1:
                return GameConstants.FPS_1;
            case 2:
                return GameConstants.FPS_2;
            case 3:
                return GameConstants.FPS_3;
            case 4:
                return GameConstants.FPS_4;
            case 5:
                return GameConstants.FPS_5;
            default:
                return GameConstants.FPS_5;
        }
    }
    private float RoundFpsToSliderValue(int fps)
    {
        int interValue_1 = ((GameConstants.FPS_1 - GameConstants.FPS_0) / 2) + GameConstants.FPS_0;
        int interValue_2 = ((GameConstants.FPS_2 - GameConstants.FPS_1) / 2) + GameConstants.FPS_1;
        int interValue_3 = ((GameConstants.FPS_3 - GameConstants.FPS_2) / 2) + GameConstants.FPS_2;
        int interValue_4 = ((GameConstants.FPS_4 - GameConstants.FPS_3) / 2) + GameConstants.FPS_3;

        if (fps < 0) // fps = -1, slider = 5
        {
            return fpsSlider.maxValue;
        }
        else if (fps < interValue_1) // 0 <= fps < ((120-60)/2) + 60 = 90, slider = 0
        {
            return fpsSlider.minValue;
        }
        else if (fps < interValue_2) // 90 <= fps < 132, slider = 1
        {
            return fpsSlider.minValue + 1;
        }
        else if (fps < interValue_3) // 132 <= fps < 192, slider = 2
        {
            return fpsSlider.minValue + 2;
        }
        else if (fps < interValue_4) // 192 <= fps < 300, slider = 3
        {
            return fpsSlider.minValue + 3;
        }
        else if (fps <= GameConstants.FPS_4) // 300 <= fps <= 360, slider = 4 
        {
            return fpsSlider.minValue + 4;
        }
        else // Should never occur
        {
            Debug.LogError("FPS Slider entered else block in RoundFpsToSliderValue function (VideoOptionsLogic.cs)");
            return fpsSlider.maxValue;
        }
    }
    private void InitSettings()
    {
        fpsSlider.minValue = 0;
        fpsSlider.maxValue = GameConstants.NUM_DISCRETE_FPS_VALUES - 1;

        if (MasterManager.userData.GetIsFullscreen())
        {
            fullscreenToggle.isOn = true;
            fullscreenToggleText.text = "YES";
        }
        else
        {
            fullscreenToggle.isOn = false;
            fullscreenToggleText.text = "NO";
        }

        if (MasterManager.userData.GetVSync())
        {
            vSyncToggle.isOn = true;
            vSyncToggleText.text = "YES";
            DisableFpsSetting();
        }
        else
        {
            vSyncToggle.isOn = false;
            vSyncToggleText.text = "NO";
            EnableFpsSetting();
        }

        int fps = MasterManager.userData.GetTargetFPS();
        if (fps == -1) // FPS is unlimited
        {
            fpsText.text = "Unlimited";
            fpsSlider.value = fpsSlider.maxValue;
        }
        else
        {
            fpsText.text = fps.ToString();
            fpsSlider.value = RoundFpsToSliderValue(fps);
        }
    }
}
