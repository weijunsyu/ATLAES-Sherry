using UnityEngine;
using System.Collections.Generic;

public class PlayerInputData : MonoBehaviour
{
    // Config parameters:

    // Cached References:

    // State Parameters and Objects:
    [HideInInspector] public Stack<(PlayerInputs.RawInputAction input, double time)> inputBuffer = new Stack<(PlayerInputs.RawInputAction input, double time)>();
    private double timeCounter = 0d;
    private bool bufferLocked = false;

    [HideInInspector] public bool[] pressedInputs = new bool[GameConstants.NUM_INPUTS]; // where false is unpressed and index -> input
    [HideInInspector] public bool[] inputTokens = new bool[GameConstants.NUM_INPUTS]; // Similar to pressedInputs except inputs are eaten on use



    // Unity Events:
    private void Start()
    {
        timeCounter = 0d;
        bufferLocked = false;
    }
    private void Update()
    {
        timeCounter += Time.deltaTime;
    }

    // Class Functions:
    public void EatInputToken(int index)
    {
        inputTokens[index] = false;
    }
    public void LockBuffer()
    {
        bufferLocked = true;
    }
    public void UnlockBuffer()
    {
        bufferLocked = false;
    }
    public bool IsBufferLocked()
    {
        return bufferLocked;
    }
    public void ResetInputBuffer()
    {
        inputBuffer.Clear();
    }
    public void AddToBuffer(PlayerInputs.RawInputAction input)
    {
        if (bufferLocked) // If the buffer is locked then do nothing
        {
            return;
        }

        double currentTime = timeCounter;
        inputBuffer.Push((input, currentTime));
    }
    public double GetBufferRelativeTime()
    {
        return timeCounter;
    }
}
