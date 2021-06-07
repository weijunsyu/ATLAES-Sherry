using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class AudioOptionsLogic : MonoBehaviour
{
    [Header("Master Volume Settings")]
    [SerializeField] private Button masterButton = null;
    [SerializeField] private TextMeshProUGUI masterButtonText = null;
    [SerializeField] private Slider masterSlider = null;
    [Header("Music Volume Settings")]
    [SerializeField] private Button musicButton = null;
    [SerializeField] private TextMeshProUGUI musicButtonText = null;
    [SerializeField] private Slider musicSlider = null;
    [Header("Effects Volume Settings")]
    [SerializeField] private Button effectsButton = null;
    [SerializeField] private TextMeshProUGUI effectsButtonText = null;
    [SerializeField] private Slider effectsSlider = null;

    private MasterManager masterManager = null;
    private AudioMixer mixer = null;

    private void Awake()
    {
        masterManager = FindObjectOfType<MasterManager>();
        mixer = masterManager.mixer;
        InitSettings();
    }

    public void SetMasterVolume(float sliderValue)
    {
        float volume = ConvertSliderToVolume(sliderValue);
        SetVolume(volume, masterButtonText, masterButton,
                  GameConstants.DEFAULT_MASTER_VOLUME, GameConstants.MASTER_VOLUME_GROUP_NAME);
        MasterManager.userData.SetMasterVolume(volume);
        MasterManager.SaveSettings();
    }
    public void SetMusicVolume(float sliderValue)
    {
        float volume = ConvertSliderToVolume(sliderValue);
        SetVolume(volume, musicButtonText, musicButton,
                  GameConstants.DEFAULT_MUSIC_VOLUME, GameConstants.MUSIC_VOLUME_GROUP_NAME);
        MasterManager.userData.SetMusicVolume(volume);
        MasterManager.SaveSettings();
    }
    public void SetEffectsVolume(float sliderValue)
    {
        float volume = ConvertSliderToVolume(sliderValue);
        SetVolume(volume, effectsButtonText, effectsButton, 
                  GameConstants.DEFAULT_EFFECTS_VOLUME, GameConstants.EFFECTS_VOLUME_GROUP_NAME);
        MasterManager.userData.SetEffectsVolume(volume);
        MasterManager.SaveSettings();
    }
    public void ButtonMasterVolume()
    {
        float value = GameConstants.DEFAULT_MASTER_VOLUME;
        masterButton.colors = GetNewColorBlock(masterButton.colors, GameConstants.WHITE);
        masterButtonText.text = ToPercentageString(value);
        masterSlider.value = ConvertVolumeToSlider(GameConstants.DEFAULT_MASTER_VOLUME);
        float volumeLevel = StaticFunctions.ConvertPercentageRawToDecibels(value);
        mixer.SetFloat(GameConstants.MASTER_VOLUME_GROUP_NAME, volumeLevel);
        MasterManager.userData.SetMasterVolume(value);
        MasterManager.SaveSettings();
    }
    public void ButtonMusicVolume()
    {
        float value = GameConstants.DEFAULT_MUSIC_VOLUME;
        musicButton.colors = GetNewColorBlock(musicButton.colors, GameConstants.WHITE);
        musicButtonText.text = ToPercentageString(value);
        musicSlider.value = ConvertVolumeToSlider(GameConstants.DEFAULT_MUSIC_VOLUME);
        float volumeLevel = StaticFunctions.ConvertPercentageRawToDecibels(value);
        mixer.SetFloat(GameConstants.MUSIC_VOLUME_GROUP_NAME, volumeLevel);
        MasterManager.userData.SetMusicVolume(value);
        MasterManager.SaveSettings();
    }
    public void ButtonEffectsVolume()
    {
        float value = GameConstants.DEFAULT_EFFECTS_VOLUME;
        effectsButton.colors = GetNewColorBlock(effectsButton.colors, GameConstants.WHITE);
        effectsButtonText.text = ToPercentageString(value);
        effectsSlider.value = ConvertVolumeToSlider(GameConstants.DEFAULT_EFFECTS_VOLUME);
        float volumeLevel = StaticFunctions.ConvertPercentageRawToDecibels(value);
        mixer.SetFloat(GameConstants.EFFECTS_VOLUME_GROUP_NAME, volumeLevel);
        MasterManager.userData.SetEffectsVolume(value);
        MasterManager.SaveSettings();
    }
    private ColorBlock GetNewColorBlock(ColorBlock colorBlock, Color32 normalColour)
    {
        colorBlock.normalColor = normalColour;
        return colorBlock;
    }
    private void SetVolume(float value, TextMeshProUGUI text, Button button,
                           float volumeDefault, string volumeGroupName)
    {
        text.text = ToPercentageString(value);
        if (value == volumeDefault)
        {
            button.colors = GetNewColorBlock(button.colors, GameConstants.WHITE);
        }
        else
        {
            button.colors = GetNewColorBlock(button.colors, GameConstants.RED);
        }

        float volumeLevel = StaticFunctions.ConvertPercentageRawToDecibels(value);
        mixer.SetFloat(volumeGroupName, volumeLevel);
    }

    private void InitVolumeLevels(float value, Slider slider, Button button, TextMeshProUGUI text, 
                                 float volumeDefault, string volumeGroupName)
    {
        slider.value = ConvertVolumeToSlider(value);
        SetVolume(value, text, button, volumeDefault, volumeGroupName);
    }
    private void InitSettings()
    {
        UserData userData = MasterManager.userData;
        InitVolumeLevels(userData.GetMasterVolume(), masterSlider, masterButton, masterButtonText, 
                        GameConstants.DEFAULT_MASTER_VOLUME, GameConstants.MASTER_VOLUME_GROUP_NAME);
        InitVolumeLevels(userData.GetMusicVolume(), musicSlider, musicButton, musicButtonText, 
                        GameConstants.DEFAULT_MUSIC_VOLUME, GameConstants.MUSIC_VOLUME_GROUP_NAME);
        InitVolumeLevels(userData.GetEffectsVolume(), effectsSlider, effectsButton, effectsButtonText, 
                        GameConstants.DEFAULT_EFFECTS_VOLUME, GameConstants.EFFECTS_VOLUME_GROUP_NAME);
    }
    private string ToPercentageString(float value)
    {
        return ToPercentage(value).ToString() + "%";
    }
    private int ToPercentage(float value)
    {
        return Mathf.RoundToInt(value * 100);
    }
    private float ConvertSliderToVolume(float sliderValue)
    {
        return sliderValue / (GameConstants.NUM_DISCRETE_VOLUME_VALUES - 1);
    }
    private float ConvertVolumeToSlider(float volume)
    {
        return volume * (GameConstants.NUM_DISCRETE_VOLUME_VALUES - 1);
    }
}
