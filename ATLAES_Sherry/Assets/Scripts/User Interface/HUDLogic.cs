using UnityEngine;
using TMPro;

public class HUDLogic : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hudTimer;


    private void Update()
    {
        hudTimer.text = MasterManager.timeInSeconds.ToString("0");
    }
}
