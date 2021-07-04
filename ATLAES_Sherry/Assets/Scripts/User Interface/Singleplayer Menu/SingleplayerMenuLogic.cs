using UnityEngine;

public class SingleplayerMenuLogic : MonoBehaviour
{
    [Header("Sub Panels")]
    [SerializeField] private Canvas adventureCanvas = null;
    [SerializeField] private Canvas fightingCanvas = null;
    [SerializeField] private Canvas hunterCanvas = null;
    [SerializeField] private Canvas trainingCanvas = null;
    [SerializeField] private Canvas optionsCanvas = null;

    private void Awake()
    {
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
    private void DisableAllSubPanels()
    {
        adventureCanvas.enabled = false;
        fightingCanvas.enabled = false;
        hunterCanvas.enabled = false;
        trainingCanvas.enabled = false;
        optionsCanvas.enabled = false;
    }
}
