using UnityEngine;
using UnityEngine.UI;

public class SingleplayerMenuLogic : MonoBehaviour
{
    [SerializeField] private Image alphaMask = null;
    [SerializeField] private Canvas deleteSaveWarningPanel = null;

    [Header("Sub Panels")]
    [SerializeField] private Canvas adventureCanvas = null;
    [SerializeField] private Canvas fightingCanvas = null;
    [SerializeField] private Canvas platformerCanvas = null;
    [SerializeField] private Canvas hunterCanvas = null;
    [SerializeField] private Canvas trainingCanvas = null;
    [SerializeField] private Canvas optionsCanvas = null;

    private MasterManager masterManager = null;

    private void Awake()
    {
        masterManager = FindObjectOfType<MasterManager>();
        DisableWarningPanel();
        EnableFighting();
    }

    public void EnableAdventure()
    {
        DisableAllSubPanels();
        adventureCanvas.enabled = true;
    }
    public void EnableFighting()
    {
        DisableAllSubPanels();
        fightingCanvas.enabled = true;
    }
    public void EnablePlatformer()
    {
        DisableAllSubPanels();
        platformerCanvas.enabled = true;
    }
    public void EnableHunter()
    {
        DisableAllSubPanels();
        hunterCanvas.enabled = true;
    }
    public void EnableTraining()
    {
        DisableAllSubPanels();
        trainingCanvas.enabled = true;
    }
    public void EnableOptions()
    {
        DisableAllSubPanels();
        optionsCanvas.enabled = true;
    }

    private void DisableWarningPanel()
    {
        alphaMask.enabled = false;
        deleteSaveWarningPanel.enabled = false;
    }
    private void DisableAllSubPanels()
    {
        adventureCanvas.enabled = false;
        fightingCanvas.enabled = false;
        platformerCanvas.enabled = false;
        hunterCanvas.enabled = false;
        trainingCanvas.enabled = false;
        optionsCanvas.enabled = false;
    }
}
