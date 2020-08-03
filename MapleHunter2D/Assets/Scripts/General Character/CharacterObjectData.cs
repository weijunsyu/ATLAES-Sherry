using UnityEngine;

public class CharacterObjectData : MonoBehaviour
{
    // Config Parameters:

    // Cached References:
    protected GlobalPersistentObject globalPersistentObject = null;

    // State Parameters and Objects:
    private int currentHP, maxHP = 100;
    private int currentStamina, maxStamina = 100;
    private float moveSpeed = 5.5f;
    private float jumpVelocity = 10f;

    private int level = 0;

    // Unity Events:


    // Class Functions:
    public int GetLevel()
    {
        return level;
    }
    public void ModifyLevel(int value)
    {
        level += value;
    }
    public int GetMaxHp()
    {
        return maxHP;
    }
    public void ModifyMaxHP(int value)
    {
        maxHP += value;
    }
    public int GetCurrentHP()
    {
        return currentHP;
    }
    /* Modify currentHP by value such that currentHP = max[0, min[(currentHP + value), maxHP]].
     * Optional force tag : if set to true then current HP value can go above max HP value. */
    public void ModifyCurrentHP(int value, bool force = false)
    {
        if (force) // no max cap
        {
            currentHP = (int)ModifyResourceValue(currentHP, value);
        }
        else
        {
            currentHP = (int)ModifyResourceValue(currentHP, value, maxHP);
        }
    }
    /* Set currentHP = value returning true if value in range (0, maxHP], false otherwise. */
    public bool SetCurrentHP(int value)
    {
        currentHP = value;
        if(value < 0 || value > maxHP)
        {
            return false;
        }
        return true;
    }
    public int GetMaxStamina()
    {
        return maxStamina;
    }
    public void ModifyMaxStamina(int value)
    {
        maxStamina += value;
    }
    public int GetCurrentStamina()
    {
        return currentStamina;
    }
    /* Modify currentStamina by value such that currentStamina = max[0, min[(currentStamina + value), maxStamina]].
     * Optional force tag : if set to true then current Stamina value can go above max Stamina value. */
    public void ModifyCurrentStamina(int value, bool force = false)
    {
        if (force) // no max cap
        {
            currentStamina = (int)ModifyResourceValue(currentStamina, value);
        }
        else
        {
            currentStamina = (int)ModifyResourceValue(currentStamina, value, maxStamina);
        }
    }
    /* Set currentStamina = value returning true if value in range (0, maxStamina], false otherwise. */
    public bool SetCurrentStamina(int value)
    {
        currentStamina = value;
        if (value < 0 || value > maxStamina)
        {
            return false;
        }
        return true;
    }
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
    public void ModifyMoveSpeed(float value)
    {
        moveSpeed = ModifyResourceValue(moveSpeed, value);
    }
    public bool SetMoveSpeed(float value)
    {
        moveSpeed = value;
        if(value < 0)
        {
            return false;
        }
        return true;
    }
    public float GetJumpVelocity()
    {
        return jumpVelocity;
    }
    public void ModifyJumpVelocity(float value)
    {
        jumpVelocity = ModifyResourceValue(jumpVelocity, value);
    }
    public void SetJumpVelocity(float value)
    {
        jumpVelocity = value;
    }
    protected void SetMaxHP(int value)
    {
        maxHP = value;
    }
    protected void SetMaxStamina(int value)
    {
        maxStamina = value;
    }
    /* Modify currentResourceValue by modifyValue such that currentResourceValue = max[0, (currentResourceValue + modifyValue)].
     * Optional maxResourceValue tag : if given then currentResourceValue = max[0, min[(currentResourceValue + modifyValue), maxResourceValue]]. 
     * Return the new resource value: newResourceValue */
    protected static float ModifyResourceValue(float currentResourceValue, float modifyValue, float maxResourceValue = 0)
    {
        if (modifyValue == 0)
        {
            return currentResourceValue;
        }

        float newResourceValue = currentResourceValue + modifyValue;
        if (newResourceValue < 0)
        {
            return 0;
        }
        if (maxResourceValue == 0)
        {
            return newResourceValue;
        }
        switch ((maxResourceValue - newResourceValue) < 0)
        {
            case false: // newResourceValue less than or equal to maxResourceValue
                return newResourceValue;
            default: // newResourceValue more than maxResourceValue
                return maxResourceValue;
        }
    }
}
