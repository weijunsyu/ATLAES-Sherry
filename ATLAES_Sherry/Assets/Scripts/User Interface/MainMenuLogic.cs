using UnityEngine;
using UnityEngine.UI;

public class MainMenuLogic : MonoBehaviour
{
    [SerializeField] private GameObject background;

    [Header("Background Image Objects")]
    [SerializeField] private Image alphaMask;
    [SerializeField] private Image aemilia;
    [SerializeField] private Image sherry;
    [SerializeField] private Image mask;
    [SerializeField] private Image redLight;
    [SerializeField] private Image spaceForeground;
    [SerializeField] private Image spaceBackground;
    [SerializeField] private Image backdrop;

    [Header("Menu Progress Sprite Masks")]
    [SerializeField] private Sprite maskTown1;
    [SerializeField] private Sprite maskX2;
    [SerializeField] private Sprite maskFinal;

    [Header("Menu Sherry and Aemilia Sprites")]
    [SerializeField] private Sprite sherryInitial;
    [SerializeField] private Sprite aemiliaInitial;
    [SerializeField] private Sprite sherryAemiliaFinal;

    private MasterManager masterManager = null;
    private SceneLoader sceneLoader = null;

    private void Awake()
    {
        masterManager = FindObjectOfType<MasterManager>();
        sceneLoader = masterManager.GetComponentInChildren<SceneLoader>();
        InitUserPreferences();
        InitMenuProgress();
    }


    public void LoadScene(int sceneIndex)
    {
        sceneLoader.LoadSceneByIndex(sceneIndex);
    }

    public void QuitGame()
    {
        sceneLoader.QuitGame();
    }

    private void InitMenuProgress()
    {
        sherry.sprite = sherryInitial;
        aemilia.sprite = aemiliaInitial;

        switch (MasterManager.userData.GetMenuProgression())
        {
            case 0: // Before playing singleplayer once
                aemilia.enabled = false;
                sherry.enabled = false;
                mask.enabled = false;
                redLight.enabled = false;
                spaceForeground.enabled = false;
                spaceBackground.enabled = false;
                backdrop.enabled = true;
                break;
            case 1: // Foreshadow first goal in singleplayer
                mask.sprite = maskTown1;

                aemilia.enabled = true;
                sherry.enabled = true;
                mask.enabled = true;
                redLight.enabled = true;
                spaceForeground.enabled = false;
                spaceBackground.enabled = false;
                backdrop.enabled = true;
                break;
            
            /* TODO */
            
            case 5: // After beating the game
                mask.sprite = maskFinal;
                sherry.sprite = sherryAemiliaFinal;

                aemilia.enabled = false;
                sherry.enabled = true;
                mask.enabled = true;
                redLight.enabled = true;
                spaceForeground.enabled = true;
                spaceBackground.enabled = true;
                backdrop.enabled = true;
                break;
            default:
                background.SetActive(false);
                break;
        }
    }
    private void InitUserPreferences()
    {
        alphaMask.enabled = true;
        alphaMask.color = new Color32(20, 20, 20, MasterManager.userData.GetMenuAlphaMask());
        
        if (MasterManager.userData.GetIsMinimalist())
        {
            background.SetActive(false);
        }
        else
        {
            background.SetActive(true);
        }
    }
}
