using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class SingleplayerNewGameLogic : MonoBehaviour
{
    [SerializeField] private SingleplayerSaveLogic singleplayerSaveLogic = null;
    [SerializeField] private SingleplayerData singleplayerData = null;
    [SerializeField] private SceneLoaderRef sceneLoader = null;
    [SerializeField] private Image alphaMask = null;
    [SerializeField] private Canvas saveSlotsMenuCanvas = null;
    [SerializeField] private TextMeshProUGUI saveSlotsText = null;

    [Header("Adventure Save Slot 1")]
    [SerializeField] private Button save0Button;
    [SerializeField] private TextMeshProUGUI save0Text;

    [Header("Adventure Save Slot 2")]
    [SerializeField] private Button save1Button;
    [SerializeField] private TextMeshProUGUI save1Text;

    [Header("Adventure Save Slot 3")]
    [SerializeField] private Button save2Button;
    [SerializeField] private TextMeshProUGUI save2Text;

    [Header("Fighting Save Slot 1")]
    [SerializeField] private Button save3Button;
    [SerializeField] private TextMeshProUGUI save3Text;

    [Header("Fighting Save Slot 2")]
    [SerializeField] private Button save4Button;
    [SerializeField] private TextMeshProUGUI save4Text;

    [Header("Fighting Save Slot 3")]
    [SerializeField] private Button save5Button;
    [SerializeField] private TextMeshProUGUI save5Text;

    [Header("Hunter Save Slot 1")]
    [SerializeField] private Button save6Button;
    [SerializeField] private TextMeshProUGUI save6Text;

    [Header("Hunter Save Slot 2")]
    [SerializeField] private Button save7Button;
    [SerializeField] private TextMeshProUGUI save7Text;

    [Header("Hunter Save Slot 3")]
    [SerializeField] private Button save8Button;
    [SerializeField] private TextMeshProUGUI save8Text;

    private MasterManager masterManager = null;
    private int saveSlotNum = -1;

    private void Awake()
    {
        masterManager = FindObjectOfType<MasterManager>();
        saveSlotNum = -1;
        alphaMask.enabled = false;
        saveSlotsMenuCanvas.enabled = false;
    }
    private void Start()
    {
        InitAllSaveSlots();
    }
    public void AcceptSaveButton()
    {
        int sceneNum = singleplayerData.saveSlots[saveSlotNum].locationSceneIndex;
        sceneLoader.AsyncLoadSceneByIndex(sceneNum);
    }
    public void CancelSaveButton()
    {
        alphaMask.enabled = false;
        saveSlotsMenuCanvas.enabled = false;
    }
    public void DeleteSaveButton()
    {
        SaveSystem.DeletePlayerData(saveSlotNum);
        alphaMask.enabled = false;
        saveSlotsMenuCanvas.enabled = false;
        singleplayerSaveLogic.LoadSaves();
        InitAllSaveSlots();
    }
    public void StartGameButton(int combinedSlotNumWorldType)
    {
        int worldType;
        DecodeCombinedInt(in combinedSlotNumWorldType, out saveSlotNum, out worldType);
        if (singleplayerData.saveSlots[saveSlotNum] == null)
        {
            // Start new game:
            masterManager.ResetGame();
            MasterManager.worldData.SetWorldType(worldType);
            masterManager.SaveGame(saveSlotNum);
            sceneLoader.AsyncLoadSceneByIndex(8);
        }
        else
        {
            // Load game:
            masterManager.LoadGame(saveSlotNum);
            alphaMask.enabled = true;
            saveSlotsMenuCanvas.enabled = true;
            InitSaveSlot(singleplayerData.saveSlots[saveSlotNum], saveSlotsText, saveSlotNum);
        }
    }
    private void DecodeCombinedInt(in int combinedNum, out int saveSlotNum, out int worldType)
    {
        saveSlotNum = combinedNum / 10;
        worldType = combinedNum % 10;
    }
    private void InitAllSaveSlots()
    {
        InitSaveSlot(singleplayerData.saveSlots[0], save0Text, 0);
        InitSaveSlot(singleplayerData.saveSlots[1], save1Text, 1);
        InitSaveSlot(singleplayerData.saveSlots[2], save2Text, 2);
        InitSaveSlot(singleplayerData.saveSlots[3], save3Text, 3);
        InitSaveSlot(singleplayerData.saveSlots[4], save4Text, 4);
        InitSaveSlot(singleplayerData.saveSlots[5], save5Text, 5);
        InitSaveSlot(singleplayerData.saveSlots[6], save6Text, 6);
        InitSaveSlot(singleplayerData.saveSlots[7], save7Text, 7);
        InitSaveSlot(singleplayerData.saveSlots[8], save8Text, 8);
    }
    private void InitSaveSlot(SaveData save, TextMeshProUGUI saveText, int saveNum)
    {
        if (save == null) // If save doesnt exist
        {
            saveText.alignment = TextAlignmentOptions.Center;
            saveText.fontSize = 150;
            saveText.text = "Start New Game";
        }
        else if (save.finishedGame > 0) // If new game +
        {
            saveText.alignment = TextAlignmentOptions.Left;
            saveText.fontSize = 100;
            saveText.text = "Save File " + saveNum + "<br>" +
                            "Location: " + GetLocationString(save.locationSceneIndex) + "<br>" +
                            "Playtime: " + GetPlaytimeString(save.playTime) +
                            " (" + GetPlaytimeString(save.finishGameTime) + ")";
        }
        else // If save exists but not in new game +
        {
            saveText.alignment = TextAlignmentOptions.Left;
            saveText.fontSize = 100;
            saveText.text = "Save File " + saveNum + "<br>" +
                            "Location: " + GetLocationString(save.locationSceneIndex) + "<br>" +
                            "Playtime: " + GetPlaytimeString(save.playTime);
        }
    }

    private string GetLocationString(int sceneIndex)
    {
        switch (sceneIndex)
        {
            case 8:
                return "Crashsite";
            case 9:
                return "Village";
            default:
                return "Unknown";
        }
    }

    private string GetPlaytimeString(double time)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);
        string formattedTime;
        if (timeSpan.Days > 0)
        {
            int hours = (timeSpan.Days * 24) + timeSpan.Hours;
            formattedTime = string.Format("{0:D1}h{1:D2}m{2:D2}s",
                        hours,
                        timeSpan.Minutes,
                        timeSpan.Seconds);
        }
        else
        {
            formattedTime = string.Format("{0:D1}h{1:D2}m{2:D2}s",
                        timeSpan.Hours,
                        timeSpan.Minutes,
                        timeSpan.Seconds);
        }
        return formattedTime;
    }
}
