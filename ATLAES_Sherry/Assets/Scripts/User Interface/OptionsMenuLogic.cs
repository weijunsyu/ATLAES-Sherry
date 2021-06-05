using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenuLogic : MonoBehaviour
{
    [SerializeField] private Image alphaMask = null;
    [SerializeField] private Canvas resetDefaultWarningPanel = null;

    [Header("Sub Panels")]
    [SerializeField] private Canvas generalCanvas = null;
    [SerializeField] private Canvas videoCanvas = null;
    [SerializeField] private Canvas audioCanvas = null;
    [SerializeField] private Canvas controlsCanvas = null;
    [SerializeField] private Canvas creditsCanvas = null;

    private MasterManager masterManager = null;

    private void Awake()
    {
        masterManager = FindObjectOfType<MasterManager>();
        EnableWarningPanel(false);
        EnableGeneral();
    }

    public void EnableGeneral()
    {
        DisableAllSubPanels();
        generalCanvas.enabled = true;
    }
    public void EnableVideo()
    {
        DisableAllSubPanels();
        videoCanvas.enabled = true;
    }
    public void EnableAudio()
    {
        DisableAllSubPanels();
        audioCanvas.enabled = true;
    }
    public void EnableControls()
    {
        DisableAllSubPanels();
        controlsCanvas.enabled = true;
    }
    public void EnableCredits()
    {
        DisableAllSubPanels();
        creditsCanvas.enabled = true;
    }
    public void EnableResetAllWarningPanel()
    {
        EnableWarningPanel(true);
    }
    public void ResetToDefaultCancel()
    {
        EnableWarningPanel(false);
    }

    public void ResetToDefaultAccept()
    {
        masterManager.ResetUser();
        EnableWarningPanel(false);
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene);
    }

    private void EnableWarningPanel(bool value)
    {
        alphaMask.enabled = value;
        resetDefaultWarningPanel.enabled = value;
    }
    private void DisableAllSubPanels()
    {
        generalCanvas.enabled = false;
        videoCanvas.enabled = false;
        audioCanvas.enabled = false;
        controlsCanvas.enabled = false;
        creditsCanvas.enabled = false;
    }
}
