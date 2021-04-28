using System.Collections.Generic;
using UnityEngine;

public class PlayerActionController : AbstractActionController
{
    public enum ComboInput
    {
        FORWARD_PRESS = 1,
        BACKWARD_PRESS = 2,
        CROUCH_PRESS = 3,
        UP_PRESS = 4,
        GUARD_PRESS = 5,
        JUMP_PRESS = 6,
        DASH_PRESS = 7,
        LIGHT_PRESS = 8,
        MEDIUM_PRESS = 9,
        HEAVY_PRESS = 10,
        FORWARD_RELEASE = -1,
        BACKWARD_RELEASE = -2,
        CROUCH_RELEASE = -3,
        UP_RELEASE = -4,
        GUARD_RELEASE = -5,
        JUMP_RELEASE = -6,
        DASH_RELEASE = -7,
        LIGHT_RELEASE = -8,
        MEDIUM_RELEASE = -9,
        HEAVY_RELEASE = -10,
    }

    // Config parameters:

    // Cached References:

    // State Parameters and Objects:
    [HideInInspector] public Stack<(PlayerInputController.RawInput input, double time)> inputBuffer = new Stack<(PlayerInputController.RawInput input, double time)>();
    private double timeCounter = 0d;
    private bool bufferLocked = false;

    // Unity Events:
    protected override void Awake()
    {
        base.Awake();
    }
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
    public void ImpartRelativeForce(Vector2 force)
    {
        if (!movementController.IsFacingRight())
        {
            force.x = -force.x;
        }
        movementController.ImpartForce(force);
    }
    public void ImpartRelativeImpulse(Vector2 force)
    {
        if (!movementController.IsFacingRight())
        {
            force.x = -force.x;
        }
        movementController.ImpartImpulse(force);
    }
    public void ResetInputBuffer()
    {
        inputBuffer.Clear();
    }
    public void AddToBuffer(PlayerInputController.RawInput input)
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
