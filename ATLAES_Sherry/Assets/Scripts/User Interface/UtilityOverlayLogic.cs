using UnityEngine;
using TMPro;

public class UtilityOverlayLogic : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI fps;
    [SerializeField] private TextMeshProUGUI ping;

    private void Update()
    {
        fps.text = CorrectFpsValue(MasterManager.fps.ToString("0"));
        DisplayPing();
    }

    private string CorrectFpsValue(string value)
    {
        if (value.Length > 4)
        {
            return "9999";
        }
        return value;
    }
    private void DisplayPing()
    {
        
        if (MasterManager.gameMode == GameMode.OnlineMultiplayer)
        {
            SetPingColour(MasterManager.ping);
            ping.text = FormatPingValue(MasterManager.ping.ToString("0"));
        }
        else
        {
            ping.text = "";
        }
    }
    private void SetPingColour(double value)
    {
        if (value < 50)
        {
            ping.color = Color.cyan;
        }
        else if (value < 100)
        {
            ping.color = Color.green;
        }
        else if (value < 150)
        {
            ping.color = Color.yellow;
        }
        else
        {
            ping.color = Color.red;
        }
    }
    private string FormatPingValue(string value)
    {
        if(value.Length > 3)
        {
            return "999ms";
        }
        return value + "ms";
    }
}
