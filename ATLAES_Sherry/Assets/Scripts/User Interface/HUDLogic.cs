using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class HUDLogic : MonoBehaviour
{
    [Header("Center Timer")]
    [SerializeField] private TextMeshProUGUI hudTimer;
    [Header("Player Health Bar")]
    [SerializeField] private Slider playerHealthBarBlue;
    [SerializeField] private Slider playerHealthBarRed;
    [SerializeField] private TextMeshProUGUI playerHealthText;
    [Header("Other Health Bar")]
    [SerializeField] private Slider otherHealthBarBlue;
    [SerializeField] private Slider otherHealthBarRed;
    [SerializeField] private TextMeshProUGUI otherHealthText;

    private static string hudTimerText = "ERROR";

    private void Awake()
    {
        playerHealthBarBlue.maxValue = GameConstants.MAX_HP;
        playerHealthBarRed.maxValue = GameConstants.MAX_HP;
        otherHealthBarBlue.maxValue = GameConstants.MAX_HP;
        otherHealthBarRed.maxValue = GameConstants.MAX_HP;

        playerHealthBarBlue.minValue = 0;
        playerHealthBarRed.minValue = 0;
        otherHealthBarBlue.minValue = 0;
        otherHealthBarRed.minValue = 0;

    }

    private void Update()
    {
        hudTimer.text = hudTimerText;

        playerHealthBarBlue.value = MasterManager.playerRecoverableHP;
        playerHealthBarRed.value = MasterManager.playerHP;
        playerHealthText.text = MasterManager.playerHP.ToString();
        
        otherHealthBarBlue.value = MasterManager.otherRecoverableHP;
        otherHealthBarRed.value = MasterManager.otherHP;
        otherHealthText.text = MasterManager.otherHP.ToString();
    }

    public static string GetHudTimerText()
    {
        return hudTimerText;
    }
    public static void SetHudTimerText(double time, bool countdown=true)
    {
        if (countdown)
        {
            hudTimerText = CorrectCountdownValue(time);
        }
        else
        {
            hudTimerText = CorrectCountupValue(time);
        }
    }
    // Return false if health falls to 0, true otherwise.
    public static bool ModHealth(ref int Health,ref int Recovery, int value, bool recoverableHP = false, bool force = false)
    {
        int newHP = Health + value;
        newHP = Mathf.Clamp(newHP, 0, GameConstants.MAX_HP);

        if (newHP <= 0)
        {
            Health = 0;
            return false;
        }
        
        if (newHP < Health) // If health went down
        {
            Health = newHP;
            if (!recoverableHP)
            {
                Recovery = Health;
            }
        }
        else // If health went up
        {
            if (Recovery < newHP) // If new health value is more than what is allowed to be recovered
            {
                if (!force) // If we are to respect the recovery bar value
                {
                    Health = Recovery;
                }
                else // If we are to force the new health value
                {
                    Health = newHP;
                    Recovery = Health;
                }
            }
            else // If new health value is less than what is allowed to be recovered
            {
                Health = newHP;
            }
        }

        return true;
    }
    public static void ResetRecoveryHP(ref int Health, ref int Recovery)
    {
        Recovery = Health;
    }

    private static string CorrectCountdownValue(double time)
    {
        string value = time.ToString("0");

        int numDigits = value.Length;
        if (numDigits > GameConstants.MAX_WHOLE_DIGITS_IN_TIMER)
        {
            string eValue = (double.Parse(value)).ToString("0.00e0");
            int numEDigits = eValue.Length;
            if (numEDigits > GameConstants.MAX_E_VALUE_LENGTH_IN_TIMER)
            {
                return "NaN";
            }
            //convert number to scientific notation.
            return eValue;
        }
        return value;
    }
    private static string CorrectCountupValue(double time)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);
        string formattedTime;
        if (timeSpan.Days > 0)
        {
            int hours = (timeSpan.Days * 24) + timeSpan.Hours;
            formattedTime = string.Format("{0:D2}:{1:D2}",
                        hours,
                        timeSpan.Minutes);
        }
        else
        {
            formattedTime = string.Format("{0:D2}:{1:D2}:{2:D2}",
                        timeSpan.Hours,
                        timeSpan.Minutes,
                        timeSpan.Seconds);
        }
        return formattedTime;
    }
}
